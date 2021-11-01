using System;
using System.Collections.Generic;
using System.Linq;

namespace ClosestPairOfPoints
{
    class StartUp
    {
        static void Main()
        {
            var rnd = new Random();
            var points = Enumerable.Range(0, 10)
                .Select(x => Point.GenPoint(rnd))
                .ToArray();
            {
                var tuple = FindClosestPairNaive(points);
                var distance = points[tuple.Item1].DistanceTo(points[tuple.Item2]);
                Console.WriteLine($"{tuple.Item1} {tuple.Item2} {distance}");
            }

            {
                var tuple = FindClosestPairDevideConquer(points);
                var distance = points[tuple.Item1].DistanceTo(points[tuple.Item2]);
                Console.WriteLine($"{tuple.Item1} {tuple.Item2} {distance}");
            }
        }
        static Tuple<int, int> FindClosestPairNaive(Point[] points)
        {
            var best1 = 0;
            var best2 = 1;
            var bestDistance = points[0].DistanceToSquared(points[1]);

            for (int i = 0; i < points.Length; i++)
            {
                for (int j = i + 1; j < points.Length; j++) //j != i
                {                  
                    var currentDistance = points[i].DistanceToSquared(points[j]);
                    if (bestDistance > currentDistance)
                    {
                        bestDistance = currentDistance;
                        best1 = i;
                        best2 = j;
                    }
                }
            }
            return new Tuple<int, int>(best1, best2);
        }

        static Tuple<int, int> FindClosestPairDevideConquer(Point[] points)
        {
            Array.Sort(points, Point.XComparer);
            return FindClosestPairDevideConquer(points, 0, points.Length); // [closed from the left; open from the right) Interval
        }

        static Tuple<int, int> FindClosestPairDevideConquer(Point[] points, int beginn, int end)
        {
            //Bottom of the Recursion
            if (end - beginn == 2)
            {
                return new Tuple<int, int>(beginn, beginn = 1);
            }

            if (end - beginn < 2)
            {
                return null;
            }

            var middle = (beginn + end) / 2;
            var leftResult = FindClosestPairDevideConquer(points, beginn, middle);
            var rightResult = FindClosestPairDevideConquer(points, middle, end);
                       
            var leftDistance = leftResult == null ? 1e15 : points[leftResult.Item1].DistanceTo(points[leftResult.Item2]);
            var rightDistance = rightResult == null ? 1e15 : points[rightResult.Item1].DistanceTo(points[rightResult.Item2]);

            var bestDistance = leftDistance < rightDistance ? leftDistance : rightDistance;
            
            var bestPair = leftDistance < rightDistance ? leftResult : rightResult;

            var borderMiddle = points[middle].X;
            var borderLeft = borderMiddle - bestDistance;
            var borderRight = borderMiddle + bestDistance;

            //Binary Search
            var borderLeftIndex = FindPointX(points, beginn, middle, borderLeft);
            var borderRighttIndex = FindPointX(points, middle, end, borderRight);

            for (int i = borderLeftIndex; i < middle; i++)
            {
                for (int j = middle; j < borderRighttIndex; j++)
                {
                    var currentDistance = points[i].DistanceTo(points[j]);
                    if (bestDistance > currentDistance)
                    {
                        bestDistance = currentDistance;
                        bestPair = new Tuple<int, int>(i, j);
                    }
                }
            }

            return bestPair;
        }

        //Binary Search
        static int FindPointX(Point[] points,int left, int right, double x)
        {
            while (left < right)
            {
                int middle = (left + right) / 2;
                if (points[middle].X < x)
                {
                    left = middle + 1;
                }
                else
                {
                    right = middle;
                }
            }

            return left;
        }

    }
}
