using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefense
{
    public class TDPath
    {
        public List<TDPathPoint> PathPoints;

        public TDPath()
        {
            PathPoints = new List<TDPathPoint>();
        }

        public TDLocation[] GetPoints()
        {
            TDLocation[] points = new TDLocation[PathPoints.Count];

            for (int i = 0; i < PathPoints.Count; i++)
            {
                points[i] = PathPoints[i].Location;
            }

            return points;
        }

        internal Point[] GetPointsFromLocations()
        {
            Point[] points = new Point[PathPoints.Count];

            for (int i = 0; i < PathPoints.Count; i++)
            {
                points[i] = new Point((int)PathPoints[i].Location.X, (int)PathPoints[i].Location.Y);
            }

            return points;
        }
    }
}
