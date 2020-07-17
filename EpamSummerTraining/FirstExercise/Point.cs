

namespace SecondTask.FirstExercise
{
    using System;
    /// <summary>
    /// Класс представляет точку в трёхмерном пространстве.
    /// </summary>
    public class ThreeDimensionalPoint
    {
        #region Fields
        /// <summary>
        /// Координаты точки.
        /// </summary>
        private double[] _coordinates;

        #endregion

        #region Constructors

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

        #endregion

        #region Indexer
        public double this[int index]
        {
            get
            {
                return _coordinates[index];
            }
        }

        #endregion

        #region Properties

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

        #endregion

        #region Methods

        public override string ToString()
        {
            var coordinates = String.Join(',', _coordinates);
            return $"Point ({coordinates})";
        }

        #endregion

        #region Operations

        public static ThreeDimensionalPoint operator - (ThreeDimensionalPoint start, ThreeDimensionalPoint end)
        {
            return new ThreeDimensionalPoint(start[0] - end[0], start[1] - end[1], start[2] - end[2]);
        }

        #endregion

    }
}
