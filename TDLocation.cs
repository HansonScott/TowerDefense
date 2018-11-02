using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefense
{
    public class TDLocation
    {
        public const int LocationBlockSize = 20;

        public double X;
        public double Y;

        public TDLocation(double X, double Y)
        {
            this.X = X;
            this.Y = Y;
        }
    }
}
