using System.Drawing;

namespace FindPath.App.Strategy.Abstract;

public interface ISearchStrategy
{
    Point[] FindShortestPath(int[,] arr);
}