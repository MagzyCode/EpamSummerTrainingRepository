using SecondTask.SecondExercise;
using Xunit;

namespace SecondTasks.Tests.TestSecondExercise
{
    public class TestPolynomialMultiplication
    {
        [Fact]
        public void PolynomialMultiplication_poly_1_2_3_and_poly_4_5_6_poly_18_27_28_13_4expected()
        {
            var expected = new Polynomial(4, 13, 28, 27, 18);

            var firstValue = new Polynomial(1, 2, 3);
            var secondValue = new Polynomial(4, 5, 6);
            var actual = firstValue * secondValue;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void PolynomialMultiplicationl_poly_3_5_9_8_and_poly_1_2_4_min99_poly_min792_min859_min443_min251_31_11_3expected()
        {
            var expected = new Polynomial(-792, -859, -443, -251, 31, 11, 3);

            var firstValue = new Polynomial(-99, 4, 2, 1);
            var secondValue = new Polynomial(8, 9, 5, 3);
            var actual = firstValue * secondValue;

            Assert.Equal(expected, actual);
        }
    }
}

