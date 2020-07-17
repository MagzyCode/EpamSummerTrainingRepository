using SecondTask.FirstExercise;
using Xunit;

namespace SecondTasks.Tests.TestFirstExercise
{
    public class TestMultiplicationVectorAndNumber
    {
        [Fact]
        public void MultiplicationVectorAndNumber_vector_10_min24_36_and_min5point89_trueexpected()
        {
            var expected = new Vector(-5.89 * 10, -5.89 * -24, -5.89 * 36);

            var firstVector = new Vector(10, -24, 36);
            var number = -5.89;
            var actual = firstVector * number;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void MultiplicationVectorAndNumber_vector_10_min24_36_and_09_trueexpected()
        {
            var expected = new Vector(0, 0, 0);

            var firstVector = new Vector(10, -24, 36);
            var number = 0;
            var actual = firstVector * number;

            Assert.Equal(expected, actual);
        }
    }
}
