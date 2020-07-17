using System;
using System.Collections.Generic;
using System.Text;

namespace SecondTask.SecondExercise
{
    public class Polynomial
    {
        #region Fields

        /// <summary>
        /// Коэффициенты полинома по возрастанию.
        /// </summary>
        private readonly double[] _coefficients;

        #endregion

        #region Constructors

        /// <summary>
        /// Коэффициенты полинома по возрастанию.
        /// </summary>
        public double[] Coefficients
        {
            get
            {
                return _coefficients.Clone() as double[];
            }
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


        #endregion

        #region Methods

        public override string ToString()
        {
            return base.ToString();
        }


        #endregion

        #region Operations

        public 

        #endregion

    }
}
