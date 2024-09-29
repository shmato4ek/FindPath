using System;
using System.Drawing;
using System.Linq;

namespace FindPath.App.Helpers;

public static class CreateMatrixHelper
{
    public static int[,] GetRandomMatrix()
    {
        var random = new Random();
        
        var size = 25;
            
        var result = new int[size, size];

        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                var value = random.Next(30);
                result[i, j] = value > 6 ? 0 : value;
            }
        }
            
        return result;
    }

    public static void ShowPath(Point[] points, int[,] arr)
    {
        for (int i = 0; i < arr.GetLength(0); i++)
        {
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                Console.Write(points.Contains(new Point(i, j)) ? " " + arr[i, j] + " " : " * ");
                if (j == arr.GetLength(1) - 1)
                {
                    Console.WriteLine();
                }
            }
        }
    }
}