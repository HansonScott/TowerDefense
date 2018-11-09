using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Timers;

namespace TowerDefense
{
    public abstract class TDEntity
    {
        public bool DrawRange = true;

        public string Name;
        public int HPMax;
        private int _HPCurrent;
        public int HPCurrent
        {
            get{return _HPCurrent;}
            set
            {
                _HPCurrent = value;
                if (_HPCurrent <= 0)
                {
                    DeleteMe = true;
                }

                if (TDForm.ThisForm.CurrentlySelectedEntity == this)
                {
                    TDForm.ThisForm.RefreshDetailsOfSelection();
                }
            }
        }
        public double SpeedMax;
        public double SpeedCurrent;
        public int Range;
        public TimeSpan Cooldown;
        public DateTime LastFire;
        public int BulletDamage;
        public int BulletSpeed = 20;
        public TDLocation Location = new TDLocation(1, 1);
        public bool DeleteMe = false;
        public int Size = 20;
        public int SpashRadius = 0;
        public int ChainHops = 0;
        public int ChainDist = 0;
        public bool IsHighlighted = false;
        private int HPSize;
        public bool SeekingMissle = false;
        public int Cost = 0; // cost of tower, or look for attacker

        public List<TDEffect> Effects = new List<TDEffect>();

        public Color MainColor
        {
            get { return this.MainPen.Color; }
            set
            {
                this.MainPen.Color = value;
            }
        }
        public Pen MainPen = new Pen(new SolidBrush(Color.Black), 2);
        protected Pen HPPen = new Pen(new SolidBrush(Color.Green), 3);
        protected Pen HighlightPen = new Pen(new SolidBrush(Color.Yellow), 1);
        
        public abstract void Update();

        public void DrawSelf(Graphics g)
        {
            try
            {
                if (this.IsHighlighted)
                {
                //    g.DrawEllipse(HighlightPen, (int)Location.X - Size, (int)Location.Y - Size, Size * 2, Size * 2);
                //}

                //if (DrawRange)
                //{
                    g.DrawEllipse(HighlightPen, (int)Location.X - Range, (int)Location.Y - Range, (Range * 2), (Range * 2));
                }

                // draw HP
                if (this.HPCurrent != this.HPMax)
                {
                    HPPen.Color = GetColorForCurrentHP(this.HPCurrent, this.HPMax);
                    HPSize = GetLineSizeForCurrentHP(this.HPCurrent, this.HPMax, this.Size);

                    if (HPSize > 0)
                    {
                        g.DrawLine(HPPen,
                            (int)Location.X - (HPSize / 2),
                            (int)Location.Y - (Size / 2) - HPPen.Width,  // just above location
                            (int)Location.X + (HPSize / 2),
                            (int)Location.Y - (Size / 2) - HPPen.Width);  // just above location
                    }
                }
            }
            catch{}
        }

        private int GetLineSizeForCurrentHP(int HPCurrent, int HPMax, int Size)
        {
            return (Size * HPCurrent / HPMax);
        }
        protected Color GetColorForCurrentHP(int HPCurrent, int HPMax)
        {
            int percent = (HPCurrent * 100 / HPMax);

            if (percent > 100)
            {
                return Color.Blue;
            }
            else if (percent > 75)
            {
                return Color.Green;
            }
            else if (percent > 50)
            {
                return Color.Yellow;
            }
            else if (percent > 25)
            {
                return Color.Orange;
            }
            else
            {
                return Color.Red;
            }
        }


        internal int RepairCost()
        {
            return this.Cost * (this.HPCurrent * 100 / this.HPMax) / 2 / 100;
        }
    }
}
