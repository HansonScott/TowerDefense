using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefense
{
    public class TDTower: TDEntity
    {
        private AISettings _AISetting = AISettings.First;
        public AISettings AISetting
        {
            get { return _AISetting; }
            set
            {
                _AISetting = value;
                // if this is the selected tower, then show the new AI setting in the detail section
                if (this == TDForm.ThisForm.CurrentlySelectedEntity)
                {
                    TDForm.ThisForm.RefreshDetailsOfSelection();
                }
            }
        }
        public enum AISettings
        {
            First,
            Last,
            Strong,
            Weak,
            Close,
            Far,
        }

        public TDTower(TDTower sourceTemplate, Point newLocation)
        {
            base.MainColor = Color.Blue;

            this.BulletDamage = sourceTemplate.BulletDamage;
            this.BulletSpeed = sourceTemplate.BulletSpeed;
            this.Cooldown = sourceTemplate.Cooldown;
            this.HPMax = sourceTemplate.HPMax;
            this.HPCurrent = this.HPMax;
            this.Location = new TDLocation(newLocation.X, newLocation.Y);
            this.Name = sourceTemplate.Name;
            this.Range = sourceTemplate.Range;
            this.Size = sourceTemplate.Size;
            this.SpashRadius = sourceTemplate.SpashRadius;
            this.SeekingMissle = sourceTemplate.SeekingMissle;
            this.ChainHops = sourceTemplate.ChainHops;
            this.ChainDist = sourceTemplate.ChainDist;
            this.Cost = sourceTemplate.Cost;

            if (sourceTemplate.Effects != null &&
                sourceTemplate.Effects.Count > 0)
            {
                foreach (TDEffect e in sourceTemplate.Effects)
                {
                    this.Effects.Add(new TDEffect(e.Effect, e.Power, e.Duration, false));
                }
            }
        }
        public TDTower()
        {
            base.MainColor = Color.Blue;
        }

        public override void Update()
        {
            // check cooldown to see if can fire
            if (DateTime.Now > this.LastFire + new TimeSpan(0,0,0,0, (int)(this.Cooldown.TotalMilliseconds / TDSession.SpeedFactor)))
            {
                List<TDAttacker> attackersInRange = GetAttackersInRange();

                // check towers in range to fire at
                if (attackersInRange.Count == 0)
                {
                    // do nothing - no towers
                }
                else
                {
                    if (attackersInRange.Count == 1)
                    {
                        // if one is the destination tower, hit it
                        ShootAtAttacker(attackersInRange[0]);
                    }
                    else if (attackersInRange.Count > 1)
                    {
                        // if multiples
                        // future: pick a tower (weakest, strongest, first?)
                        TDAttacker a = attackersInRange[0];

                        switch (this.AISetting)
                        {
                            case AISettings.First:
                                // sort list by who is closest to the end
                                a = GetFirstAttacker(attackersInRange);
                                break;
                            case AISettings.Last:
                                // sort list by who is closest to the start
                                a = GetLastAttacker(attackersInRange);
                                break;
                            case AISettings.Strong:
                                // sort by current HP - get strongest
                                a = GetStrongAttacker(attackersInRange);
                                break;
                            case AISettings.Weak:
                                // sort by current HP - get weakest
                                a = GetWeakAttacker(attackersInRange);
                                break;
                            case AISettings.Close:
                                // sort by current HP - get weakest
                                a = GetCloseAttacker(attackersInRange);
                                break;
                            case AISettings.Far:
                                // sort by current HP - get weakest
                                a = GetFarAttacker(attackersInRange);
                                break;
                        }

                        ShootAtAttacker(a);
                    }

                    LastFire = DateTime.Now;

                } // end else - there are attackers in range
            } // end if met cooldown
        }

        private TDAttacker GetCloseAttacker(List<TDAttacker> atts)
        {
            TDAttacker result = atts[0];
            double closestRange = 0;
            double rangeToThis = 0;
            foreach (TDAttacker a in atts)
            {
                rangeToThis = TDMath.RangeToTarget(this.Location, a.Location);
                if (closestRange == 0 ||
                    rangeToThis < closestRange)
                {
                    closestRange = rangeToThis;
                    result = a;
                }
            }

            return result;
        }
        private TDAttacker GetFarAttacker(List<TDAttacker> atts)
        {
            TDAttacker result = atts[0];
            double farthestRange = 0;
            double rangeToThis = 0;
            foreach (TDAttacker a in atts)
            {
                rangeToThis = TDMath.RangeToTarget(this.Location, a.Location);
                if (rangeToThis > farthestRange)
                {
                    farthestRange = rangeToThis;
                    result = a;
                }
            }

            return result;
        }
        private TDAttacker GetFirstAttacker(List<TDAttacker> atts)
        {
            TDAttacker result = atts[0];
            atts = SortAttackersByPath(atts);
            result = atts[atts.Count - 1];
            return result;
        }
        private TDAttacker GetLastAttacker(List<TDAttacker> atts)
        {
            TDAttacker result = atts[0];
            atts = SortAttackersByPath(atts);
            result = atts[0];
            return result;
        }
        private TDAttacker GetStrongAttacker(List<TDAttacker> atts)
        {
            TDAttacker result = atts[0];
            atts = SortAttackersByHP(atts);
            result = atts[0];
            return result;
        }
        private TDAttacker GetWeakAttacker(List<TDAttacker> atts)
        {
            TDAttacker result = atts[0];
            atts = SortAttackersByHP(atts);
            result = atts[atts.Count - 1];
            return result;
        }

        private void ShootAtAttacker(TDAttacker Attacker)
        {
            // create a TDAmmo object at this current location, and set it's speed toward target.
            TDAmmo newAmmo = new TDAmmo(this, Attacker);
            TDSession.thisSession.CurrentLevel.Ammo.Add(newAmmo);
        }

        private List<TDAttacker> GetAttackersInRange()
        {
            List<TDAttacker> results = new List<TDAttacker>();

            foreach (TDAttacker a in TDSession.thisSession.CurrentLevel.Attackers)
            {
                if(!a.Immune &&
                    AttackerrWithinRange(a))
                {
                    results.Add(a);
                }
            }

            return results;
        }
        private bool AttackerrWithinRange(TDAttacker a)
        {
            return TDMath.PointInRange(this.Location, a.Location, this.Range);
        }
        private List<TDAttacker> SortAttackersByPath(List<TDAttacker> atts)
        {
            try
            {
                atts.Sort(delegate(TDAttacker a1, TDAttacker a2)
                {
                    if (a1 != null && !a1.Immune)
                    {
                        return a1.CompareTo(a2);
                    }
                    else
                    {
                        return 0;
                    }
                });
            }
            catch { } // this crashes sometimes when the numbers are crazy, just skip the sort.

            return atts;
        }
        private List<TDAttacker> SortAttackersByHP(List<TDAttacker> atts)
        {
            atts.Sort(delegate(TDAttacker a1, TDAttacker a2) { return a1.CompareHPTo(a2); });
            return atts;
        }

        new public void DrawSelf(Graphics g)
        {
            base.DrawSelf(g);

            try
            {
                // draw bounds
                g.DrawRectangle(this.MainPen, (int)base.Location.X - base.Size / 2, (int)base.Location.Y - base.Size / 2, base.Size, base.Size);
            }
            catch { }

        }

        internal void DrawSelf(Graphics graphics, Point point)
        {
            base.Location.X = point.X;
            base.Location.Y = point.Y;
            this.DrawSelf(graphics);
        }
    }
}
