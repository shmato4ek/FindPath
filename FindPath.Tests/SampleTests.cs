using FindPath.App;
using NUnit.Framework;
using System.Drawing;

namespace FindPath.Tests
{
    public class Tests
    {
        [Test]
        public void FindShortestPath_EmptyArray_ReturnsDirectPath()
        {
            int[,] arr = new int[4, 4]
            {
                {0,0,0,0},
                {0,0,0,0},
                {0,0,0,0},
                {0,0,0,0}
            };

            var expectedResult = new[]
            {
                new Point(0,0),
                new Point(0,1),
                new Point(1,1),
                new Point(1,2),
                new Point(2,2),
                new Point(2,3),
                new Point(3,3)
            };

            var actualResult = Program.FindShortestPath(arr);

            Assert.IsNotNull(actualResult);
            Assert.That(actualResult.Length, Is.EqualTo(expectedResult.Length));

            for(int i = 0; i < expectedResult.Length; i++)
            {
                Assert.That(actualResult[i], Is.EqualTo(expectedResult[i]));
            }
        }

        [Test]
        public void FindShortestPath_UniformArray_ReturnsDirectPath()
        {
            int[,] arr = new int[4, 4]
            {
                {1,1,1,1},
                {1,1,1,1},
                {1,1,1,1},
                {1,1,1,1}
            };

            var expectedResult = new[]
            {
                new Point(0,0),
                new Point(1,1),
                new Point(2,2),
                new Point(3,3)
            };

            var actualResult = Program.FindShortestPath(arr);

            Assert.IsNotNull(actualResult);
            Assert.That(actualResult.Length, Is.EqualTo(expectedResult.Length));

            for (int i = 0; i < expectedResult.Length; i++)
            {
                Assert.That(actualResult[i], Is.EqualTo(expectedResult[i]));
            }
        }

        [Test]
        public void FindShortestPath_MixedArray_ReturnsShortestPath()
        {
            int[,] arr = new int[4, 4]
            {
                {1,1,0,1},
                {1,1,0,1},
                {0,0,4,1},
                {1,1,1,1}
            };

            var expectedResult = new[]
            {
                new Point(0,0),
                new Point(1,1),
                new Point(1,2),
                new Point(1,3),
                new Point(2,3),
                new Point(3,3)
            };

            var actualResult = Program.FindShortestPath(arr);

            Assert.IsNotNull(actualResult);
            Assert.That(actualResult.Length, Is.EqualTo(expectedResult.Length));

            for (int i = 0; i < expectedResult.Length; i++)
            {
                Assert.That(actualResult[i], Is.EqualTo(expectedResult[i]));
            }
        }
    }
}