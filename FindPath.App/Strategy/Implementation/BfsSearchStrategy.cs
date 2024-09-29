using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using FindPath.App.Strategy.Abstract;

namespace FindPath.App.Strategy.Implementation;

public class BfsSearchStrategy: SearchStrategyBase, ISearchStrategy
{
    public Point[] FindShortestPath(int[,] arr)
    {
        var allPaths = new List<Point[]>(); // all current paths
        var flag = true; // flag for algorithm evaluation cycle
        var resultPath = new List<Point>(); // result of bfs algorithm evaluation

        var startingPoint = new Point(0, 0); // starting point
        allPaths.Add(new Point[1] {startingPoint}); // adding starting path
        
        while (flag)
        {
            var newPaths = new List<Point[]>();
            foreach (var path in allPaths)
            {
                var initValues = GetInitValues(path, arr);
                var availablePoints = GetNextMoves(path[^1].X, path[^1].Y, arr, initValues).ToArray();
                availablePoints = availablePoints.Where(p => !path.Contains(p)).ToArray();

                if (availablePoints.Length == 0)
                {
                    return null;
                }
                
                foreach (var newPoint in availablePoints)
                {
                    var newPath = new Point[path.Length + 1];
                    for (int i = 0; i < path.Length; i++)
                    {
                        newPath[i] = path[i];
                    }

                    newPath[^1] = newPoint;

                    newPaths.Add(newPath);
                }
            }

            foreach (var path in newPaths)
            {
                allPaths.Add(path);
            }

            var length = allPaths.OrderBy(p => p.Length).Last().Length;
            allPaths = allPaths.Where(p => p.Length >= length).ToList();
                
            var lastPoint = new Point(arr.GetLength(0) - 1, arr.GetLength(1) - 1);
            
            var pathsCount = Math.Max(arr.GetLength(0), arr.GetLength(1));
            
            allPaths = allPaths.OrderBy(p => GetDistance(p.Last(), lastPoint)).Take(pathsCount).ToList();
                
            foreach (var path in allPaths)
            {
                if (path[^1].X == arr.GetLength(0) - 1 && path[^1].Y == arr.GetLength(1) - 1)
                {
                    resultPath = path.ToList();
                    flag = false;
                }
            }
        }
        
        return resultPath.ToArray();
    }
}