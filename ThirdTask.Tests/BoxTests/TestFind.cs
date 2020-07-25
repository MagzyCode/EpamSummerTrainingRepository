using Application.Figures;
using Application.Painting;
using FiguresCollection;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ThirdTask.Tests.BoxTests
{
    public class TestFind
    {
        [Fact]
        public void Replace_Circle_trueexcpected()
        {
            var expected = true;
            bool actual = false;
            var box = new Box { Figures = BoxCreated.figures };


            var result = box.Find(typeof(Circle), FigureColor.Transparent);
            if ((result.ColorOfFigure == FigureColor.Transparent) &&
                result.GetType() == typeof(Circle))
            {
                actual = true;
            }

            Assert.Equal(expected, actual);
        }
    }
}
