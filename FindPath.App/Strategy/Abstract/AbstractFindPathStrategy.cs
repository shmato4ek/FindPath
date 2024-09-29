using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace FindPath.App.Strategy.Abstract;

public abstract class AbstractFindPathStrategy
{
    private Func<int, int, bool> hasZero = (startValue, endValue) => 
        startValue == 0 || endValue == 0;
    
    private Func<int, int, bool> areEqual = (startValue, endValue) => 
        startValue == endValue;
    
    private Func<int, int, bool> valuesNotZero = (startValue, endValue) => 
        startValue != 0 && endValue != 0;
    
    
    protected List<Point> GetNextMoves(int indexX, int indexY, int[,] arr) 
    {
        var startValue = arr[indexX, indexY];
        var availablePoints = new List<Point>();

        //move right
        if (indexY != arr.GetLength(1) - 1 &&
            CanMoveRight(startValue, arr[indexX, indexY + 1]))
        {
            availablePoints.Add(new Point(indexX, indexY + 1)); 
        }
            
        //move left
        if (indexY != 0 &&
            CanMoveLeft(startValue, arr[indexX, indexY - 1]))
        {
            availablePoints.Add(new Point(indexX, indexY - 1));
        }

        //move down
        if (indexX != arr.GetLength(0) - 1 &&
            CanMoveDown(startValue, arr[indexX + 1, indexY]))
        {
            availablePoints.Add(new Point(indexX + 1, indexY));
        }

        //move up
        if (indexX != 0 &&
            CanMoveUp(startValue, arr[indexX - 1, indexY]))
        {
            availablePoints.Add(new Point(indexX - 1, indexY));
        }
            
        //move top left
        if (indexX != 0 && indexY != 0 &&
            CanMoveTopLeft(startValue, arr[indexX - 1, indexY - 1]))
        {
            availablePoints.Add(new Point(indexX - 1, indexY - 1));
        }
            
        //move top right
        if (indexX != 0 && indexY != arr.GetLength(1) - 1 &&
            CanMoveTopRight(startValue, arr[indexX - 1, indexY + 1]))
        {
            availablePoints.Add(new Point(indexX - 1, indexY + 1));
        }
            
        //move bottom left
        if (indexX != arr.GetLength(0) - 1 && indexY != 0 &&
            CanMoveBottomLeft(startValue, arr[indexX + 1, indexY - 1]))
        {
            availablePoints.Add(new Point(indexX + 1, indexY - 1));
        }
            
        //move bottom right
        if (indexX != arr.GetLength(0) - 1 && indexY != arr.GetLength(1) - 1 &&
            CanMoveBottomRight(startValue, arr[indexX + 1, indexY + 1]))
        {
            availablePoints.Add(new Point(indexX + 1, indexY + 1));
        }
            
        return availablePoints;
    }
    
    protected List<int> GetUniquePathValues(Point[] pathPoints, int[,] arr)
    {
        var allPathValues = pathPoints.Select(point => arr[point.X, point.Y]).ToList();

        return allPathValues.Distinct().ToList();
    }
    
    protected double GetEuclideanDistanceDistance(Point startPoint, Point finalPoint)
    {
        return Math.Sqrt(Math.Pow(finalPoint.X - startPoint.X, 2) + Math.Pow(finalPoint.Y - startPoint.Y, 2));
    }
    
    private bool CanMoveRight(int startValue, int endValue)
    {
        return hasZero(startValue, endValue) ||
                areEqual(startValue, endValue);
    }

    private bool CanMoveLeft(int startValue, int endValue)
    {
        return hasZero(startValue, endValue) ||
                areEqual(startValue, endValue);
    }

    private bool CanMoveDown( int startValue, int endValue)
    {
        return hasZero(startValue, endValue) ||
                areEqual(startValue, endValue);
    }

    private bool CanMoveUp(int startValue, int endValue)
    {
        return hasZero(startValue, endValue) ||
                areEqual(startValue, endValue);
    }

    private bool CanMoveTopLeft(int startValue, int endValue)
    {
        return valuesNotZero(startValue, endValue);
    }

    private bool CanMoveTopRight(int startValue, int endValue)
    {
        return valuesNotZero(startValue, endValue);
    }

    private bool CanMoveBottomLeft(int startValue, int endValue)
    {
        return valuesNotZero(startValue, endValue);
    }

    private bool CanMoveBottomRight(int startValue, int endValue)
    {
        return valuesNotZero(startValue, endValue);
    }
}