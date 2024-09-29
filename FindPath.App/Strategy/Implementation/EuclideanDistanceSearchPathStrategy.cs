using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using FindPath.App.Strategy.Abstract;

namespace FindPath.App.Strategy.Implementation;

public sealed class EuclideanDistanceSearchPathStrategy: AbstractFindPathStrategy, IFindPathStrategy
{
    public Point[] FindShortestPath(int[,] arr)
    {
        var flag = true;
        
        var endPoint = new Point(arr.GetLength(0) - 1, arr.GetLength(1) - 1);
        var currentPath = new List<Point> { new Point(0, 0) };

        while (flag)
        {
            var uniquePathValues = GetUniquePathValues(currentPath.ToArray(), arr);
            var availablePoints = GetNextMoves(currentPath.Last().X, currentPath.Last().Y, arr);

            var newPoint = availablePoints
                .Where(p => !currentPath.Contains(p))
                .Where(p => uniquePathValues.Contains(arr[p.X, p.Y]) || availablePoints.Count < 2)
                .OrderBy(p => GetEuclideanDistanceDistance(p, endPoint))
                .FirstOrDefault();

            if (newPoint == new Point(0, 0) && currentPath.Count != 1)
            {
                return null;
            }
            
            currentPath.Add(newPoint);

            if (currentPath.Last() == endPoint)
            {
                flag = false;
            }
        }
        
        return currentPath.ToArray();
    }
}