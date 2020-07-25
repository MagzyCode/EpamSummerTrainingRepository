using Application.Painting;
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
    }
}
