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
        public void LoadFile_4excpected()
        {
            var expected = 4;

            var figures = StreamAccess.LoadFile();
            var actual = figures.Where(i => i != null).Count();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Save_trueexcpected()
        {
            var expected = 4;

            var figures = StreamAccess.LoadFile();
            StreamAccess.Save(figures);
            figures = StreamAccess.LoadFile();
            var actual = figures.Where(i => i != null).Count();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SaveAllFilm_trueexcpected()
        {
            var expected = 2;

            var figures = StreamAccess.LoadFile();
            StreamAccess.Save(figures, Application.Painting.FigureMaterial.Film);
            figures = StreamAccess.LoadFile();
            var actual = figures.Where(i => i != null).Count();

            Assert.Equal(expected, actual);
        }

    }
}
