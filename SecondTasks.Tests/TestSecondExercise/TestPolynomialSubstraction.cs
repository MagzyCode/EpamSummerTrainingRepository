using SecondTask.SecondExercise;
using Xunit;

namespace SecondTasks.Tests.TestSecondExercise
{
    public class TestPolynomialSubstraction
    {

        [Fact]
        public void SubstractionOfPolynomial_poly_min5_12_1_and_poly_1_5_5_6_poly_1_0_17_7expected()
        {
            var expected = new Polynomial(-6, 7, -4, -6);

            var firstValue = new Polynomial(-5, 12, 1);
            var secondValue = new Polynomial(1, 5, 5, 6);
            var actual = firstValue - secondValue;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SubstractionOfPolynomial_poly_9_1_1_and_poly_1_5_6_poly_10_6_7expected()
        {
            var expected = new Polynomial(8, -4, -5);

            var firstValue = new Polynomial(9, 1, 1);
            var secondValue = new Polynomial(1, 5, 6);
            var actual = firstValue - secondValue;

            Assert.Equal(expected, actual);
        }
    }
}
