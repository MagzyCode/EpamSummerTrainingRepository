using SecondTask.FirstExercise;
using Xunit;

namespace SecondTasks.Tests.TestFirstExercise
{
    public class TestAreVectorsCollinearMethod
    {
        [Fact]
        public void AreVectorsCollinearMethod_vector_0_0_0_and_vector_5_5_5_falseexpected()
        {
            bool? expected = null;

            var firstVector = new Vector(0, 0, 0);
            var secondVector = new Vector(5, 5, 5);
            var actual = Vector.AreVectorsCollinear(firstVector, secondVector);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void AreVectorsCollinearMethod_vector_1_2_3_and_vector_4_8_12_trueexpexted()
        {
            bool? expected = true;

            var firstVector = new Vector(1, 2, 3);
            var secondVector = new Vector(4, 8, 12);
            var actual = Vector.AreVectorsCollinear(firstVector, secondVector);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void AreVectorsCollinearMethod_vector_1_2_3_and_vector_5_10_12_trueexpexted()
        {
            bool? expected = false;

            var firstVector = new Vector(1, 2, 3);
            var secondVector = new Vector(5, 10, 12);
            var actual = Vector.AreVectorsCollinear(firstVector, secondVector);

            Assert.Equal(expected, actual);
        }


    }
}

