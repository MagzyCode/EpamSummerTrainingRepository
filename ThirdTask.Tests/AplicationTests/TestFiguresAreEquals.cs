using Application.Figures;
using Application.Painting;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ThirdTask.Tests.AplicationTests
{
    public class TestFiguresAreEquals
    {
        [Fact]
        public void Equals_Circle_Circle_trueexcpected()
        {
            var expected = true;

            var first = new Circle(FigureMaterial.Paper, new Point(0, 0), 12) { ColorOfFigure = FigureColor.Blue };
            var second = new Circle(FigureMaterial.Paper, new Point(-1.45, 9.258), 19) { ColorOfFigure = FigureColor.Blue };
            var actual = first.Equals(second);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Equals_Polygon_Circle_falseexcpected()
        {
            var expected = false;

            var first = new Circle(FigureMaterial.Paper, new Point(0, 0), 12) { ColorOfFigure = FigureColor.Blue };
            var points = new Point[]
            {
                new Point(-5, -5),
                new Point(10, 10),
                new Point(6, 0)
            };
            var second = new Polygon(FigureMaterial.Film, points);
            var actual = first.Equals(second);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Equals_Oval_Oval_falseexcpected()
        {
            var expected = false;

            var first = new Oval(FigureMaterial.Paper, new Point(0, 0), 2, 12) { ColorOfFigure = FigureColor.Blue };
            var second = new Oval(FigureMaterial.Paper, new Point(-1.45, 9.258), 19, 32) { ColorOfFigure = FigureColor.Orange};
            var actual = first.Equals(second);

            Assert.Equal(expected, actual);
        }

    }
}
