using System.Drawing;
using FindPath.App.Strategy.Abstract;

namespace FindPath.App.Strategy;

public class FindPathContext
{
    private readonly IFindPathStrategy _findPathStrategy;

    public FindPathContext(IFindPathStrategy findPathStrategy)
    {
        _findPathStrategy = findPathStrategy;
    }

    public Point[] FindPath(int[,] arr)
    {
        if (arr.Length == 0)
        {
            return null;
        }
        
        return _findPathStrategy.FindShortestPath(arr);
    }
}