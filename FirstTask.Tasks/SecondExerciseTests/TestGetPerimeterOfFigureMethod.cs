using FirstTask.SecondExercise;
using FirstTask.SecondExercise.Polygons;
using FirstTask.SecondExercise.SmoothCurves;
using System;
using Xunit;

namespace FirstTask.Tests.SecondExerciseTests
{
    public class TestGetPerimeterOfFigureMethod
    {
        [Fact]
        public void TestGetPerimeter_Triangle_0_0_5_5_0_5_24returned()
        {
            var points = new Point[]
            {
                new Point(0, 0),
                new Point(5, 5),
                new Point(0, 5)
            };
            var triangle = new Triangle(points);
            double expected = 17.07;

            var actual = Math.Round(triangle.GetPerimeterOfFigure(), 2);
            
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestGetPerimeter_Rectangle_minus7_1_5_minus5_24returned()
        {
            var points = new Point[]
            {
                new Point(-7, 1),
                new Point(5, -5),
            };
            var rectangle = new Rectangle(points);
            double expected = 36;

            var actual = Math.Round(rectangle.GetPerimeterOfFigure(), 2);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestGetPerimeter_Polygon_min3_min2_min1_4_6_1_3_10_min4_9_60returned()
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
            double expected = 41.54;

            var actual = Math.Round(polygon.GetPerimeterOfFigure(), 2);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestGetPerimeter_Circle_0_0_0_5_returned()
        {
            var points = new Point[]
            {
                new Point(0, 0),
                new Point(0, 5),
            };
            var circle = new Circle(points);
            double expected = 15.71;

            var actual = Math.Round(circle.GetPerimeterOfFigure(), 2);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestGetPerimeter_Oval_minus7_1_5_minus5_60returned()
        {
            var points = new Point[]
            {
                new Point(-7, 1),
                new Point(5, -5),
            };
            var oval = new Oval(points);
            double expected = 29.8;

            var actual = Math.Round(oval.GetPerimeterOfFigure(), 1);

            Assert.Equal(expected, actual);
        }
    }
}
