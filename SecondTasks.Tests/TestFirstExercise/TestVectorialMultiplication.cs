using SecondTask.FirstExercise;
using Xunit;

namespace SecondTasks.Tests.TestFirstExercise
{
    public class TestVectorialMultiplication
    {
        [Fact]
        public void VectorialMultiplication_vector_5_min6_1_and_vector_33_2_4_vector_min26_13_208expected()
        {
            var expected = new Vector(-26, 13, 208);

            var firstVector = new Vector(5, -6, 1);
            var secondVector = new Vector(33, 2, 4);
            var actual = firstVector - secondVector;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void VectorialMultiplication_vector_2_8_9_and_vector_min3_min2_0()
        {
            var expected = new Vector(18, -27, 20);

            var firstVector = new Vector(2, 8, 9);
            var secondVector = new Vector(3, 2, 0);
            var actual = firstVector - secondVector;

            Assert.Equal(expected, actual);
        }
    }
}
