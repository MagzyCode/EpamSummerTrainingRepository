using FirstTask;
using System;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace EpamSummerTraining
{
    /// <summary>
    /// Класс, предназначенный для вычисления НОД(GCD) чисел с применением алгоритма Евклида
    /// </summary>
    public class EuclideanAlgorithm : IEuclideanAlgoritm
    {
        #region Constructors
        public EuclideanAlgorithm()
        { }

        #endregion

        #region Methods
        /// <summary>
        /// Метод получения НОД двух целых чисел методом Евклида
        /// </summary>
        /// <param name="firstNumber"> Первое число для вычисления НОД </param>
        /// <param name="secondNumber"> Второе число для вычисления НОД</param>
        /// <param name="executionTime"> Время, затраченное на выполнение расчётов </param>
        /// <returns></returns>
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
        /// Метод получение НОД двух целых чисел методом Стейница
        /// </summary>
        /// <param name="firstNumber"> Первое число для вычисления НОД </param>
        /// <param name="secondNumber"> Второе число для вычисления НОД </param>
        /// <param name="executionTime"> Время, затраченное на выполнение расчётов</param>
        /// <returns></returns>
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
        /// Метод вычисления НОД для нескольких целых чисел
        /// </summary>
        /// <param name="numbers"> Массив чисел для вычислениях их НОД </param>
        /// <returns></returns>
        public int FindEuclideanGCD(params int[] numbers)
        {
            if (numbers.Length <= 1)
            {
                return 0;
            }
            var firstTwoNumbersGCD = FindEuclideanGCD(firstNumber: numbers[0], secondNumber: numbers[1]);
            for (int counter = 0; counter < numbers.Length - 2; counter++)
            {
                firstTwoNumbersGCD = FindEuclideanGCD(firstTwoNumbersGCD, numbers[counter + 2]);
            }
            return firstTwoNumbersGCD;
        }

        /// <summary>
        /// Метод вычисления НОД для двух целых чисел методом Евклида
        /// </summary>
        /// <param name="firstNumber"> Первое число для вычисления НОД </param>
        /// <param name="secondNumber"> Первое число для вычисления НОД </param>
        /// <returns></returns>
        private int FindEuclideanGCD(int firstNumber, int secondNumber)
        {
            while (firstNumber != 0 && secondNumber != 0)
            {
                if (firstNumber > secondNumber)
                {
                    firstNumber %= secondNumber;
                }
                else
                {
                    secondNumber %= secondNumber;
                }
            }
            var result = firstNumber + secondNumber;
            return result;
        }

        /// <summary>
        /// Метод вычисления НОД для двух целых чисел методом Стейница
        /// </summary>
        /// <param name="firstNumber"> Первое число для вычисления НОД </param>
        /// <param name="secondNumber"> Первое число для вычисления НОД </param>
        /// <returns></returns>
        private int FindSteinitzGCD(int firstNumber, int secondNumber)
        {
            if ((firstNumber == 0) || (secondNumber == 0))
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
