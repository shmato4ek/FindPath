using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace FindPath.App
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[,] testArr = new int [10, 10]
            {
                { 0, 0, 1, 0, 0, 0, 0, 0, 1, 1 },
                { 0, 1, 1, 0, 1, 1, 1, 0, 0, 0 },
                { 1, 0, 0, 1, 0, 0, 1, 0, 0, 1 },
                { 1, 1, 0, 0, 0, 1, 1, 0, 1, 0 },
                { 1, 1, 0, 0, 0, 1, 0, 0, 1, 0 },
                { 0, 0, 0, 0, 1, 0, 0, 1, 0, 0 },
                { 1, 1, 1, 0, 0, 0, 0, 1, 0, 0 },
                { 0, 0, 0, 0, 0, 1, 0, 0, 1, 0 },
                { 0, 0, 0, 0, 0, 0, 1, 0, 0, 0},
                { 0, 1, 1, 0, 0, 0, 1, 0, 1, 0}
            };
                
            int[,] arr = new int[25, 25]
            {
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 4, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 4, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 4, 4, 0},
                {0, 0, 0, 0, 0, 0, 0, 6, 6, 0, 0, 0, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 4, 4, 0},
                {0, 0, 0, 0, 0, 0, 0, 6, 6, 0, 0, 0, 4, 4, 0, 0, 0, 5, 5, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 6, 6, 0, 0, 0, 4, 4, 0, 0, 0, 5, 5, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 4, 0, 0, 0, 5, 5, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 4, 4, 0, 0, 0, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 4, 4, 4, 4, 4, 4, 4, 0, 0, 0, 7, 7, 0, 0, 0, 0, 5, 5, 0, 0, 0, 0, 0},
                {0, 0, 4, 4, 4, 4, 4, 4, 4, 0, 0, 0, 7, 7, 0, 0, 0, 0, 5, 5, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 7, 7, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 4, 4, 4, 4, 4, 0, 0, 0},
                {4, 4, 4, 4, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 4, 4, 4, 4, 4, 0, 0, 0},
                {4, 4, 4, 4, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {4, 4, 4, 4, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {4, 4, 4, 4, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {4, 4, 4, 4, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 4, 4, 4, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
            };

            var test = GetRandomMatrix();

            foreach (var point in FindShortestPath(arr))
            {
                Console.WriteLine(point);
            }

            Console.ReadKey();
        }

        public static Point[] FindShortestPath(int[,] arr)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            var allPaths = new List<Point[]>();
            var flag = true;
            var resultPath = new List<Point>();
            
            var indexX = 0;
            var indexY = 0;

            var Point = new Point(0, 0);
            allPaths.Add(new Point[1] {Point});

            while (flag)
            {
                var newPaths = new List<Point[]>();
                foreach (var path in allPaths)
                {
                    var initValues = GetInitValues(path, arr);
                    var availablePoints = GetNextMoves(path[path.Length - 1].X, path[path.Length - 1].Y, arr, initValues).ToArray();
                    foreach (var newPoint in availablePoints)
                    {
                        if (!path.Contains(newPoint))
                        {
                            var newPath = new Point[path.Length + 1];
                            for (int i = 0; i < path.Length; i++)
                            {
                                newPath[i] = path[i];
                            }

                            newPath[newPath.Length - 1] = newPoint;

                            newPaths.Add(newPath);
                        }
                    }
                }

                foreach (var path in newPaths)
                {
                    allPaths.Add(path);
                }

                var length = allPaths.OrderBy(p => p.Length).Last().Length;
                allPaths = allPaths.Where(p => p.Length >= length).ToList();
                
                var lastPoint = new Point(arr.GetLength(0) - 1, arr.GetLength(1) - 1);
                
                allPaths = allPaths.OrderBy(p => GetDistance(p.Last(), lastPoint)).Take(15).ToList();
                
                foreach (var path in allPaths)
                {
                    if (path[path.Length - 1].X == arr.GetLength(0) - 1 && path[path.Length - 1].Y == arr.GetLength(1) - 1)
                    {
                        resultPath = path.ToList();
                        flag = false;
                    }
                }
            }
            
            watch.Stop();
            
            Console.WriteLine("FindShortestPath evaluation time: " + watch.ElapsedMilliseconds);

            return resultPath.ToArray();
        }

        public static List<int> GetInitValues(Point[] points, int[,] arr)
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

        public static int[,] GetRandomMatrix()
        {
            var random = new Random();

            var x = random.Next(30);
            var y = random.Next(30);
            
            var result = new int[x, y];

            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    var value = random.Next(30);
                    result[i, j] = value > 6 ? 0 : value;
                }
            }
            
            return result;
        }
    }
}
