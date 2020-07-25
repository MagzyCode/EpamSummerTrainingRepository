using Application.Figures;
using Application.Painting;
using FiguresCollection;
using Xunit;

namespace ThirdTask.Tests.BoxTests
{
    public class TestFigureReplace
    {
        [Fact]
        public void Replace_Circle_1excpected()
        {
            var expected = BoxCreated.TEST_COUNT;

            var box = new Box { Figures = BoxCreated.figures };
            var circle = new Circle(FigureMaterial.Film, new Point[] { BoxCreated.points[0], BoxCreated.points[1] });

            box.ReplaceFigure(0, circle);
            var actual = box.Count;

            Assert.Equal(expected, actual);
        }
    }
}
