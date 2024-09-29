using System.Drawing;
using FindPath.App.Strategy.Abstract;

namespace FindPath.App.Strategy;

public class SearchContext
{
    private readonly ISearchStrategy _searchStrategy;

    public SearchContext(ISearchStrategy searchStrategy)
    {
        _searchStrategy = searchStrategy;
    }

    public Point[] Search(int[,] arr)
    {
        if (arr.Length == 0 || arr == null)
        {
            return null;
        }
        
        return _searchStrategy.FindShortestPath(arr);
    }
}