using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks.Sources;

namespace SecondTask.SecondExercise
{
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
            return base.ToString();
        }


        #endregion

        #region Operations

        public static Polynomial operator + (Polynomial firstValue, Polynomial secondValue)
        {
            var maxDegree = Math.Max(firstValue.Degree, secondValue.Degree);
            var result = new Polynomial(maxDegree);
            var minDegree = Math.Min(firstValue.Degree, secondValue.Degree);
            for (int i = 0; i < minDegree; i++)
            {
                result[i] = firstValue[i] + secondValue[i];
            }
            return result;
        }

        #endregion

    }
}
