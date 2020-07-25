using FiguresCollection;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ThirdTask.Tests.BoxTests
{
    public class TestGettingAllFilmFigures
    {
        [Fact]
        public void GetAllFilmFigures_Circle_1excpected()
        {
            var expected = 5;

            var box = new Box { Figures = BoxCreated.figures };

            var circles = box.GetAllFilmFigures();
            var actual = circles.Length;

            Assert.Equal(expected, actual);
        }
    }
}
