using SecondTask.FirstExercise;
using Xunit;

namespace SecondTasks.Tests.TestFirstExercise
{
    public class TestComparisonOperation
    {

        [Fact]
        public void Equals_vector_0_0_0_and_vector_0_0_0_trueexpected()
        {
            var expected = true;

            var firstVector = new Vector(0, 0, 0);
            var secondVector = new Vector(0, 0, 0);
            var actual = firstVector.Equals(secondVector);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Equals_vector_0_0_0_and_vector_0_0_min1_expected()
        {
            var expected = false;

            var firstVector = new Vector(0, 0, 0);
            var secondVector = new Vector(0, 0, -1);
            var actual = firstVector.Equals(secondVector);

            Assert.Equal(expected, actual);
        }
    }
}
