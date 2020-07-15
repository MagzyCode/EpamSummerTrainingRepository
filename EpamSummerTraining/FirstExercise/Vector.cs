

using System;
using System.Collections.Generic;
using System.Linq;

namespace SecondTask.FirstExercise
{
    /// <summary>
    /// Класс Vector предоставляет возможность работы с трехмерными векторами.
    /// </summary>
    public class Vector
    {
        #region Fields

        /// <summary>
        /// Координаты вектора
        /// </summary>
        private readonly double[] _coodinates;

        #endregion

        #region Properties

        /// <summary>
        /// Возврашает длину вектора в пространстве.
        /// </summary>
        public double Module
        { 
            get
            {
                return GetModule();
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Инициализация объекта типа Vector, использующая две точки в пространстве.
        /// </summary>
        /// <param name="startPoint">Начальная точка вектора.</param>
        /// <param name="endPoint">Конечная точка вектора.</param>
        public Vector(ThreeDimensionalPoint startPoint, ThreeDimensionalPoint endPoint)
        {
            _coodinates = new double[] 
            { 
                (endPoint.Coordinates[0] - startPoint.Coordinates[0]),
                (endPoint.Coordinates[1] - startPoint.Coordinates[1]),
                (endPoint.Coordinates[2] - startPoint.Coordinates[2])
            };
        }

        /// <summary>
        /// Инициализация объект типа Vector, использующая значения координат вектора
        /// </summary>
        /// <param name="xCoordinate"></param>
        /// <param name="yCoordinate"></param>
        /// <param name="zCoordinate"></param>
        public Vector(double xCoordinate, double yCoordinate, double zCoordinate)
        {
            _coodinates = new double[] { xCoordinate, yCoordinate, zCoordinate };
        }

        #endregion

        #region Indexer

        /// <summary>
        /// Индексатор, обращающийся к значениям координат вектора.
        /// </summary>
        /// <param name="index">Индекс обращения к координате вектора.</param>
        /// <returns>Возвращает координату вектора. При обращению по 
        /// индексу за границами значений, вызывается IndexOutOfRangeException.
        /// </returns>
        public double this[int index]
        {
            get
            {
                return _coodinates[index];
            }
        }

        #endregion

        #region Operations

        public static Vector operator + (Vector first, Vector second)
        {
            return new Vector(second[0] + first[0], second[1] + first[1], second[2] + first[2]);
        }

        public static Vector operator - (Vector first, Vector second)
        {
            return new Vector(first[0] - second[0], first[1] - second[1], first[1] - second[1]);
        }

        public static Vector operator * (Vector vector, int number)
        {
            return new Vector(vector[0] * number, vector[1] * number, vector[1] * number);
        }

        public static Vector operator * (Vector first, Vector second)
        {
            var xValue = first[1] * second[2] - first[2] * second[1];
            var yValue = first[2] * second[0] - first[0] * second[2];
            var zValue = first[0] * second[1] - first[1] * second[0];
            return new Vector(xValue, yValue, zValue);
        }

        public static bool operator == (Vector first, Vector second)
        {
            bool areCollinear = AreVectorsCollinear(first, second);
            var areModulesEquals = first.Module == second.Module;
            var result = areCollinear && areModulesEquals ? true : false;
            return result;
        }

        public static bool operator != (Vector first, Vector second)
        {
            bool areCollinear = AreVectorsCollinear(first, second);
            var areModulesEquals = first.Module == second.Module;
            var result = areCollinear && areModulesEquals ? false : true;
            return result;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Метод получает длину вектора.
        /// </summary>
        /// <returns>Возвращает длину вектора.</returns>
        private double GetModule()
        {
            var rootValue = Math.Pow(_coodinates[0], 2) + Math.Pow(_coodinates[1], 2) +
                    Math.Pow(_coodinates[2], 2); 
            var module = Math.Pow(rootValue ,0.5);
            return module;
        }

        public override string ToString()
        {
            var vector = String.Join(',', _coodinates);
            return $"({vector})";
        }

        public override bool Equals(object obj)
        {
            return this == (obj as Vector);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this);
        }

        /// <summary>
        /// Метод сравнения двух векторов на ортогональность (перпендикулярность).
        /// </summary>
        /// <param name="firstVector">Первый вектор.</param>
        /// <param name="secondVector">Второй вектор.</param>
        /// <returns>Возвращает bool, в случае ортогональности векторов, возвращается true</returns>
        public static bool AreVectorsOrthogonal(Vector firstVector, Vector secondVector)
        {
            var calculation = secondVector[0] * firstVector[0] + secondVector[1] * firstVector[1] + 
                    secondVector[2] * firstVector[2];
            var result = calculation == 0 ? true : false;
            return result;
        }

        /// <summary>
        /// Метод сравнения двух векторов на коллинеарность (параллельность).
        /// </summary>
        /// <param name="firstVector">Первый вектор.</param>
        /// <param name="secondVector">Второй вектор.</param>
        /// <returns></returns>
        public static bool AreVectorsCollinear(Vector firstVector, Vector secondVector)
        {
            var firstCalculation = firstVector[0] / secondVector[0]; 
            var secondCalculation = firstVector[1] / secondVector[1];
            var thirdCalculation = firstVector[2] / secondVector[2];
            if (firstCalculation == secondCalculation && secondCalculation == thirdCalculation)
            {
                return true;
            }
            return false;
        }

        public static double GetScalarMultiplication(Vector first, Vector second)
        {
            var result = first[0] * second[0] + first[2] * second[2] + first[2] * second[2];
            return result;
        }

        public static double GetVectorialMultiplication(Vector first, Vector second)
        {
            var result = first[0] * second[0] + first[2] * second[2] + first[2] * second[2];
            return result;
        }


        #endregion
    }
}
