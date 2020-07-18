using SecondTask.SecondExercise;
using Xunit;

namespace SecondTasks.Tests.TestSecondExercise
{
    public class TestPolynomialDivision
    {
        [Fact]
        public void PolynomialMultiplication_poly_1_2_3_and_poly_4_5_6_poly_18_27_28_13_4expected()
        {
            var expectedQuotient = new Polynomial(-1, 3);
            var expectedRemainder = new Polynomial(5, 1);

            var firstValue = new Polynomial(4, 2, 5, 3);
            var secondValue = new Polynomial(1, 2, 1);
            var actual = firstValue / secondValue;

            Assert.Equal(expectedQuotient, actual.quotient);
            Assert.Equal(expectedRemainder, actual.remainder);
        }

    }
}
