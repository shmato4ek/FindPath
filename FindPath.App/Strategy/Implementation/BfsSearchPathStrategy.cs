using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using FindPath.App.Strategy.Abstract;

namespace FindPath.App.Strategy.Implementation;

public sealed class BfsSearchPathStrategy: AbstractFindPathStrategy, IFindPathStrategy
{
    public Point[] FindShortestPath(int[,] arr)
    {
        var allPaths = new List<Point[]>(); // all current paths
        var flag = true; // flag for algorithm evaluation cycle
        var resultPath = new List<Point>(); // result of bfs algorithm evaluation
        var lastPoint = new Point(arr.GetLength(0) - 1, arr.GetLength(1) - 1);

        var startPoint = new Point(0, 0); // starting point
        allPaths.Add(new Point[1] {startPoint}); // adding starting path
        
        while (flag)
        {
            var newPaths = new List<Point[]>();
            foreach (var path in allPaths)
            {
                var uniquePathValues = GetUniquePathValues(path, arr);
                var availablePoints = GetNextMoves(path[^1].X, path[^1].Y, arr)
                    .Where(p => !path.Contains(p))
                    .Where(p => uniquePathValues.Count < 2 || (uniquePathValues.Contains(arr[p.X, p.Y])))
                    .ToArray();

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

            var maxPathLength = allPaths.OrderBy(p => p.Length).Last().Length;
            
            allPaths = allPaths.Where(p => p.Length == maxPathLength).ToList();
            
            var filteredPathCount = Math.Max(arr.GetLength(0), arr.GetLength(1));
            
            allPaths = allPaths.OrderBy(p => GetEuclideanDistanceDistance(p.Last(), lastPoint)).Take(filteredPathCount).ToList();
                
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