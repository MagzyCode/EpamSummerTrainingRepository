using SecondTask.ThirdExercise.Specific_Product;
using Xunit;

namespace SecondTasks.Tests.TestThirdExercise
{
    public class TestTransformationProductInCost
    {
        [Fact]
        public void TestTransformationProductInCost_product_spoon_300expected()
        {
            var expected = 300.0;

            var value = new HouseholdProduct("Вилка", 300);
            var actual = (double)value;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestTransformationProductInCost_product_spoon_30000expected()
        {
            var expected = 30000;

            var value = new HouseholdProduct("Вилка", 300);
            var actual = (int)value;

            Assert.Equal(expected, actual);
        }
    }
}
