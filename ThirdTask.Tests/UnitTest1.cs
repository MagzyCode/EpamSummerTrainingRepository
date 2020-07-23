using Application.Figures;
using FiguresCollection;
using System.Collections.Generic;
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

            var box = new Box()
            {
                Figures = new List<Application.Figures.ISpecificFigure>()
                {
                    new Circle(Application.Painting.FigureMaterial.Paper, new Application.Painting.Point(0, 0), 9)
                }
            };

            XMLAccess.Save(box.Figures);

            Assert.Equal(expected, true);

        }
    }
}
