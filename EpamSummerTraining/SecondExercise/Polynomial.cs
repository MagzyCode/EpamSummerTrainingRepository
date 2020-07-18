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

        public Polynomial(int degree)
        {
            _coefficients = degree < 0 ? throw new ArgumentOutOfRangeException() : new double[degree];
        }

        public Polynomial(params double[] coefficients)
        {
            GetCorrectCoefficients(ref coefficients);
            _coefficients = coefficients ?? throw new NullReferenceException();
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
                    _coefficients = value;
                }
            }
        }


        #endregion

        #region Methods

        public override string ToString()
        {
            var result = new StringBuilder();
            for (int i = Degree - 1; i >= 0; i--)
            {
                var additionString = i == 0
                        ? $"{Coefficients[i]}*x^{i + 1}+"
                        : $"{Coefficients[i]}*x^{i + 1}";
                result.Append(additionString);
            }
            return result.ToString();
        }

        public override bool Equals(object obj)
        {
            var polynomial = (obj as Polynomial);
            if (polynomial != null)
            {
                var result = Enumerable.SequenceEqual(this.Coefficients, polynomial.Coefficients);
                return result;
            }
            return false;
        }

        private static void GetCorrectCoefficients(ref double[] coefficients)
        {
            if (coefficients == null)
            {
                return;
            }

            coefficients = coefficients.Reverse().ToArray();
            var counterOfZerosDegree = 0;
            for (int i = 0; i < coefficients.Length; i++)
            {
                if (coefficients[i] != 0)
                {
                    break;
                }
                else
                {
                    counterOfZerosDegree++;
                }
            }
            coefficients = coefficients.Skip(counterOfZerosDegree).Reverse().ToArray();
           
        }

        #endregion

        #region Operations

        public static Polynomial operator + (Polynomial firstValue, Polynomial secondValue)
        {
            (Polynomial minValue, Polynomial maxValue) = firstValue > secondValue
                    ? (secondValue, firstValue)
                    : (firstValue, secondValue);
            var result = new Polynomial(maxValue.Degree);
            for (int i = 0; i < maxValue.Degree; i++)
            {
                if (i >= minValue.Degree)
                {
                    result[i] = maxValue[i];
                }
                else
                {
                    result[i] = minValue[i] + maxValue[i];
                }
            }
            return result;
        }

        public static bool operator > (Polynomial firstValue, Polynomial secondValue)
        {
            var result = firstValue.Degree > secondValue.Degree;
            return result;
        }

        public static bool operator < (Polynomial firstValue, Polynomial secondValue)
        {
            var result = !(firstValue > secondValue);
            return result;
        }

        public static Polynomial operator - (Polynomial firstValue, Polynomial secondValue)
        {
            return firstValue + (secondValue * -1);
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

        public static (Polynomial quotient, Polynomial remainder) operator / (Polynomial dividend, Polynomial divider)
        {
            if ((dividend.Coefficients.Last() == 0) || (divider.Coefficients.Last() == 0))
            {
                throw new ArithmeticException("Старший член многочлена делимого не может быть 0");
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
            GetCorrectCoefficients(ref remainder);
            var quotientOfPolynomial = new Polynomial(quotient);
            var remainderOfPolynomial = new Polynomial(remainder);
            return (quotientOfPolynomial, remainderOfPolynomial);
        }

        #endregion

    }
}
