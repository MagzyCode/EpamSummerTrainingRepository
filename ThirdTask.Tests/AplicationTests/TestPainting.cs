using Application.Figures;
using Application.Painting;
using Xunit;

namespace ThirdTask.Tests.AplicationTests
{
    public class TestPainting
    {
        [Fact]
        public void Cutting_Oval_Circle_trueexcpected()
        {
            var expected = new Circle(FigureMaterial.Paper, new Point(0, 0), 2) { ColorOfFigure = FigureColor.Black };

            ISpecificFigure actual = new Circle(FigureMaterial.Paper, new Point(0, 0), 2);
            FigurePainting.Paint(ref actual, FigureColor.Black);

            Assert.Equal(expected, actual);
        }
    }
}
