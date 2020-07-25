using Application.Figures;
using Application.Painting;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using Xunit;

namespace ThirdTask.Tests.AplicationTests
{
    public class TestFiguresCutting
    {
        [Fact]
        public void Cutting_Oval_Circle_trueexcpected()
        {
            var expected = new Circle(FigureMaterial.Paper, new Point(0, 0), 2) { ColorOfFigure = FigureColor.Blue };

            var first = new Oval(FigureMaterial.Paper, new Point(0, 0), 3, 12) { ColorOfFigure = FigureColor.Blue };
            var points = new Point[]
            {
                new Point(0, 0),
                new Point(0, 3)
            };
            var actual = new Circle(first, points);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Cutting_Polygon_Circle_falseexcpected()
        {
            var expected = false;
            bool actual;
            try
            {
                var points = new Point[]
                {
                    new Point(0, 0),
                    new Point(0, 3),
                    new Point(3, 3),
                    new Point(3, 0)
                };
                var expectedCircle = new Circle(FigureMaterial.Paper, new Point[] { points[1], points[3] });
                var polygon = new Polygon(FigureMaterial.Paper, points);
                var circle = new Circle(polygon, new Point[] { points[0], points[2] });

                actual = expectedCircle.Equals(circle);
            }
            catch
            {
                actual = false;
            }
            Assert.Equal(expected, actual);
        }
    }
}
