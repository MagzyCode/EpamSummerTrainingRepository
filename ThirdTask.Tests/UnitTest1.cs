using Application.Figures;
using Application.Painting;
using FiguresCollection;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using XMLFileAccess;
using Xunit;

namespace ThirdTask.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test()
        {
            var expected = true;
            var points = new Point[]
            {
                new Point(-5, -5),
                new Point(-5, 5),
                new Point(5, 5),
                new Point(5, -5)
            };

            var box = new Box()
            {
                Figures = new List<ISpecificFigure>()
                {
                    new Circle(FigureMaterial.Paper, new Point(0, 0), 9) { ColorOfFigure = FigureColor.Green },
                    new Polygon(FigureMaterial.Paper, points) {ColorOfFigure = FigureColor.Grey },
                    new Circle(FigureMaterial.Paper, points[0], 9) { ColorOfFigure = FigureColor.Brown },
                    new Oval(FigureMaterial.Paper, new Point[] { points[0], points[2] })
                }
            };

            var result = box.Figures;
            // var i = new XMLAccess();
            // i.Save(result);

            var i = new StreamAccess();
            var j = i.LoadFile();
            //i.LoadFile("figures.xml", out result);

            Assert.Equal(expected, true);

        }
    }
}
