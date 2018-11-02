using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace TowerDefense
{
    public class TDAmmo
    {
        private static Pen AmmoPen;

        private TDEntity source;
        private TDEntity target;
        private TDLocation CurrentLocation;
        private int speed;
        private int damage;
        public bool DeleteMe = false;
        public int SplashRadius = 0;
        public int ChainCount = 0;
        public int ChainDist = 50;
        private double moveX;
        private double moveY;
        bool Seeking = false;
        int size;

        public List<TDEffect> Effects;

        public TDAmmo(TDEntity source, TDEntity target)
        {
            this.source = source;
            this.CurrentLocation = new TDLocation(source.Location.X, source.Location.Y);
            this.target = target;
            this.speed = source.BulletSpeed;
            this.damage = source.BulletDamage;
            this.SplashRadius = source.SpashRadius;
            this.Seeking = source.SeekingMissle;
            this.ChainCount = source.ChainHops;
            this.ChainDist = source.ChainDist;
            this.size = 1 + (this.damage / 4);
            CalculateTrajectory();

            // copy any effects (except waveDelay)
            this.Effects = new List<TDEffect>();
            foreach (TDEffect e in source.Effects)
            {
                if (e.Effect == TDEffectTypes.WaveDelay) { continue; }
                else
                {
                    this.Effects.Add(new TDEffect(e.Effect, e.Power, e.Duration, false));
                }
            }

        }

        private void CalculateTrajectory()
        {
            // get raw change
            double changeX = this.target.Location.X - this.CurrentLocation.X;
            double changeY = this.target.Location.Y - this.CurrentLocation.Y;

            // calculate direction angle (rise over run)
            double angle = Math.Atan2(changeY, changeX);

            // get the X part of the speed
            moveX = Math.Cos(angle) * this.speed;

            // get the Y part of the speed
            moveY = Math.Sin(angle) * this.speed;

        }

        public void Update()
        {
            // if on target
            if (this.Seeking &&
                TDMath.PointOnPoint(this.CurrentLocation, target.Location, (int)(this.speed * TDSession.SpeedFactor)))
            {
                HitTarget(target as TDEntity);
            }
            else
            {
                // if on any target type
                if (target is TDAttacker)
                {
                    // hit any target
                    for (int i = 0; i < TDSession.thisSession.CurrentLevel.Attackers.Count; i++)
                    {
                        if (TDSession.thisSession.CurrentLevel.Attackers[i] != this.source &&
                            TDMath.PointOnPoint(this.CurrentLocation, 
                                TDSession.thisSession.CurrentLevel.Attackers[i].Location, 
                                TDSession.thisSession.CurrentLevel.Attackers[i].Size))
                        {
                            HitTarget(TDSession.thisSession.CurrentLevel.Attackers[i] as TDEntity);
                            break;
                        }
                    }
                }
                else // if target is TDTower
                {
                    // hit any tower
                    for (int i = 0; i < TDSession.thisSession.CurrentLevel.Towers.Count; i++)
                    {
                        if (TDMath.PointOnPoint(this.CurrentLocation, 
                                    TDSession.thisSession.CurrentLevel.Towers[i].Location, 
                                    TDSession.thisSession.CurrentLevel.Towers[i].Size))
                        {
                            HitTarget(TDSession.thisSession.CurrentLevel.Towers[i] as TDEntity);
                            break;
                        }
                    }
                }

                // move toward target
                MoveToward(target.Location);
            }
        }

        private void HitTarget(TDEntity entity)
        {
            #region splash
            if (this.SplashRadius > 0)
            {
                DamageRadius(target.Location, this.SplashRadius);

                // spawn a new explosion
                TDSession.thisSession.CurrentLevel.Explosions.Add(new TDExplosion(entity.Location, this.SplashRadius));
            }
            #endregion
            else // not splash
            {
                entity.HPCurrent -= this.damage;

                // apply any effects
                if (this.Effects != null &&
                    this.Effects.Count > 0)
                {
                    foreach(TDEffect e in this.Effects)
                    {
                        entity.Effects.Add(new TDEffect(e.Effect, e.Power, e.Duration, true));
                    }
                }
            }

            #region Chaining
            if (this.ChainCount > 0)
            {
                // find the next closest attacker, not the source
                List<TDEntity> newTargets = GetTowersInRange(entity.Location, this.ChainDist, false, true);

                // don't hit this source.
                if (newTargets.Contains(this.source))
                {
                    newTargets.Remove(this.source);
                }

                // and don't hit this new target itself
                if (newTargets.Contains(entity))
                {
                    newTargets.Remove(entity);
                }

                if (newTargets.Count > 0)
                {
                    // get a random target within this range
                    TDEntity newTarget = newTargets[TDMath.D(newTargets.Count) - 1];

                    // make a new ammo from this one,
                    TDAmmo newAmmo = new TDAmmo(entity, newTarget); // start from this target hit

                    // reduce the chain count
                    newAmmo.ChainDist = this.ChainDist;
                    newAmmo.ChainCount = this.ChainCount - 1;
                    newAmmo.damage = Math.Max(1, this.damage - 1); // override the damage with the chain decline
                    TDSession.thisSession.CurrentLevel.Ammo.Add(newAmmo);
                }
            }
            #endregion

            // since ammo dies automatically
            this.DeleteMe = true;
        }

        private void DamageRadius(TDLocation loc, int Radius)
        {
            List<TDEntity> towersInRange = GetTowersInRange(loc, Radius, false, true);

            for (int i = 0; i < towersInRange.Count; i++)
            {
                towersInRange[i].HPCurrent -= this.damage;
            }
        }

        private List<TDEntity> GetTowersInRange(TDLocation loc, int Radius, bool IncludeTowers, bool IncludeAttackers)
        {
            List<TDEntity> towersInRange = new List<TDEntity>();

            if (IncludeAttackers)
            {
                foreach (TDAttacker a in TDSession.thisSession.CurrentLevel.Attackers)
                {
                    if (TDMath.PointInRange(loc, a.Location, Radius))
                    {
                        towersInRange.Add(a);
                    }
                }
            }
            if(IncludeTowers)
            {
                foreach (TDTower t in TDSession.thisSession.CurrentLevel.Towers)
                {
                    if (TDMath.PointInRange(loc, t.Location, Radius))
                    {
                        towersInRange.Add(t);
                    }
                }
            }

            return towersInRange;
        }

        private void MoveToward(TDLocation Location)
        {
            if (this.Seeking)
            {
                CalculateTrajectory();
            }

            // do the actual move - adjust the location X and Y by their respect parts
            this.CurrentLocation.X += moveX * TDSession.SpeedFactor;
            this.CurrentLocation.Y += moveY * TDSession.SpeedFactor;
        }

        internal void DrawSelf(Graphics g)
        {
            if (AmmoPen == null) { AmmoPen = new Pen(Color.Black, 2); }

            try
            {
                g.DrawEllipse(AmmoPen, (int)this.CurrentLocation.X, (int)this.CurrentLocation.Y, this.size, this.size);
            }
            catch { }

        }
    }
}
