namespace SecondTask.SecondExercise
{
    using System;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Класс представляет собой полином n-ой степени от одной переменной.
    /// </summary>
    public class Polynomial
    {
        #region Fields

        /// <summary>
        /// Коэффициенты полинома по возрастанию.
        /// </summary>
        private double[] _coefficients;

        #endregion

        #region Constructors

        /// <summary>
        /// Инициализирует объект типа Polynomial,
        /// используя старшую степень полинома.
        /// </summary>
        /// <param name="degree">Степень старшего члена.
        /// При попытке ввести отрицательное число или 0 будет
        /// вызвано исключение ArgumentOutOfRangeException.</param>
        public Polynomial(int degree)
        {
            _coefficients = degree < 0 ? throw new ArgumentOutOfRangeException() : new double[degree];
        }

        /// <summary>
        /// Инициализирует объект типа Polynomial,
        /// используя коэффициенты полинома.
        /// </summary>
        /// <param name="coefficients">Коэффициенты полинома. При попытке
        /// ввести значение null будет вызвано исключение NullReferenceException</param>
        public Polynomial(params double[] coefficients)
        {
            Coefficients = coefficients;
        }

        #endregion

        #region Indexer

        public double this[int index]
        {
            get
            {
                return _coefficients[index];
            }

            set
            {
                _coefficients[index] = value;
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// Степень полинома
        /// </summary>
        public int Degree
        {
            get
            {
                return _coefficients.Length;
            }
        }

        /// <summary>
        /// Коэффициенты полинома по возрастанию.
        /// При попытке присвоения null, будет вызвано
        /// исключение NullReferenceException.
        /// </summary>
        public double[] Coefficients
        {
            get
            {
                return _coefficients.Clone() as double[];
            }

            set
            {
                if (value != null)
                {
                    GetCorrectCoefficients(ref value);
                    _coefficients = value;
                }
                else
                {
                    throw new NullReferenceException("Нельзя присвоить коэффициентам полинома null");
                }
            }
        }


        #endregion

        #region Methods
        
        public override int GetHashCode()
        {
            return HashCode.Combine(this);
        }

        public override bool Equals(object obj)
        {
            if (obj is Polynomial polynomial)
            {
                return this == polynomial;
            }
            return false;
        }

        /// <summary>
        /// Метод по сокращению полинома, в случае нулевых
        /// значений старших коэффициентов.
        /// </summary>
        /// <param name="coefficients">Коэффициенты полинома.</param>
        private static void GetCorrectCoefficients(ref double[] coefficients)
        {
            coefficients = coefficients.Reverse().ToArray();
            var counterOfZeros = 0;
            for (; counterOfZeros < coefficients.Length; counterOfZeros++)
            {
                if (coefficients[counterOfZeros] != 0)
                {
                    break;
                }
            }
            coefficients = coefficients.Skip(counterOfZeros).Reverse().ToArray();    
        }

        #endregion

        #region Operations

        public static Polynomial operator + (Polynomial firstValue, Polynomial secondValue)
        {
            (Polynomial minValue, Polynomial maxValue) = firstValue > secondValue
                    ? (secondValue, firstValue)
                    : (firstValue, secondValue);
            var arrayOfCoefficients = new double[maxValue.Degree];
            for (int i = 0; i < maxValue.Degree; i++)
            {
                if (i >= minValue.Degree)
                {
                    arrayOfCoefficients[i] = maxValue[i];
                }
                else
                {
                    arrayOfCoefficients[i] = minValue[i] + maxValue[i];
                }
            }
            GetCorrectCoefficients(ref arrayOfCoefficients);
            var result = new Polynomial(arrayOfCoefficients);
            return result;
        }

        public static Polynomial operator -(Polynomial firstValue, Polynomial secondValue)
        {
            return firstValue + (secondValue * -1);
        }

        /// <summary>
        /// Сравнение двух полиномов по их старшей степени.
        /// </summary>
        /// <param name="left">Левый операнд.</param>
        /// <param name="right">Правый операнд.</param>
        /// <returns>Возвращает bool.</returns>
        public static bool operator > (Polynomial left, Polynomial right)
        {
            var result = left.Degree > right.Degree;
            return result;
        }

        /// <summary>
        /// Сравнение двух полиномов по их старшей степени.
        /// </summary>
        /// <param name="left">Левый операнд.</param>
        /// <param name="right">Правый операнд.</param>
        /// <returns>Возвращает bool.</returns>
        public static bool operator < (Polynomial left, Polynomial right)
        {
            var result = !(left > right);
            return result;
        }

        /// <summary>
        /// Сравнение двух полином по средству
        /// сравнения их коэффициентов.
        /// </summary>
        /// <param name="left">Левый операнд.</param>
        /// <param name="right">Правый операнд.</param>
        /// <returns>Возращает true в случае равенства двух полиномов. Если 
        /// один из элементов равен null результатом вернется false.</returns>
        public static bool operator == (Polynomial left, Polynomial right)
        {
            var result = Enumerable.SequenceEqual(left.Coefficients, right.Coefficients);
            return result;
        }

        /// <summary>
        /// Сравнение двух полином по средству
        /// сравнения их коэффициентов.
        /// </summary>
        /// <param name="left">Левый операнд.</param>
        /// <param name="right">Правый операнд.</param>
        /// <returns>Возращает true в случае равенства двух полиномов. Если 
        /// один из элементов равен null результатом вернется false.</returns>
        public static bool operator != (Polynomial left, Polynomial right)
        {
            return !(left == right);
        }

        public static Polynomial operator * (Polynomial value, double number)
        {
            var arrayOfCoefficients = new double[value.Degree];
            for (int i = 0; i < value.Degree; i++)
            {
                arrayOfCoefficients[i] = value[i] * number;
            }
            var result = new Polynomial(arrayOfCoefficients);
            return result;
        }

        public static Polynomial operator * (double number, Polynomial value)
        {
            return value * number;
        }

        public static Polynomial operator * (Polynomial firstValue, Polynomial secondValue)
        {
            double[] arrayOfCoefficients = new double[firstValue.Degree + secondValue.Degree - 1];
            for (int i = 0; i < firstValue.Degree; ++i)
            {
                for (int j = 0; j < secondValue.Degree; ++j)
                {
                    arrayOfCoefficients[i + j] += firstValue[i] * secondValue[j];
                }
            }
            var result = new Polynomial(arrayOfCoefficients);
            return result;
        }

        /// <summary>
        /// Операция деления полиномов с остатком.
        /// </summary>
        /// <param name="dividend">Полином, на который делят.</param>
        /// <param name="divider">Полином, который делит.</param>
        /// <returns>Возвращает результат деления и остаток от него соответственно.
        /// В случае невозможности деления вызывается исключение ArithmeticException.
        /// </returns>
        public static (Polynomial quotient, Polynomial remainder) operator / (Polynomial dividend, Polynomial divider)
        {
            if (dividend.Degree < divider.Degree)
            {
                throw new ArithmeticException("Степень делителя не может быть больше степени делимого");
            }

            var remainder = dividend.Coefficients.Clone() as double[];
            var quotient = new double[remainder.Length - divider.Degree + 1];
            for (int i = 0; i < quotient.Length; i++)
            {
                double coefficients = remainder[remainder.Length - i - 1] / divider.Coefficients.Last();
                quotient[quotient.Length - i - 1] = coefficients;
                for (int j = 0; j < divider.Degree; j++)
                {
                    remainder[remainder.Length - i - j - 1] -= coefficients * divider[divider.Degree - j - 1];
                }
            }
            var quotientOfPolynomial = new Polynomial(quotient);
            var remainderOfPolynomial = new Polynomial(remainder);
            return (quotientOfPolynomial, remainderOfPolynomial);
        }

        #endregion

    }
}
