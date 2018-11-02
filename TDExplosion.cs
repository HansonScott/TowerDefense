using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace TowerDefense
{
    public class TDExplosion
    {
        public bool DeleteMe = false;
        public TDLocation Location;
        public int Radius;
        DateTime Spawn;
        TimeSpan Duration = new TimeSpan(0,0,0,0,200);

        Pen ExplosionPen = new Pen(new SolidBrush(Color.Yellow), 3);

        public TDExplosion(TDLocation loc, int radius)
        {
            this.Location = new TDLocation(loc.X, loc.Y);
            this.Radius = radius;
            this.Spawn = DateTime.Now;
        }

        public void Update()
        {
            if (DateTime.Now > Spawn + Duration)
            {
                DeleteMe = true;
            }
        }

        public void DrawSelf(Graphics g)
        {
            g.DrawEllipse(ExplosionPen, (int)(Location.X - Radius/2), (int)(Location.Y - Radius/2), Radius, Radius);
        }
    }
}
