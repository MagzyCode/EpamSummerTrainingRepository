using Application.Painting;
using System;

namespace Application.Figures
{
    public class Oval : Figure, ISpecificFigure
    {
        private readonly double _smallDiameter = default;
        private readonly double _bigDiameter = default;

        /// <summary>
        /// Конструктор создания фигуры "Овал", использую массив точек.
        /// </summary>
        /// <param name="points">Точки прямоугольника, в который вписывается овал</param>
        public Oval(Point[] points)
        {
            _points = points;
            _sideSizes = GetOvalSides();
            _smallDiameter = _sideSizes[1];
            _bigDiameter = _sideSizes[0];
        }

        /// <summary>
        /// Конструктор создания овала, использующий центральную 
        /// точку и значения перпендикулярных радиусов.
        /// </summary>
        /// <param name="centerPoint">Точка-центр овала.</param>
        /// <param name="smallRadius">Малый радиус овала.</param>
        /// <param name="bigRadius">Большой радиус овала.</param>
        public Oval(Point centerPoint, double smallRadius, double bigRadius)
        {
            _points = new Point[] { centerPoint };
            _smallDiameter = smallRadius;
            _bigDiameter = bigRadius;
            _sideSizes = new double[] { _smallDiameter, _bigDiameter };
        }

        public FigureColor ColorOfFigure { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public double GetArea()
        {
            var area = Math.PI * _smallDiameter * _bigDiameter;
            return area;
        }

        public double GetPerimeter()
        {
            var rootPartOfFormula = (_bigDiameter * _bigDiameter +
                    _smallDiameter * _smallDiameter) / 8;
            var perimeter = 2 * Math.PI * Math.Pow(rootPartOfFormula, 0.5);
            return perimeter;
        }

        /// <summary>
        /// Преобразует значения точек в свойстве Points в малый и большой радиусы овала.
        /// </summary>
        /// <returns>Возвращает массив сторон(диаметров) овала</returns>
        private double[] GetOvalSides()
        {
            var axisValues = Point.GetDifferenceOfAxis(Points[0], Points[1]);
            if (axisValues.xDifferenct > axisValues.yDifference)
            {
                return new double[] { axisValues.xDifferenct, axisValues.yDifference };
            }
            else
            {
                return new double[] { axisValues.yDifference, axisValues.xDifferenct };
            }
        }

    }
}
