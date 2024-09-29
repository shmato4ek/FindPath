using System;
using System.Collections.Generic;
using System.Drawing;
using FindPath.App.Strategy;
using FindPath.App.Strategy.Abstract;
using FindPath.App.Strategy.Implementation;
using NUnit.Framework;

namespace FindPath.Tests;

public class FindPathStrategiesTests
{
    [Test]
    public void EmptyArrayErrorTest()
    {
        var emptyArray = new int[0,0];
        foreach (var TC in new List<FindPathContext>
                 {
                     new FindPathContext(new BfsSearchPathStrategy()),
                     new FindPathContext(new EuclideanDistanceSearchPathStrategy()),
                 })
        {
            Assert.Throws<Exception>(() => TC.FindPath(emptyArray));
        }
    }

    [Test]
    public void PathDoesNotExistTest()
    {
        var arr = new int[3, 3]
        {
            { 0, 1, 2 },
            { 3, 4, 5 },
            { 4, 3, 2 }
        };

        foreach (var TC in new List<FindPathContext>
                 {
                     new FindPathContext(new BfsSearchPathStrategy()),
                     new FindPathContext(new EuclideanDistanceSearchPathStrategy()),
                 })
        {
            Assert.Throws<Exception>(() => TC.FindPath(arr));
        }
    }

    [Test]
    public void NonSquareArrayResultLengthTest()
    {
        int[,] arr = new int[3,4]
        {
            {0, 0, 1, 0},
            {0, 1, 0, 0},
            {0, 0, 4, 0},
        };
        
        var expectedResult = new[]
        {
            new Point(0, 0),
            new Point(0, 1),
            new Point(0, 2),
            new Point(1, 2),
            new Point(1, 3),
            new Point(2, 3),
        };

        foreach (var TC in new List<FindPathContext>
        {
            new FindPathContext(new BfsSearchPathStrategy()),
            new FindPathContext(new EuclideanDistanceSearchPathStrategy()),
        })
        {
            Assert.That(TC.FindPath(arr).Length, Is.EqualTo(expectedResult.Length));
        }
    }

    [Test]
    public void LargeArrayResultLengthTest()
    {
        var arr = new int[25, 25]
        {
            { 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 4, 0 },
            { 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 4, 0 },
            { 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 4, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 4, 4, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 1, 0, 0, 0, 5, 5, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 1, 0, 0, 0, 5, 5, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 5, 0, 0, 0, 0, 5, 5, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 4, 4, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 5, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 5, 5, 5, 5, 5, 5, 5, 0, 0, 0, 0, 0, 0, 0, 0, 5, 5, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 5, 5, 5, 5, 0, 0, 0, 0 },
            { 0, 4, 4, 4, 4, 4, 0, 0, 0, 0, 0, 0, 0, 5, 5, 5, 5, 5, 5, 5, 5, 0, 0, 0, 0 },
            { 0, 4, 4, 4, 4, 5, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 4, 0, 0, 0, 0, 5, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 5, 4, 4, 4, 4, 4, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 4, 4, 4, 4, 4, 0, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 4, 4, 4, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
        };

        var expectedResult = new[]
        {
            new Point(0, 0),
            new Point(0, 1),
            new Point(1, 1),
            new Point(1, 2),
            new Point(2, 2),
            new Point(3, 3),
            new Point(3, 4),
            new Point(4, 4),
            new Point(4, 5),
            new Point(5, 5),
            new Point(5, 6),
            new Point(6, 6),
            new Point(6, 7),
            new Point(7, 7),
            new Point(7, 8),
            new Point(8, 8),
            new Point(8, 9),
            new Point(9, 9),
            new Point(9, 10),
            new Point(10, 10),
            new Point(10, 11),
            new Point(11, 11),
            new Point(11, 12),
            new Point(12, 12),
            new Point(12, 13),
            new Point(13, 13),
            new Point(13, 14),
            new Point(14, 14),
            new Point(14, 15),
            new Point(15, 15),
            new Point(15, 16),
            new Point(16, 16),
            new Point(16, 17),
            new Point(17, 17),
            new Point(17, 18),
            new Point(18, 18),
            new Point(19, 19),
            new Point(19, 20),
            new Point(20, 20),
            new Point(20, 21),
            new Point(21, 21),
            new Point(21, 22),
            new Point(22, 22),
            new Point(22, 23),
            new Point(23, 23),
            new Point(23, 24),
            new Point(24, 24),
        };
        
        foreach (var TC in new List<FindPathContext>
                 {
                     new FindPathContext(new BfsSearchPathStrategy()),
                     new FindPathContext(new EuclideanDistanceSearchPathStrategy()),
                 })
        {
            Assert.That(TC.FindPath(arr).Length, Is.EqualTo(expectedResult.Length));
        }
    }
}