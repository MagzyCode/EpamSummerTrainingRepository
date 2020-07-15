using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace SecondTask.FirstExercise
{
    /// <summary>
    /// Класс представляет точку в трёхмерном пространстве.
    /// </summary>
    public class ThreeDimensionalPoint
    {
        /// <summary>
        /// Координаты точки.
        /// </summary>
        private double[] _coordinates;

        /// <summary>
        /// Координаты точки.
        /// </summary>
        public double[] Coordinates
        {
            get
            {
                return _coordinates.Clone() as double[];
            }
        }

        /// <summary>
        /// Инициализация типа ThreeDimensionalPoint, используя значения 
        /// по осям OX, OY, OZ соответственно.
        /// </summary>
        /// <param name="xAxis">Значение по оси OX.</param>
        /// <param name="yAxis">Значения по оси ОY.</param>
        /// <param name="zAxis">Значение по оси OZ.</param>
        public ThreeDimensionalPoint(double xAxis, double yAxis, double zAxis)
        {
            _coordinates = new double[] { xAxis, yAxis, zAxis };
        }

        public double this[int index]
        {
            get
            {
                return _coordinates[index];
            }
        }

        public static ThreeDimensionalPoint operator - (ThreeDimensionalPoint start, ThreeDimensionalPoint end)
        {
            return new ThreeDimensionalPoint(start[0] - end[0], start[1] - end[1], start[2] - end[2]);
        }

        public override string ToString()
        {
            var coordinates = String.Join(',', _coordinates);
            return $"Point ({coordinates})";
        }


    }
}
