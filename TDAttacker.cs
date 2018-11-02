using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefense
{
    public enum AttackerTypes
    {
        Boss = 1,
        Troll = 2,
        Orc = 3,
        Goblin = 4,
        GoblinArcher = 5
    }

    public class TDAttacker: TDEntity
    {
        private int NextPoint = 0;
        private bool CanStart = false;
        public int WaveIndex = 0;
        public bool Immune = true;

        private Image _MainImage = null;
        public Image MainImage
        {
            get
            {
                return _MainImage;
            }
            set
            {
                if (value != null)
                {
                    _MainImage = value;
                    // brush settings?
                }
            }
        }

        TDPath Path;

        #region Constructors and Setup
        public TDAttacker(string Name, int HP, int Speed, int Damage, int Range, int CoolDown)
        {
            base.MainColor = Color.Red;

            this.Name = Name;
            this.HPMax = HP;
            this.HPCurrent = HP;
            this.SpeedMax = Math.Max(5,Speed);
            this.SpeedCurrent = Speed;
            this.BulletDamage = Damage;
            this.Range = Range;
            this.Cooldown = new TimeSpan(0, 0, 0, 0, CoolDown);
        }
        public TDAttacker(AttackerTypes t, int Level)
        {
            // get attacker template for enum
            TDAttacker a = TDResources.Attackers[((int)t - 1)];

            this.Name = a.Name;
            this.MainColor = Color.Red;

            if (a.MainImage != null)
            {
                this.MainImage = a.MainImage;
            }

            // adjust stats for level
            
            // HP  - quickly increase
            this.HPMax = a.HPMax + (Level * 10);
            this.HPCurrent = this.HPMax;

            // Range - slowly increase
            this.Range = (a.Range * 2) + (Level / 5);

            // Speed - slowly increase
            this.SpeedMax = Math.Max(1, (a.SpeedMax + Level) / 4);
            this.SpeedCurrent = this.SpeedMax;

            // Damage - increase linearly
            this.BulletDamage = (a.BulletDamage / 10) + (Level);

            // bullet speed
            this.BulletSpeed = a.BulletSpeed;

            // cooldown remains constant
            this.Cooldown = new TimeSpan(0,0,0,0,(int)(a.Cooldown.TotalMilliseconds * 100));

            // cost (loot)
            this.Cost = 5 + ((Level - 1) * 2);
        }
        #endregion

        #region Public Methods
        public void SetPath(TDPath Path)
        {
            this.Path = Path;

            // automatically set the starting location to the first point on the path.
            this.Location = new TDLocation(Path.PathPoints[0].Location.X, Path.PathPoints[0].Location.Y);
        }
        public override void Update()
        {
            if (this.CanStart && this.Immune)
            {
                this.Immune = false;
                // update the next wave to be at least this index.
                TDSession.thisSession.CurrentLevel.WaveStarted = Math.Max(this.WaveIndex, TDSession.thisSession.CurrentLevel.WaveStarted);
            }

            // apply any effects
            if (this.Effects != null &&
                this.Effects.Count > 0)
            {
                foreach (TDEffect e in this.Effects)
                {
                    if (e.Effect == TDEffectTypes.WaveDelay)
                    {
                        if (e.State == TDEffect.TDTimerState.Finished)
                        {
                            e.HasBeenApplied = true;
                            this.CanStart = true;
                        }
                        else if (e.State == TDEffect.TDTimerState.Running && e.DurationRemaining.TotalMilliseconds < 0)
                        {
                            e.State = TDEffect.TDTimerState.Finished;
                            return;
                        }
                        else
                        {
                            // if we have not finished this effect, then we can't start yet. (or do anything else).
                            return;
                        }
                    }

                    #region Slow
                    if (e.Effect == TDEffectTypes.Slow)
                    {
                        if (e.State == TDEffect.TDTimerState.Running)
                        {
                            // slow only applies once
                            if (!e.HasBeenApplied)
                            {
                                // change current speed to effect.
                                this.SpeedCurrent = (this.SpeedMax * (100-(double)e.Power) / 100);
                                e.HasBeenApplied = true;
                            }
                        }
                        else if (e.State == TDEffect.TDTimerState.Finished)
                        {
                            // only edit if the effect is still applied
                            if (e.HasBeenApplied)
                            {
                                // set the speed back to normal
                                this.SpeedCurrent = this.SpeedMax;
                                // tell the system we have undid the speed change
                                e.HasBeenApplied = false;
                            }
                        }
                    } // end slow
                #endregion
                }
            }

            // next point
            if (OnPoint(this.Location, this.Path.PathPoints[NextPoint].Location))
            {
                // change destination to the next point on the path.
                NextPoint++;

                // if on last point, then damage lvl HP
                if (NextPoint >= Path.PathPoints.Count)
                {
                    TDSession.thisSession.CurrentLevel.HPRemaining -= this.HPCurrent;
                    this.Cost = 0; // no loot for an enemy crashing into your base!
                    DeleteMe = true;
                    return;
                }
            }

            // move toward point
            MoveToward(this.Path.PathPoints[NextPoint].Location);

            // check cooldown to see if can fire
            if (DateTime.Now > this.LastFire + new TimeSpan(0, 0, 0, 0, (int)(this.Cooldown.TotalMilliseconds / TDSession.SpeedFactor)))
            {
                // we can, so see if any towers in range
                List<TDTower> towersInRange = GetTowersInRange();

                // check towers in range to fire at
                if (towersInRange.Count == 0)
                {
                    // do nothing - no towers
                }
                else
                {
                    // only have a chance to shoot this update (makes the firing more random)
                    if (TDMath.D(100) > 97)
                    {
                        if (towersInRange.Count == 1)
                        {
                            // if one is the destination tower, hit it
                            ShootAtTower(towersInRange[0]);
                        }
                        else if (towersInRange.Count > 1)
                        {
                            // if multiples
                            // future: pick a tower (weakest, strongest, first?)

                            // for now, just shoot the first one
                            ShootAtTower(towersInRange[0]);
                        }

                        LastFire = DateTime.Now;
                    }
                } // end else - are towers in range
            }
        }
        public double DistanceToNextPoint()
        {
            return TDMath.RangeToTarget(this.Location, this.Path.PathPoints[NextPoint].Location);
        }
        #endregion

        #region Private Functions
        private void ShootAtTower(TDTower tower)
        {
            // create a TDAmmo object at this current location, and set it's speed toward target.
            TDAmmo newAmmo = new TDAmmo(this, tower);
            TDSession.thisSession.CurrentLevel.Ammo.Add(newAmmo);
        }
        private void MoveToward(TDLocation tDLocation)
        {
            // get destination
            TDLocation nextLocation = this.Path.PathPoints[NextPoint].Location;

            // get raw change
            double changeX = nextLocation.X - (this.Location.X);
            double changeY = nextLocation.Y - (this.Location.Y);

            // calculate direction angle (rise over run)
            double angle = Math.Atan2(changeY, changeX);

            // get the X part of the speed
            double moveX = Math.Cos(angle) * this.SpeedCurrent;

            // get the Y part of the speed
            double moveY = Math.Sin(angle) * this.SpeedCurrent;

            // do the actual move - adjust the location X and Y by their respect parts
            this.Location.X += moveX * TDSession.SpeedFactor;
            this.Location.Y += moveY * TDSession.SpeedFactor;
        }
        private bool OnPoint(TDLocation L1, TDLocation L2)
        {
            return TDMath.PointOnPoint(L1, L2, (int)Math.Max(1,this.SpeedCurrent * TDSession.SpeedFactor));
        }
        private List<TDTower> GetTowersInRange()
        {
            List<TDTower> results = new List<TDTower>();

            foreach (TDTower tower in TDSession.thisSession.CurrentLevel.Towers)
            {
                if (TowerWithinRange(tower))
                {
                    results.Add(tower);
                }
            }

            return results;
        }
        private bool TowerWithinRange(TDTower tower)
        {
            return TDMath.PointInRange(this.Location, tower.Location, this.Range);
        }
        #endregion

        new public void DrawSelf(Graphics g)
        {
            // don't draw until past first point.
            if (this.NextPoint == 0) { return; }

            base.DrawSelf(g);

            try
            {
                if (this.MainImage != null)
                {
                    g.DrawImage(MainImage, (int)base.Location.X - base.Size / 2, (int)base.Location.Y - base.Size / 2, base.Size, base.Size);
                }
                else
                {
                    // draw base location box
                    g.DrawRectangle(MainPen, (int)base.Location.X - base.Size / 2, (int)base.Location.Y - base.Size / 2, base.Size, base.Size);
                }
            }
            catch { }
        }

        internal int CompareTo(TDAttacker a2)
        {
            if (a2 == null) { return 1; }

            if (this.NextPoint != a2.NextPoint) { return this.NextPoint - a2.NextPoint; }
            else
            {
                if (a2.DistanceToNextPoint() > this.DistanceToNextPoint())
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
            }
        }

        internal int CompareHPTo(TDAttacker a2)
        {
            if (this.HPCurrent < a2.HPCurrent) { return 1; }
            else if (this.HPCurrent > a2.HPCurrent) { return -1; }
            else { return 0; }
        }

        internal void AdjustEffectDurations(double OldSpeedFactor, double NewSpeedFactor)
        {
            // if the same, then don't bother adjusting.
            foreach (TDEffect e in Effects)
            {
                e.AdjustDuration(OldSpeedFactor, NewSpeedFactor);
            }
        }

        internal void ResumeEffects()
        {
            if (Effects.Count > 0)
            {
                foreach (TDEffect e in Effects)
                {
                    e.Resume();
                }
            }
        }

        internal void StartWaveDelayEffects()
        {
            if (Effects.Count > 0)
            {
                foreach (TDEffect e in Effects)
                {
                    if (e.Effect == TDEffectTypes.WaveDelay)
                    {
                        e.Start();
                    }
                }
            }
        }
    }
}
