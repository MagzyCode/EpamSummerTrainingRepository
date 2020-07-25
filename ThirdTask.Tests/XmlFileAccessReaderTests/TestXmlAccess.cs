using Application.Painting;
using System.IO;
using System.Linq;
using XmlFileAccess;
using Xunit;

namespace ThirdTask.Tests.XmlFileAccessReaderTests
{
    public class TestXmlAccess
    {
        [Fact]
        public void LoadFileAndSave_9excpected()
        {
            var expected = BoxCreated.TEST_COUNT;

            XmlAccess.Save(BoxCreated.figures);
            var figures = XmlAccess.LoadFile();
            var actual = figures.Where(i => i != null).Count();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void LoadFileAndSaveInDifferentAccess_9excpected()
        {
            var expected = BoxCreated.TEST_COUNT;

            StreamAccess.Save(BoxCreated.figures, "testFigures1.xml");
            var figures = XmlAccess.LoadFile("testFigures1.xml");
            
            var actual = figures.Where(i => i != null).Count();

            Assert.Equal(expected, actual);
        }
    }
}
