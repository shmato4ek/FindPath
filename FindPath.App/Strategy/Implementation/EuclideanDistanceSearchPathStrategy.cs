using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using FindPath.App.Strategy.Abstract;

namespace FindPath.App.Strategy.Implementation;

public sealed class EuclideanDistanceSearchPathStrategy: AbstractFindPathStrategy
{
    public override Point[] FindShortestPath(int[,] arr)
    {
        var flag = true; // flag for algorithm evaluation cycle
        
        var endPoint = new Point(arr.GetLength(0) - 1, arr.GetLength(1) - 1); // target point
        var currentPath = new List<Point> { new Point(0, 0) }; // starting path

        while (flag)
        {
            var uniquePathValues = GetUniquePathValues(currentPath.ToArray(), arr); // finding unique values in current paths
            var availablePoints = GetNextMoves(currentPath.Last().X, currentPath.Last().Y, arr); // available points for next move

            var newPoint = availablePoints // choosing next path step
                .Where(p => !currentPath.Contains(p)) // checking if current path does not contain the point
                .Where(p => uniquePathValues.Contains(arr[p.X, p.Y]) || uniquePathValues.Count < 2) // check if the points' values are valid
                .OrderBy(p => GetEuclideanDistanceDistance(p, endPoint)) // order available points by Euclidean distance to the target point
                .FirstOrDefault(); // picking the closest point
            
            if (newPoint == new Point(0, 0) && currentPath.Count != 1) // check if algorithm did not find the path
            {
                throw new Exception("Path could not be found");
            }
            
            currentPath.Add(newPoint); // adding picked point to the current path

            if (currentPath.Last() == endPoint) // check if current path is a solution
            {
                flag = false;
            }
        }
        
        return currentPath.ToArray();
    }
}