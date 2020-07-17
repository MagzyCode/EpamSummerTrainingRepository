using SecondTask.FirstExercise;
using Xunit;

namespace SecondTasks.Tests.TestFirstExercise
{
    public class TestAdditionOperation
    {
        [Fact]
        public void AdditionOfVectors_vector_0_0_0_and_vector_5_5_5_vector5_5_5expected()
        {
            var expected = new Vector(5, 5, 5);

            var firstVector = new Vector(0, 0, 0);
            var secondVector = new Vector(5, 5, 5);
            var actual = firstVector + secondVector;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void AdditionOfVectors_vector_min3_145_1_and_vector_985and5_min5_14and45_()
        {
            var expected = new Vector(982.5, 140, 15.45);

            var firstVector = new Vector(-3, 145, 1);
            var secondVector = new Vector(985.5, -5, 14.45);
            var actual = firstVector + secondVector;

            Assert.Equal(expected, actual);
        }
    }
}
