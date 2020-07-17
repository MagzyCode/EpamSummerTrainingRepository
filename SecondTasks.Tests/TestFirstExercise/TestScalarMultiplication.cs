using SecondTask.FirstExercise;
using Xunit;

namespace SecondTasks.Tests.TestFirstExercise
{
    public class TestScalarMultiplication
    {
        [Fact]
        public void GetScalarMultiplication_vector_10_min24_36_and_vector_10_24_36_820xpected()
        {
            var expected = 820;

            var firstVector = new Vector(10, -24, 36);
            var secondVector = new Vector(10, 24, 36);
            var actual = Vector.GetScalarMultiplication(firstVector, secondVector);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetScalarMultiplication_vector_10_min24_36_and_vector_min11_16_3_min386expected()
        {
            var expected = -386.0;

            var firstVector = new Vector(10, -24, 36);
            var secondVector = new Vector(-11, 16, 3);
            var actual = Vector.GetScalarMultiplication(firstVector, secondVector);

            Assert.Equal(expected, actual);
        }
    }
}
