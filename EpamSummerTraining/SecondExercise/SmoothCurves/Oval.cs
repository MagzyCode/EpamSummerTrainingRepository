using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace FirstTask.SecondExercise.SmoothCurves
{
    public class Oval : Figure
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


        public override double GetAreaOfFigure()
        {
            var area = Math.PI * _smallDiameter * _bigDiameter;
            return area;
        }

        public override double GetPerimeterOfFigure()
        {
            var perimeter = Math.PI * (_smallDiameter + _bigDiameter);
            return perimeter;
        }

        /// <summary>
        /// Преобразует значения точек в свойстве Points в малый и большой радиусы овала.
        /// </summary>
        /// <returns>Возвращает массив сторон(диаметров) овала</returns>
        private double[] GetOvalSides()
        {
            var sides = new double[]
            {
                Math.Abs(Points[1].AbscissaAxisValue - Points[0].AbscissaAxisValue),
                Math.Abs(Points[1].OrdinateAxisValue - Points[0].OrdinateAxisValue),
            };
            return sides;
        }

    }
}
