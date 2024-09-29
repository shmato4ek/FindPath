using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using FindPath.App.Strategy.Abstract;
using FindPath.App.Strategy.Helpers;

namespace FindPath.App.Strategy.Implementation;

public class EuclideanDistanceSearchStrategy: ISearchStrategy
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
    
    private List<int> GetInitValues(Point[] points, int[,] arr)
    {
        var allValues = new List<int>();

        foreach (var point in points)
        {
            allValues.Add(arr[point.X, point.Y]);
        }
            
        allValues = allValues.Distinct().ToList();
        return allValues;
    }
    
    public static double GetDistance(Point startPoint, Point finalPoint)
    {
        return Math.Sqrt(Math.Pow(finalPoint.X - startPoint.X, 2) + Math.Pow(finalPoint.Y - startPoint.Y, 2));
    }
    
    public static List<Point> GetNextMoves(int indexX, int indexY, int[,] arr, List<int> initValues) {
        var hasZeroValue = (int x, int y) => arr[indexX, indexY] == 0 || arr[x, y] == 0;
        var areEqual = (int x, int y) => arr[indexX, indexY] == arr[x, y];
        var doesntHaveZeroValues = (int x, int y) => arr[indexX, indexY] != 0 && arr[x, y] != 0;
        var checkInitValues = (int x, int y) => initValues.Count < 2 || (initValues.Contains(arr[indexX, indexY]) && initValues.Contains(arr[x, y]));
            
        var currentValue = arr[indexX, indexY];
        var moveNextRules = new List<Point>();

        //move right
        if (indexY != arr.GetLength(1) - 1 &&
            checkInitValues(indexX, indexY + 1) &&
            (hasZeroValue(indexX, indexY + 1) ||
             areEqual(indexX, indexY + 1)))
        {
            moveNextRules.Add(new Point(indexX, indexY + 1)); 
        }
            
        //move left
        if (indexY != 0 &&
            checkInitValues(indexX, indexY - 1) &&
            (hasZeroValue(indexX, indexY - 1) ||
             areEqual(indexX, indexY - 1)))
        {
            moveNextRules.Add(new Point(indexX, indexY - 1));
        }

        //move down
        if (indexX != arr.GetLength(0) - 1 &&
            checkInitValues(indexX + 1, indexY) &&
            (hasZeroValue(indexX + 1, indexY) ||
             areEqual(indexX + 1, indexY)))
        {
            moveNextRules.Add(new Point(indexX + 1, indexY));
        }

        //move up
        if (indexX != 0 &&
            checkInitValues(indexX - 1, indexY) &&
            (hasZeroValue(indexX - 1, indexY) ||
             areEqual(indexX - 1, indexY)))
        {
            moveNextRules.Add(new Point(indexX - 1, indexY));
        }
            
        //move top left
        if ((indexX != 0 && indexY != 0) &&
            checkInitValues(indexX - 1, indexY - 1) &&
            doesntHaveZeroValues(indexX - 1, indexY - 1) &&
            areEqual(indexX - 1, indexY - 1))
        {
            moveNextRules.Add(new Point(indexX - 1, indexY - 1));
        }
            
        //move top right
        if ((indexX != 0 && indexY != arr.GetLength(1) - 1) &&
            checkInitValues(indexX - 1, indexY + 1) &&
            doesntHaveZeroValues(indexX - 1, indexY + 1) &&
            areEqual(indexX - 1, indexY + 1))
        {
            moveNextRules.Add(new Point(indexX - 1, indexY + 1));
        }
            
        //move bottom left
        if ((indexX != arr.GetLength(0) - 1 && indexY != 0) &&
            checkInitValues(indexX + 1, indexY - 1) &&
            doesntHaveZeroValues(indexX + 1, indexY - 1) &&
            areEqual(indexX + 1, indexY - 1))
        {
            moveNextRules.Add(new Point(indexX + 1, indexY - 1));
        }
            
        //move bottom right
        if ((indexX != arr.GetLength(0) - 1 && indexY != arr.GetLength(1) - 1) &&
            checkInitValues(indexX + 1, indexY + 1) &&
            doesntHaveZeroValues(indexX + 1, indexY + 1) &&
            areEqual(indexX + 1, indexY + 1))
        {
            moveNextRules.Add(new Point(indexX + 1, indexY + 1));
        }
            
        return moveNextRules;
    }
}