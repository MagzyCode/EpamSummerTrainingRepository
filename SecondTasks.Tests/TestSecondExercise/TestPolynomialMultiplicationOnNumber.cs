using SecondTask.SecondExercise;
using Xunit;


namespace SecondTasks.Tests.TestSecondExercise
{
    public class TestPolynomialMultiplicationOnNumber
    {
        [Fact]
        public void PolynomialMultiplicationOnNumber_poly_6_miin7_4_6_and_min1_poly_min6_7_min4_min6expected()
        {
            var expected = new Polynomial(-6, 7, -4, -6);

            var number = -1;
            var value = new Polynomial(6, -7, 4, 6);
            var actual = number * value;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void PolynomialMultiplicationOnNumber_poly_9_13_1_and_poly_5point89_poly_53point01_76point57_5point89expected()
        {
            var expected = new Polynomial(9 * 5.89, 13 * 5.89, 1 * 5.89);

            var number = 5.89;
            var value = new Polynomial(9, 13, 1);
            var actual = number * value;

            Assert.Equal(expected, actual);
        }
    }
}
