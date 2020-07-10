using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace EpamSummerTraining
{
    /// <summary>
    /// Класс, предназначенный для вычисления НОД(GCD) чисел с применением алгоритма Евклида
    /// </summary>
    public static class EuclideanAlgorithm
    {
        #region IfClassNotStatic
        // private readonly int[] numbers = default;

        // public EuclideanAlgorithm()
        // { }

        // public EuclideanAlgorithm(params int[] numbers)
        // {
        //     this.numbers = numbers;
        // }
        #endregion


        public static int FindGCD(int firstNumber, int secondNumber)
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
        
        public static int FindGCD(params int[] numbers)
        {
            if (numbers.Length <= 1)
            {
                return 0;
            }
            var firstTwoNumbersGCD = FindGCD(firstNumber: numbers[0], secondNumber: numbers[1]);
            for (int counter = 0; counter < numbers.Length - 2; counter++)
            {
                firstTwoNumbersGCD = FindGCD(firstTwoNumbersGCD, numbers[counter + 2]);
            }
            return firstTwoNumbersGCD;
        }



    }
}
