using System;

namespace DistanceTask
{
    public static class DistanceTask
    {
        // Расстояние от точки (x, y) до отрезка AB с координатами A(ax, ay), B(bx, by)
        public static double GetDistanceToSegment(double ax, double ay, double bx, double by, double x, double y)
        {
            double coefK1 = (by - ay) / (bx - ax);
            double coefK2 = -1 / coefK1;
            double coefB = y - coefK2 * x;
            double xIntersection = (ay - coefK1 * ax - coefB) / (coefK2 - coefK1);
            double yIntersection = coefK2 * xIntersection + coefB;
            if ((by - ay) == 0)
            {
                xIntersection = x;
                yIntersection = ay;
                if ((xIntersection >= ax && xIntersection <= bx) || (xIntersection <= ax && xIntersection >= bx))
                {
                    return Math.Abs(yIntersection - y);
                }
                else return Math.Min(Math.Pow(((ax - x) * (ax - x) + (ay - y) * (ay - y)), 0.5), Math.Pow(((bx - x) * (bx - x) + (by - y) * (by - y)), 0.5));

            }

            else if ((bx - ax) == 0)
            {
                xIntersection = ax;
                yIntersection = y;
                if ((yIntersection >= ay && yIntersection <= by) || (yIntersection <= ay && yIntersection >= by))
                {
                    return Math.Abs(xIntersection - x);
                }
                else return Math.Min(Math.Pow(((ax - x) * (ax - x) + (ay - y) * (ay - y)), 0.5), Math.Pow(((bx - x) * (bx - x) + (by - y) * (by - y)), 0.5));

            }
            else if ((y == coefK1 * x + ay - coefK1 * ax) && ((x >= ax && x <= bx) || (x <= ax && x >= bx)))
            {
                return 0;
            }
            else if ((xIntersection >= ax && xIntersection <= bx) || (xIntersection <= ax && xIntersection >= bx))
            {
                return Math.Pow((xIntersection - x) * (xIntersection - x) + (yIntersection - y) * (yIntersection - y), 0.5);
            }
            else return Math.Min(Math.Pow(((ax - x) * (ax - x) + (ay - y) * (ay - y)), 0.5), Math.Pow(((bx - x) * (bx - x) + (by - y) * (by - y)), 0.5));

        }
    }
}
