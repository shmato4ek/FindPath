using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace FindPath.App.Strategy.Abstract;

public abstract class SearchStrategyBase
{
    private Func<int, int, bool> hasZeroValue = (startValue, endValue) => 
        startValue == 0 || endValue == 0;
    
    private Func<int, int, bool> areEqual = (startValue, endValue) => 
        startValue == endValue;
    
    private Func<int, int, bool> doesntHaveZeroValues = (startValue, endValue) => 
        startValue != 0 && endValue != 0;
    
    
    protected List<Point> GetNextMoves(int indexX, int indexY, int[,] arr, List<int> initValues) 
    {
        var startValue = arr[indexX, indexY];
        var currentValue = arr[indexX, indexY];
        var moveNextRules = new List<Point>();

        //move right
        if (indexY != arr.GetLength(1) - 1 &&
            CanMoveRight(startValue, arr[indexX, indexY + 1]))
        {
            moveNextRules.Add(new Point(indexX, indexY + 1)); 
        }
            
        //move left
        if (indexY != 0 &&
            CanMoveLeft(startValue, arr[indexX, indexY - 1]))
        {
            moveNextRules.Add(new Point(indexX, indexY - 1));
        }

        //move down
        if (indexX != arr.GetLength(0) - 1 &&
            CanMoveDown(startValue, arr[indexX + 1, indexY]))
        {
            moveNextRules.Add(new Point(indexX + 1, indexY));
        }

        //move up
        if (indexX != 0 &&
            CanMoveUp(startValue, arr[indexX - 1, indexY]))
        {
            moveNextRules.Add(new Point(indexX - 1, indexY));
        }
            
        //move top left
        if (indexX != 0 && indexY != 0 &&
            CanMoveTopLeft(startValue, arr[indexX - 1, indexY - 1]))
        {
            moveNextRules.Add(new Point(indexX - 1, indexY - 1));
        }
            
        //move top right
        if (indexX != 0 && indexY != arr.GetLength(1) - 1 &&
            CanMoveTopRight(startValue, arr[indexX - 1, indexY + 1]))
        {
            moveNextRules.Add(new Point(indexX - 1, indexY + 1));
        }
            
        //move bottom left
        if (indexX != arr.GetLength(0) - 1 && indexY != 0 &&
            CanMoveBottomLeft(startValue, arr[indexX + 1, indexY - 1]))
        {
            moveNextRules.Add(new Point(indexX + 1, indexY - 1));
        }
            
        //move bottom right
        if (indexX != arr.GetLength(0) - 1 && indexY != arr.GetLength(1) - 1 &&
            CanMoveBottomRight(startValue, arr[indexX + 1, indexY + 1]))
        {
            moveNextRules.Add(new Point(indexX + 1, indexY + 1));
        }
            
        return moveNextRules;
    }
    
    protected List<int> GetInitValues(Point[] points, int[,] arr)
    {
        var allValues = new List<int>();

        foreach (var point in points)
        {
            allValues.Add(arr[point.X, point.Y]);
        }
            
        allValues = allValues.Distinct().ToList();
        return allValues;
    }
    
    protected double GetDistance(Point startPoint, Point finalPoint)
    {
        return Math.Sqrt(Math.Pow(finalPoint.X - startPoint.X, 2) + Math.Pow(finalPoint.Y - startPoint.Y, 2));
    }
    
    private bool CanMoveRight(int startValue, int endValue)
    {
        return hasZeroValue(startValue, endValue) ||
                areEqual(startValue, endValue);
    }

    private bool CanMoveLeft(int startValue, int endValue)
    {
        return hasZeroValue(startValue, endValue) ||
                areEqual(startValue, endValue);
    }

    private bool CanMoveDown( int startValue, int endValue)
    {
        return hasZeroValue(startValue, endValue) ||
                areEqual(startValue, endValue);
    }

    private bool CanMoveUp(int startValue, int endValue)
    {
        return hasZeroValue(startValue, endValue) ||
                areEqual(startValue, endValue);
    }

    private bool CanMoveTopLeft(int startValue, int endValue)
    {
        return doesntHaveZeroValues(startValue, endValue) ||
                areEqual(startValue, endValue);
    }

    private bool CanMoveTopRight(int startValue, int endValue)
    {
        return doesntHaveZeroValues(startValue, endValue) ||
                areEqual(startValue, endValue);
    }

    private bool CanMoveBottomLeft(int startValue, int endValue)
    {
        return doesntHaveZeroValues(startValue, endValue) ||
                areEqual(startValue, endValue);
    }

    private bool CanMoveBottomRight(int startValue, int endValue)
    {
        return doesntHaveZeroValues(startValue, endValue) ||
                areEqual(startValue, endValue);
    }
}