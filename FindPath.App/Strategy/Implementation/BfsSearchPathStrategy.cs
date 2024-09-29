using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using FindPath.App.Strategy.Abstract;

namespace FindPath.App.Strategy.Implementation;

public sealed class BfsSearchPathStrategy: AbstractFindPathStrategy
{
    public override Point[] FindShortestPath(int[,] arr)
    {
        var allPaths = new List<Point[]>(); // all current paths
        var flag = true; // flag for algorithm evaluation cycle
        var resultPath = new List<Point>(); // result of bfs algorithm evaluation
        var lastPoint = new Point(arr.GetLength(0) - 1, arr.GetLength(1) - 1); // target point

        var startPoint = new Point(0, 0); // starting point
        allPaths.Add(new Point[1] {startPoint}); // adding initial path
        
        while (flag)
        {
            var newPaths = new List<Point[]>(); // new paths in current iteration
            foreach (var path in allPaths)
            {
                var uniquePathValues = GetUniquePathValues(path, arr); // finding unique values in current paths
                var availablePoints = GetNextMoves(path[^1].X, path[^1].Y, arr) // available points for next move
                    .Where(p => !path.Contains(p)) // checking if current path does not contain the point
                    .Where(p => uniquePathValues.Count < 2 || (uniquePathValues.Contains(arr[p.X, p.Y]))) // check if the points' values are valid
                    .ToArray();

                if (availablePoints.Length == 0) // check if algorithm did not find the path
                {
                    throw new Exception("Path could not be found");
                }
                
                foreach (var newPoint in availablePoints) // creating new paths with available points
                {
                    var newPath = new Point[path.Length + 1]; 
                    
                    for (var i = 0; i < path.Length; i++)
                    {
                        newPath[i] = path[i];
                    }

                    newPath[^1] = newPoint;

                    newPaths.Add(newPath);
                }
            }

            foreach (var path in newPaths) // adding new paths, founded in current iteration, to all paths
            {
                allPaths.Add(path);
            }

            var maxPathLength = allPaths.OrderBy(p => p.Length).Last().Length; // retrieving length of the longest path
            
            allPaths = allPaths.Where(p => p.Length == maxPathLength).ToList(); // removing old paths
            
            var filteredPathCount = Math.Max(arr.GetLength(0), arr.GetLength(1)); // amount of paths that will be taken to the next iteration
            
            allPaths = allPaths.OrderBy(p => GetEuclideanDistanceDistance(p.Last(), lastPoint))
                .Take(filteredPathCount)
                .ToList(); // filtering out not suitable paths determined by Euclidean distance to the target point
                
            foreach (var path in allPaths) // check if all paths contain solution
            {
                if (path[^1].X == arr.GetLength(0) - 1 && path[^1].Y == arr.GetLength(1) - 1)
                {
                    resultPath = path.ToList();
                    flag = false; // breaking the loop if solution was found
                }
            }
        }
        
        return resultPath.ToArray();
    }
}