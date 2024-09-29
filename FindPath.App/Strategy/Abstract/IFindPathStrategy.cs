using System.Drawing;

namespace FindPath.App.Strategy.Abstract;

public interface IFindPathStrategy
{
    Point[] FindShortestPath(int[,] arr);
}