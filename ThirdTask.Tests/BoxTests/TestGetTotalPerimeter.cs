using FiguresCollection;
using System;
using Xunit;

namespace ThirdTask.Tests.BoxTests
{
    public class TestGetTotalPerimeter
    {
        [Fact]
        public void GetTotalPerimeter_540excpected()
        {
            var expected = 227.70575147305536;

            var box = new Box { Figures = BoxCreated.figures };

            var actual = box.TotalPerimeter;

            Assert.Equal(expected, actual);
        }
    }
}
