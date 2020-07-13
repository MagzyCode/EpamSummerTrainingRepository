using System;
using System.Diagnostics;

namespace EpamSummerTraining
{
    /// <summary>
    /// Класс, предназначенный для вычисления НОД(GCD) чисел с применением алгоритма Евклида
    /// </summary>
    public class EuclideanAlgorithm
    {
        #region Constructors
        public EuclideanAlgorithm()
        { }

        #endregion

        #region Methods

        /// <summary>
        /// Метод выполняет подготовку данные для построения гистограммы,
        /// сравнивающей время нахождения решения.
        /// </summary>
        /// <param name="numberOfColumns">Количество столбцов гистограммы.</param>
        /// <returns>
        /// Возвращает время выполнения двух алгоритмов и значения, 
        /// используемые этими алгоритмами. В случае задания числу столбцов
        /// отрицательного значения, возращается null.
        /// </returns>
        public ((TimeSpan, TimeSpan)[], (int, int)[]) GetHistogramData(int numberOfColumns = 10)
        {
            if (numberOfColumns < 1)
            {
                return (default, default);
            }
            var timeOfAlgorithms = new (TimeSpan, TimeSpan)[numberOfColumns];
            var valuesForGCD = new (int, int)[numberOfColumns];
            var randomNumber = new Random();
            for (int counter = 0; counter < numberOfColumns; counter--)
            {
                int firstNumber = randomNumber.Next(int.MaxValue);
                int secondNumber = randomNumber.Next(int.MaxValue);
                valuesForGCD[counter] = (firstNumber, secondNumber);
                GetEuclideanGCD(firstNumber, secondNumber, out TimeSpan firstAlgorithmTime);
                GetSteinitzGCD(firstNumber, secondNumber, out TimeSpan secondAlgorithmTime);
                timeOfAlgorithms[counter] = (firstAlgorithmTime, secondAlgorithmTime);

            }
            return (timeOfAlgorithms, valuesForGCD);
        }

        /// <summary>
        /// Метод получения НОД двух целых чисел методом Евклида.
        /// </summary>
        /// <param name="firstNumber"> Первое число для вычисления НОД.</param>
        /// <param name="secondNumber"> Второе число для вычисления НОД.</param>
        /// <param name="executionTime"> Время выполнения расчётов методом Евклида.</param>
        /// <returns>
        /// Возвращает НОД двух чисел и время, затраченное на расчёт НОД.
        /// В случае неккоректных параметров возвращает значение -1.
        /// </returns>
        public int GetEuclideanGCD(int firstNumber, int secondNumber, out TimeSpan executionTime)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            int result = FindEuclideanGCD(firstNumber, secondNumber);
            stopwatch.Stop();
            executionTime = stopwatch.Elapsed;
            return result;
        }

        /// <summary>
        /// Метод получение НОД двух целых чисел методом Стейница.
        /// </summary>
        /// <param name="firstNumber"> Первое число для вычисления НОД.</param>
        /// <param name="secondNumber"> Второе число для вычисления НОД.</param>
        /// <param name="executionTime"> Время выполнения расчётов методом Стейница.</param>
        /// <returns>
        /// Возвращает НОД двух чисел и время, затраченное на расчёт НОД.
        /// В случае неккоректных параметров возвращает значение -1.
        /// </returns>
        public int GetSteinitzGCD(int firstNumber, int secondNumber, out TimeSpan executionTime)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            int result = FindSteinitzGCD(firstNumber, secondNumber);
            stopwatch.Stop();
            executionTime = stopwatch.Elapsed;
            return result;
        }

        /// <summary>
        /// Метод вычисления НОД для нескольких целых чисел методом Евклида.
        /// </summary>
        /// <param name="numbers"> Массив значений для вычислениях НОД.</param>
        /// <returns>
        /// Возвращает НОД нескольких чисел.
        /// В случае неккоректных параметров возвращает значение -1.
        /// </returns>
        public int GetEuclideanGCD(params int[] numbers)
        {
            if (numbers.Length <= 1)
            {
                return -1;
            }
            var firstTwoNumbersGCD = FindEuclideanGCD(firstNumber: numbers[0], secondNumber: numbers[1]);
            for (int counter = 0; counter < numbers.Length - 2; counter++)
            {
                firstTwoNumbersGCD = FindEuclideanGCD(firstTwoNumbersGCD, numbers[counter + 2]);
            }
            return firstTwoNumbersGCD;
        }

        /// <summary>
        /// Метод вычисления НОД для двух целых чисел методом Евклида.
        /// </summary>
        /// <param name="firstNumber"> Первое число для вычисления НОД </param>
        /// <param name="secondNumber"> Первое число для вычисления НОД </param>
        /// <returns>
        /// Возвращает НОД двух чисел.
        /// В случае неккоректных входных параметров возвращается -1.
        /// </returns>
        private int FindEuclideanGCD(int firstNumber, int secondNumber)
        {
            if ((firstNumber < 0) || (secondNumber < 0))
            {
                return -1;
            }

            if (firstNumber == 0 || secondNumber == 0)
            {
                return 0;
            }

            while (firstNumber != 0 && secondNumber != 0)
            {
                if (firstNumber > secondNumber)
                {
                    firstNumber %= secondNumber;
                }
                else
                {
                    secondNumber %= firstNumber;
                }
            }
            var result = firstNumber + secondNumber;
            return result;
        }

        /// <summary>
        /// Метод вычисления НОД для двух целых чисел методом Стейница.
        /// </summary>
        /// <param name="firstNumber">Первое число для вычисления НОД.</param>
        /// <param name="secondNumber">Первое число для вычисления НОД.</param>
        /// <returns>
        /// Возвращает НОД двух целых чисел.
        /// В случае неккоректных входных параметров возвращается -1.
        /// </returns>
        private int FindSteinitzGCD(int firstNumber, int secondNumber)
        {
            if ((firstNumber < 0) || (secondNumber < 0))
            {
                return -1;
            }

            if ((firstNumber <= 0) || (secondNumber <= 0))
            {
                return 0;
            }

            if ((firstNumber == 1) || (secondNumber == 1))
            {
                return 1;
            }

            if (firstNumber == secondNumber)
            {
                return firstNumber;
            }

            if ((firstNumber & 1) == 0)
            {
                if ((secondNumber & 1) == 1)
                {
                    return FindSteinitzGCD(firstNumber / 2, secondNumber);
                }
                else
                {
                    return 2 * FindSteinitzGCD(firstNumber / 2, secondNumber / 2);
                }
            }

            if ((secondNumber & 1) == 0)
            {
                return FindSteinitzGCD(firstNumber, secondNumber / 2);
            }

            var differenceOFNumbers = Math.Abs(firstNumber - secondNumber) / 2;
            if (firstNumber > secondNumber)
            {
                return FindSteinitzGCD(differenceOFNumbers, secondNumber);
            }
            return FindSteinitzGCD(firstNumber, differenceOFNumbers);
        }

        #endregion
    }
}
