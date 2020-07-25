using Application.Figures;
using Application.Painting;
using FiguresCollection;
using System.Linq;
using Xunit;

namespace ThirdTask.Tests.BoxTests
{
    public class TestAddition
    {
        [Fact]
        public void Adding_Circle_1excpected()
        {
            var expected = 1;

            var box = new Box();
            ISpecificFigure figure = new Circle(FigureMaterial.Paper, new Point(0, 0), 2);
            box.AddFigure(figure);
            var actual = box.Count;

            Assert.Equal(expected, actual);
        }
    }
}
