using FirstTask.SecondExercise;
using Xunit;

namespace FirstTask.Tests.SecondExerciseTests
{
    public class TestEqualsMethod
    {
        private FileLoadData fileLoad = new FileLoadData();
        [Fact]
        public void Equals_TriangleandNull_falsereturned()
        {

            var figures = fileLoad.GetFigureFromFile();
            bool expected = false;

            var actual = figures[0].Equals(null);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Equals_TriangleandTriangle_falsereturned()
        {

            var figures = fileLoad.GetFigureFromFile();
            bool expected = false;

            var actual = figures[0].Equals(figures[1]);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Equals_OvalandOval_falsereturned()
        {

            var figures = fileLoad.GetFigureFromFile();
            bool expected = true;

            var actual = figures[2].Equals(figures[3]);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Equals_PolygonAndPolygon_falsereturned()
        {

            var figures = fileLoad.GetFigureFromFile();
            bool expected = false;
           
            var actual = figures[4].Equals(figures[5]);

            Assert.Equal(expected, actual);
        }


    }
}
