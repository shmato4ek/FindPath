using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using FindPath.App.Strategy.Abstract;
using FindPath.App.Strategy.Helpers;

namespace FindPath.App.Strategy.Implementation;

public class EuclideanDistanceSearchStrategy: SearchStrategyBase, ISearchStrategy
{
    public Point[] FindShortestPath(int[,] arr)
    {
        var currentPath = new List<Point>();
        var flag = true;
            
        var indexX = 0;
        var indexY = 0;

        var Point = new Point(0, 0);
        currentPath.Add(Point);

        while (flag)
        {
            var initValues = GetInitValues(currentPath.ToArray(), arr);
            var availablePoints = GetNextMoves(currentPath.Last().X, currentPath.Last().Y, arr, initValues)
                .ToArray();
            var endPoint = new Point(arr.GetLength(0) - 1, arr.GetLength(1) - 1);

            var newPoint = availablePoints
                .Where(p => !currentPath.Contains(p))
                .OrderBy(p => GetDistance(p, endPoint))
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