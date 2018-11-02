using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefense
{
    public class TDMath
    {
        private static Random r;
        public static int D(int x)
        {
            if (r == null) { r = new Random(); }

            return (r.Next(x) + 1);
        }

        public static T1 GetRandomEnum<T1>()
        {
            string[] names = Enum.GetNames(typeof(T1));
            int resultIndex = D(names.Length);
            return (T1)Enum.Parse(typeof(T1), names[resultIndex - 1]);
        }

        public static bool PointOnPoint(TDLocation L1, TDLocation L2, int margin)
        {
            return ((Math.Abs(L2.X - L1.X) < margin) &&
                    (Math.Abs(L2.Y - L1.Y) < margin));
        }

        public static bool PointInRange(TDLocation center, TDLocation target, int range)
        {
            return RangeToTarget(center, target) <= range + (TDMap.GridSize / 2);
        }
        public static double RangeToTarget(TDLocation center, TDLocation target)
        {
            double changeX = target.X - center.X;
            double changeY = target.Y - center.Y;

            // c^2 = a^2 + b^2
            double dist = Math.Sqrt((changeX * changeX + changeY * changeY));

            return dist;
        }

        internal static bool Intersects(TDLocation loc1, int size1, TDLocation loc2, int size2)
        {
            bool result = false;

            bool Xdoes = loc1.X < loc2.X + size2 && loc1.X + size1 > loc2.X;
            bool Ydoes = loc1.Y < loc2.Y + size2 && loc1.Y + size1 > loc2.Y;

            result = Xdoes && Ydoes;
            return result;
        }

        /// <summary>
        /// Does the target interect the line between point A and point B.
        /// </summary>
        /// <param name="target"></param>
        /// <param name="pointA"></param>
        /// <param name="pointB"></param>
        /// <returns></returns>
        internal static bool Intersects(TDTower target, TDPathPoint pointA, TDPathPoint pointB)
        {
            bool result = false;

            // adjust PathPoints by GridSize
            double aX = pointA.Location.X;
            double aY = pointA.Location.Y;
            double bX = pointB.Location.X;
            double bY = pointB.Location.Y;

            bool intersectXAxis = false;
            bool intersectYAxis = false;

            if (aX < bX)
            {
                intersectXAxis = target.Location.X < bX + (TDMap.GridSize - 2) && target.Location.X + (TDMap.GridSize - 2) > aX;
            }
            else
            {
                intersectXAxis = target.Location.X < aX + (TDMap.GridSize - 2) && target.Location.X + (TDMap.GridSize - 2) > bX;
            }

            // y between
            if (aY < bY)
            {
                intersectYAxis = target.Location.Y < bY + (TDMap.GridSize - 2) && target.Location.Y + (TDMap.GridSize - 2) > aY;
            }
            else
            {
                intersectYAxis = target.Location.Y < aY + (TDMap.GridSize - 2) && target.Location.Y + (TDMap.GridSize - 2) > bY;
            }

            // if it intersects the rectangle of the two
            result = intersectXAxis && intersectYAxis;
            
            // if it is within the square box, and is a diagonal line, check it additionally because it might not be on the actual path.
            if (result &&
                aX != bX && aY != bY) // neither a horizontal or vertical line
            {
                // use graphing formulas y=Mx+b to see if the location is on the line (or within range of the line).
                // y = (Mx + b)
                // y = ((^Y / ^X) * x + b)
                // target.y = ((changeY / changeX)* target.x + b)
                // target.y = (((bY-aY) / (bX-aX))* target.x + b))
                double slope = (bY - aY) / (bX - aX);
                // to find b, use b = y - mx, and we put in one of the points
                double b = aY - (slope * aX);
                double estimatedY = slope * target.Location.X  + b;
                // actual Y needs to be 'close' to the estimated Y of the line
                result = (Math.Abs(target.Location.Y - estimatedY) < (TDMap.GridSize - 1));
            }

            return result;
        }
    }
}
