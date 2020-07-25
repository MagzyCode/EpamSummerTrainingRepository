using FiguresCollection;
using Xunit;

namespace ThirdTask.Tests.BoxTests
{
    public class TestGetTotalArea
    {
        [Fact]
        public void GetTotalArea_Circle_540excpected()
        {
            var expected = 540.25216010359941;

            var box = new Box { Figures = BoxCreated.figures };

            var actual = box.TotalArea;

            Assert.Equal(expected, actual);
        }
    }
}
