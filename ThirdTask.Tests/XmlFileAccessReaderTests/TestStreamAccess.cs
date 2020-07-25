using Application.Painting;
using System;
using System.IO;
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
    }
}
