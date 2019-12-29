using System;
using System.Collections.Generic;
using System.Text;

namespace linearRegression
{
    class Trendline
    {
        public float M { get; private set; }
        public float B { get; private set; }

        float sumY = 0;
        float sumX = 0;
        float sumXPow2 = 0;
        float sumXY = 0;
        int n = 0;

        public Trendline(List<Point> Points)
        {
            CalculateValues(Points);
            M = CalculateM();
            B = CalculateB();
        }

        void CalculateValues(List<Point> points)
        {
            foreach (var point in points)
            {
                sumY += point.Y;
                sumX += point.X;
                sumXPow2 += point.X * point.X;
                sumXY += point.X * point.Y;
            }

            n = points.Count;
        }

        float CalculateB()
        {
            return (sumY * sumXPow2 - sumX * sumXY) / (n * sumXPow2 - sumX * sumX);
        }

        float CalculateM()
        {
            return ((n * sumXY) - (sumX * sumY)) / ((n * (sumXPow2)) - (sumX * sumX));
        }
    }
}
