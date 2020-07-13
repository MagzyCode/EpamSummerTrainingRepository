using Xunit;

namespace FirstTask.Tests.FirstExerciseTests
{
    public class TestFindEuclideanGCDParamsMethod
    {
        [Fact]
        public void GetEuclideanGCD_168and456_24returned()
        {
            int a = 168;
            int b = 456;
            int expected = 24;

            var algorithm = new EpamSummerTraining.EuclideanAlgorithm();
            int actual = algorithm.GetEuclideanGCD(a, b);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetEuclideanGCD_minus5and333and555_minus1returned()
        {
            int a = -5;
            int b = 333;
            int c = 555;
            int expected = -1;

            var algorithm = new EpamSummerTraining.EuclideanAlgorithm();
            int actual = algorithm.GetEuclideanGCD(a, b, c);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetEuclideanGCD_16and64and1000_8returned()
        {
            int a = 16;
            int b = 64;
            int c = 1000;
            int expected = 8;

            var algorithm = new EpamSummerTraining.EuclideanAlgorithm();
            int actual = algorithm.GetEuclideanGCD(a, b, c);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetEuclideanGCD_1and6and6_0returned()
        {
            int a = 1;
            int b = 6;
            int c = 6;
            int expected = 1;

            var algorithm = new EpamSummerTraining.EuclideanAlgorithm();
            int actual = algorithm.GetEuclideanGCD(a, b, c);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetEuclideanGCD_44and444and4444and6554_2returned()
        {
            int a = 44;
            int b = 444;
            int c = 4444;
            int d = 6554;
            int expected = 2;

            var algorithm = new EpamSummerTraining.EuclideanAlgorithm();
            int actual = algorithm.GetEuclideanGCD(a, b, c, d);

            Assert.Equal(expected, actual);
        }
    }
}
