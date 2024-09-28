using System.Drawing;
using FindPath.App.Strategy.Abstract;

namespace FindPath.App.Strategy;

public class SearchContext
{
    private ISearchStrategy _searchStrategy;

    public void SetStrategy(ISearchStrategy searchStrategy)
    {
        _searchStrategy = searchStrategy;
    }

    public Point[] Search(int[,] arr)
    {
        return _searchStrategy.FindShortestPath(arr);
    }
}