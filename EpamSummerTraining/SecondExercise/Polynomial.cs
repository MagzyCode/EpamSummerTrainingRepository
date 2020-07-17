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
            for (int i = Degree - 1; i > 0; i--)
            {
                result.Append($"{Coefficients[i]}*x^{i+1}");
            }
            return result.ToString();
        }


        #endregion

        #region Operations

        public static Polynomial operator + (Polynomial firstValue, Polynomial secondValue)
        {
            (int maxDegree, int minDegree) = firstValue.Degree > secondValue.Degree
                ? (firstValue.Degree, secondValue.Degree)
                : (secondValue.Degree, firstValue.Degree);
            var result = new Polynomial(maxDegree);
            for (int i = 0; i < minDegree; i++)
            {
                result[i] = firstValue[i] + secondValue[i];
            }
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
            var remainder = dividend.Coefficients.Clone() as double[];
            var quotient = new double[dividend.Degree - divider.Degree + 1];
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
