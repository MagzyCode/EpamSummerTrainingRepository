using Xunit;


namespace FirstTask.Tasks
{
    public class TestGetEuclideanGCDMethod
    {
        [Fact]
        public void GetEuclideanGCD_168and456_24returned()
        {  
            int i = 168;
            int j = 456;
            int expected = 24;

            var algorithm = new EpamSummerTraining.EuclideanAlgorithm();
            int actual = algorithm.GetEuclideanGCD(i, j, out _);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetEuclideanGCD_minus5and333_minus1returned()
        {
            int i = -5;
            int j = 333;
            int expected = -1;

            var algorithm = new EpamSummerTraining.EuclideanAlgorithm();
            int actual = algorithm.GetEuclideanGCD(i, j, out _);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetEuclideanGCD_24and0_0returned()
        {
            int i = 24;
            int j = 0;
            int expected = 0;

            var algorithm = new EpamSummerTraining.EuclideanAlgorithm();
            int actual = algorithm.GetEuclideanGCD(i, j, out _);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetEuclideanGCD_1and6_0returned()
        {
            int i = 1;
            int j = 6;
            int expected = 1;

            var algorithm = new EpamSummerTraining.EuclideanAlgorithm();
            int actual = algorithm.GetEuclideanGCD(i, j, out _);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetEuclideanGCD_1598and47154_2returned()
        {
            int i = 1598;
            int j = 47154;
            int expected = 2;

            var algorithm = new EpamSummerTraining.EuclideanAlgorithm();
            int actual = algorithm.GetEuclideanGCD(i, j, out _);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetEuclideanGCD_155and155_155returned()
        {
            int i = 155;
            int j = 155;
            int expected = 155;

            var algorithm = new EpamSummerTraining.EuclideanAlgorithm();
            int actual = algorithm.GetEuclideanGCD(i, j, out _);

            Assert.Equal(expected, actual);
        }
    }
}
