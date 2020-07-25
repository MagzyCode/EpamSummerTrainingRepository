using FiguresCollection;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ThirdTask.Tests.BoxTests
{
    public class TestGetingAllCircles
    {
        [Fact]
        public void GetAllCircles_Circle_1excpected()
        {
            var expected = 3;

            var box = new Box { Figures = BoxCreated.figures };

            var circles = box.GetAllCircles();
            var actual = circles.Length;

            Assert.Equal(expected, actual);
        }
    }
}
