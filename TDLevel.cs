using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefense
{
    public class TDLevel
    {
        public static bool testing = false;

        public static int StartingHP = 100;
        public static int WaveDelay = 30000; // some permutation of ms (adjusted for the speed factor (normal speed factor = .1)
        public static int AttackerDelayWithinWave = 2000; // some permutation of ms

        #region Public fields
        public int Level;
        public TDMap Map;
        public List<TDAttacker> Attackers = new List<TDAttacker>();
        public List<TDTower> Towers = new List<TDTower>();
        public List<TDAmmo> Ammo = new List<TDAmmo>();
        public List<TDExplosion> Explosions = new List<TDExplosion>();
        public Image BackImage;
        private int _WaveStarted;
        public int WaveStarted
        {
            get { return _WaveStarted; }
            set
            {
                if (this._WaveStarted != value)
                {
                    TDForm.ThisForm.SetLabelText(TDForm.ThisForm.lblNextWave, "" + value + " / " + TDSession.thisSession.CurrentLevel.WaveCount);
                }

                this._WaveStarted = value;
            }
        }
        private int _WaveCount;
        public int WaveCount
        {
            get
            {
                return _WaveCount;
            }
            set
            {
                _WaveCount = value;
            }
        }

        bool LevelHasStarted = false;
        #endregion

        #region Private Members
        private int _HPRemaining;
        #endregion

        #region Public Properties
        public int HPRemaining
        {
            get { return _HPRemaining; }
            set
            {
                _HPRemaining = value;
                TDForm.ThisForm.SetLabelText(TDForm.ThisForm.lblHP, Math.Max(0, value).ToString());
            }
        }
        #endregion

        #region Constructor and Setup
        public TDLevel(int lvl)
        {
            this.Level = lvl;
            HPRemaining = StartingHP;

            this.Map = new TDMap(TDResources.Maps[lvl - 1]);

            if (this.Map.Paths != null && this.Map.Paths.Count > 0)
            {
                GenerateAttackersForLevel(lvl, this.Map.Paths);
            }
        }
        private void GenerateAttackersForLevel(int lvl, List<TDPath> Paths)
        {
            // waves
            this._WaveCount = 9 + (lvl);

            if (testing) { _WaveCount = 0; }

            // wave attacker type
            bool mixed = (TDMath.D(100) > 70); // 30% mixed

            // attackers per wave
            int attPerWave = 5 + TDMath.D(10 * lvl);

            if (testing) { attPerWave = 0; }

            // if 80, then betwen 41 and 80;
            int ThisWaveDelay = (WaveDelay / 2) + TDMath.D(WaveDelay / 2);

            if (testing) { ThisWaveDelay = WaveDelay; }

            int MaxDelay = 0;

            // for each wave
            for (int i = 0; i < this._WaveCount; i++)
            {
                // set the type and path for this wave
                AttackerTypes t = GetWeightedAttackerType(false);
                TDPath p = Paths[TDMath.D(Paths.Count) - 1];

                // vary the attacker separation for this wave (between 1/2 and full value)
                int AttackerDelayWithinThisWave = (AttackerDelayWithinWave / 2) + TDMath.D((AttackerDelayWithinWave / 2));

                if (testing)
                {
                    AttackerDelayWithinThisWave = AttackerDelayWithinWave;
                }

                for (int j = 0; j < attPerWave; j++)
                {
                    // check for mixed attacker type
                    if (mixed && lvl > 3) // don't mix until lvl 4+
                    {
                        // randomized the type for the next attacker
                        t = GetWeightedAttackerType(true);
                        p = Paths[TDMath.D(Paths.Count) - 1];
                    }

                    // generate the new attacker
                    TDAttacker a = new TDAttacker(t, lvl);
                    a.WaveIndex = i + 1;

                    int delayMS = Math.Max(1, (i * ThisWaveDelay) + (j * AttackerDelayWithinThisWave)); // slightly stagger each attacker within the wave (j)
                    a.Effects.Add(new TDEffect(TDEffectTypes.WaveDelay, 0, new TimeSpan(0, 0, 0, 0, delayMS), false));
                    a.SetPath(p);

                    this.Attackers.Add(a);

                    // remember the MaxDelay for the Boss
                    MaxDelay = Math.Max(MaxDelay, delayMS);
                }
            }

            // and finally, add the level boss
            TDAttacker boss = new TDAttacker(AttackerTypes.Boss, lvl + 10);
            boss.Size += 4;
            boss.HPMax = boss.HPMax * 6;
            boss.HPCurrent = boss.HPMax;
            int AdditionalBossDelay = 500;
            if (testing) { AdditionalBossDelay = 10000; }
            boss.Effects.Add(new TDEffect(TDEffectTypes.WaveDelay, 0, new TimeSpan(0, 0, 0, 0, MaxDelay + AdditionalBossDelay), false)); // 1/2 second after last attacker
            TDPath pBoss = Paths[TDMath.D(Paths.Count) - 1];
            boss.SetPath(pBoss);
            this.Attackers.Add(boss);
        }
        private AttackerTypes GetWeightedAttackerType(bool AllowBoss)
        {
            int d = TDMath.D(100);
            if (d < 25)
            {
                return AttackerTypes.Goblin;
            }
            else if (d < 50)
            {
                return AttackerTypes.GoblinArcher;
            }
            else if (d < 75)
            {
                return AttackerTypes.Orc;
            }
            else if (d < 95 || (AllowBoss == false)) // boss number will default to troll
            {
                return AttackerTypes.Troll;
            }
            else // d >= 95
            {
                return AttackerTypes.Boss;
            }
        }
        #endregion

        #region Public Methods
        internal void Update()
        {
            if (!LevelHasStarted)
            {
                // start all wave delay effects
                for (int i = this.Attackers.Count - 1; i >= 0; i--)
                {
                    if (this.Attackers[i].DeleteMe)
                    {
                        TDSession.thisSession.gold += this.Attackers[i].Cost;
                        this.Attackers.RemoveAt(i); continue;
                    }
                    else
                    {
                        this.Attackers[i].StartWaveDelayEffects();
                    }
                }

                // and set this to have startedl
                LevelHasStarted = true;
            }

            #region End Checking
            // update biggest conditions first
            // death
            if (this.HPRemaining <= 0)
            {
                TDForm.ThisForm.DisplayLoss();
                return;
            }

            // win
            if (this.Attackers.Count == 0)
            {
                TriggerWin();
                return;
            }
            #endregion

            #region Update each object
            // each attacker
            for (int i = this.Attackers.Count - 1; i >= 0; i--)
            {
                if (this.Attackers[i].DeleteMe) 
                {
                    TDSession.thisSession.gold += this.Attackers[i].Cost;
                    this.Attackers.RemoveAt(i); continue; 
                }
                else
                {
                    this.Attackers[i].Update();
                }
            }

            // each tower
            for (int i = this.Towers.Count - 1; i >= 0; i--)
            {
                if (this.Towers[i].DeleteMe) { this.Towers.RemoveAt(i); continue; }
                else
                {
                    this.Towers[i].Update();
                }
            }

            // each ammo
            for (int i = this.Ammo.Count - 1; i >= 0; i--)
            {
                if (this.Ammo[i].DeleteMe) { this.Ammo.RemoveAt(i); continue; }
                else
                {
                    this.Ammo[i].Update();
                }
            }

            // each explosion
            for (int i = this.Explosions.Count - 1; i >= 0; i--)
            {
                if (this.Explosions[i].DeleteMe)
                {
                    this.Explosions.RemoveAt(i); 
                    continue; 
                }
                else
                {
                    this.Explosions[i].Update();
                }
            }
            #endregion
        }
        internal void DrawSelf(Graphics g)
        {
            DrawBackground(g);

            DrawAttackers(g);
            DrawTowers(g);
            DrawAmmo(g);
            DrawExplosions(g);
        }
        internal void DrawBackground(Graphics g)
        {
            this.Map.Draw(g);
        }
        #region Draw Sprites
        internal void DrawAttackers(Graphics g)
        {
            // remain single threaded - tried Parallel but jumped the cpu
            for (int i = 0; i < this.Attackers.Count; i++)
            {
                if(this.Attackers[i] != null &&
                    !this.Attackers[i].DeleteMe)
                {
                    this.Attackers[i].DrawSelf(g);
                }
            }
        }
        internal void DrawTowers(Graphics g)
        {
            for (int i = 0; i < this.Towers.Count; i++)
            {
                if (this.Towers[i] != null &&
                    !this.Towers[i].DeleteMe)
                {
                    this.Towers[i].DrawSelf(g);
                }
            }
        }
        internal void DrawAmmo(Graphics g)
        {
            for (int i = 0; i < this.Ammo.Count; i++)
            {
                if (this.Ammo[i] != null &&
                    !this.Ammo[i].DeleteMe)
                {
                    this.Ammo[i].DrawSelf(g);
                }
            }
        }
        internal void DrawExplosions(Graphics g)
        {
            for (int i = 0; i < this.Explosions.Count; i++)
            {
                if (this.Explosions[i] != null &&
                    !this.Explosions[i].DeleteMe)
                {
                    this.Explosions[i].DrawSelf(g);
                }
            }
        }
        #endregion

        #region Effects
        internal void PauseAllEffects()
        {
            foreach (TDAttacker a in this.Attackers)
            {
                if (a.Effects.Count > 0)
                {
                    foreach (TDEffect e in a.Effects)
                    {
                        e.Pause();
                    }
                }
            }
        }
        internal void ResumeAllEffects()
        {
            foreach (TDAttacker a in this.Attackers)
            {
                a.ResumeEffects();
            }
        }
        internal void AdjustEffectDurations(double OldSpeedFactor, double SpeedFactor)
        {
            foreach (TDAttacker a in this.Attackers)
            {
                if (a.Effects.Count > 0)
                {
                    a.AdjustEffectDurations(OldSpeedFactor, SpeedFactor);
                }
            }
        }
        #endregion
        #endregion

        #region private Functions
        private void TriggerWin()
        {
            TDSession.thisSession.Paused = true;
            // display Win
            TDForm.ThisForm.DisplayLevelWin(this.Level);

            // advance to level 2
            TDSession.thisSession.AdvanceLevel();
        }
        #endregion

        public bool CanPlaceTower(TDTower t)
        {
            if (Map.isTowerOnPath(t))
            {
                return false;
            }

            // if on other tower - no
            if (isTowerOnTowers(t))
            {
                return false;
            }

            return true;
        }
        internal bool isTowerOnTowers(TDTower target)
        {
            foreach (TDTower t in this.Towers)
            {
                if (TDMath.Intersects(target.Location, target.Size, t.Location, t.Size))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
