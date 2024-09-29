using System;
using System.Drawing;
using FindPath.App.Strategy.Abstract;

namespace FindPath.App.Strategy;

public class FindPathContext
{
    private readonly IFindPathStrategy _findPathStrategy;

    public FindPathContext(IFindPathStrategy findPathStrategy)
    {
        _findPathStrategy = findPathStrategy; // setting search strategy
    }

    public Point[] FindPath(int[,] arr)
    {
        if (arr.Length == 0) // input validation
        {
            throw new Exception("Array must not be empty");
        }
        
        return _findPathStrategy.FindShortestPath(arr); // running search strategy
    }
}