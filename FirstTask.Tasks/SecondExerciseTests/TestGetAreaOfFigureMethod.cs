using FirstTask.SecondExercise;
using FirstTask.SecondExercise.Polygons;
using FirstTask.SecondExercise.SmoothCurves;
using System;
using Xunit;

namespace FirstTask.Tests.SecondExerciseTests
{
    public class TestGetAreaOfFigureMethod
    {

        [Fact]
        public void GetAreaOfFigure_Triangle_0_0_5_5_0_5_24returned()
        {
            var points = new Point[]
            {
                new Point(0, 0),
                new Point(5, 5),
                new Point(0, 5)
            };
            var triangle = new Triangle(points);
            double expected = 12.50;

            var actual = Math.Round(triangle.GetAreaOfFigure(), 2);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetAreaOfFigure_Rectangle_minus7_1_5_minus5_24returned()
        {
            var points = new Point[]
            {
                new Point(-7, 1),
                new Point(5, -5),
            };
            var rectangle = new Rectangle(points);
            double expected = 72;

            var actual = Math.Round(rectangle.GetAreaOfFigure(), 2);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetAreaOfFigure_Polygon_min3_min2_min1_4_6_1_3_10_min4_9_60returned()
        {
            var points = new Point[]
            {
                new Point(-3, -2),
                new Point(-1, 4),
                new Point(6, 1),
                new Point(3, 10),
                new Point(-4, 9),
            };
            var polygon = new Polygon(points);
            double expected = 60;

            var actual = Math.Round(polygon.GetAreaOfFigure(), 2);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetAreaOfFigure_Circle_0_0_0_5_returned()
        {
            var points = new Point[]
            {
                new Point(0, 0),
                new Point(0, 5),
            };
            var circle = new Circle(points);
            double expected = 19.63;

            var actual = Math.Round(circle.GetAreaOfFigure(), 2);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetAreaOfFigure_Oval_minus7_1_5_minus5_60returned()
        {
            var points = new Point[]
            {
                new Point(-7, 1),
                new Point(5, -5),
            };
            var oval = new Oval(points);
            double expected = 226.2;

            var actual = Math.Round(oval.GetAreaOfFigure(), 1);

            Assert.Equal(expected, actual);
        }
    }
}
