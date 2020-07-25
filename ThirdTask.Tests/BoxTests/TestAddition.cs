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
            var expected = BoxCreated.TEST_COUNT + 1;

            var box = new Box { Figures = BoxCreated.figures };
            var circle = new Circle(FigureMaterial.Film, new Point[] { BoxCreated.points[0], BoxCreated.points[1] });

            box.AddFigure(circle);
            var actual = box.Count;

            Assert.Equal(expected, actual);
        }
    }
}
