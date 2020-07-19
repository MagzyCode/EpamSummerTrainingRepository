using SecondTask.ThirdExercise.Specific_Product;
using System.Net.WebSockets;
using Xunit;

namespace SecondTasks.Tests.TestThirdExercise
{
    public class TestTransformationOfProduct
    {
        [Fact]
        public void TestTransformationOfProduct_GastroProd_folk_HouseholdProd_folk_expected()
        {
            var expected = new GastronomicProduct("Вилка", 300);

            var value = new HouseholdProduct("Вилка", 300);
            GastronomicProduct actual = value;

            Assert.Equal(expected, actual);
        }
    }
}
