using Application.Figures;
using Application.Painting;
using System.Linq;
using XmlFileAccess;
using Xunit;

namespace ThirdTask.Tests.XmlFileAccessReaderTests
{
    public class TestStreamAccess
    {
        [Fact]
        public void LoadFileAndSave_9excpected()
        {
            var expected = BoxCreated.TEST_COUNT;

            StreamAccess.Save(BoxCreated.figures);
            var figures = StreamAccess.LoadFile();
            var actual = figures.Where(i => i != null).Count();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void LoadFileAndSaveInDifferentAccess_9excpected()
        {
            var expected = BoxCreated.TEST_COUNT;

            StreamAccess.Save(BoxCreated.figures, "testFigures.xml");
            var figures = XmlAccess.LoadFile("testFigures.xml");
            var actual = figures.Where(i => i != null).Count();

            Assert.Equal(expected, actual);
        }
    }
}
