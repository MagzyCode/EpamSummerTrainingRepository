using FirstTask.SecondExercise;
using System;
using Xunit;

namespace FirstTask.Tests.SecondExerciseTests
{
    public class TestGetLengthBetweenPointsMethod
    {
        [Fact]
        public void GetLengthBetweenPoints_0_0_5_5_7point0711returned()
        {
            var points = new Point[]
            {
                new Point(0, 0),
                new Point(5, 5),
            };
            double expected = 7.0711;

            var actual = Math.Round(Figure.GetLengthBetweenPoints(points[0], points[1]), 4) ;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetLengthBetweenPoints_min54_min64_105_min1_213returned()
        {
            var points = new Point[]
            {
                new Point(-54, -64),
                new Point(150, -1),
            };
            double expected = 213.5064;

            var actual = Math.Round(Figure.GetLengthBetweenPoints(points[0], points[1]), 4);

            Assert.Equal(expected, actual);
        }
    }
}
