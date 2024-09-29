using System.Drawing;

namespace FindPath.App.Strategy.Abstract;

public interface IFindPathStrategy // interface for search strategies
{
    Point[] FindShortestPath(int[,] arr);
}