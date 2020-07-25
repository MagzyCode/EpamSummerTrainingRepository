using FiguresCollection;
using System.Linq;
using Xunit;

namespace ThirdTask.Tests.BoxTests
{
    public class TestRemoving
    {
        [Fact]
        public void RemoveFigure_540excpected()
        {
            var expected = BoxCreated.TEST_COUNT - 1;

            var box = new Box { Figures = BoxCreated.figures };

            box.RemoveFigure(5);
            var actual = box.Figures.Where(i => i != null).Count(); 

            Assert.Equal(expected, actual);
        }
    }
}
