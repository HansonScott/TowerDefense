using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TowerDefense
{
    public class TDPathPoint: IComparable
    {
        public TDLocation Location;
        public int Index;

        public TDPathPoint(int PathNodeIndex, int x, int y)
        {
            this.Index = PathNodeIndex;
            this.Location = new TDLocation(x, y);
        }

        public int CompareTo(object other)
        {
            return this.Index - ((TDPathPoint)other).Index;
        }
    }
}
