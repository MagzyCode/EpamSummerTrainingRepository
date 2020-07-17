using SecondTask.FirstExercise;
using Xunit;

namespace SecondTasks.Tests.TestFirstExercise
{
    public class TestAreVectorsOrthogonalMethod
    {

        [Fact]
        public void AreVectorsOrthogonalMethod_vector_1_2_0_and_vector_2_min1_10_trueexpected()
        {
            var expected = true;

            var firstVector = new Vector(1, 2, 0);
            var secondVector = new Vector(2, -1, 10);
            var actual = Vector.AreVectorsOrthogonal(firstVector, secondVector);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void AreVectorsOrthogonalMethod_vector_1_2_3_and_vector_2_1_10_trueexpected()
        {
            var expected = false;

            var firstVector = new Vector(1, 2, 3);
            var secondVector = new Vector(2, 1, 10);
            var actual = Vector.AreVectorsOrthogonal(firstVector, secondVector);

            Assert.Equal(expected, actual);
        }
    }
}
