using SecondTask.ThirdExercise.Specific_Product;
using Xunit;

namespace SecondTasks.Tests.TestThirdExercise
{
    public class TestAdditionOfSameProduct
    {
        [Fact]
        public void TestAdditionOfSameProduct_product_spoon_and_product_folk_spoonfolk_expected()
        {
            var expected = new GroceryProduct("Ложка-Вилка", 300);


            var firstValue = new GroceryProduct("Ложка", 200);
            var secondValue = new GroceryProduct("Вилка", 400);
            var actual = firstValue + secondValue;

            Assert.Equal(expected, actual);
        }
    }
}
