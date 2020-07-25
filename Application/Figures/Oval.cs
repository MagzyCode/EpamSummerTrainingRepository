using Application.Painting;
using System;

namespace Application.Figures
{
    public class Oval : Figure, ISpecificFigure
    {
        private readonly double _smallDiameter;
        private readonly double _bigDiameter;

        public Oval(ISpecificFigure figure, Point[] points) : base(figure, points)
        { }

        /// <summary>
        /// Конструктор создания фигуры "Овал", использую массив точек и материал.
        /// </summary>
        /// <param name="material">Материал фигуры.</param>
        /// <param name="points">Точки прямоугольника, в который вписывается овал.</param>
        public Oval(FigureMaterial material, Point[] points) : base(points, material)
        {
            // Points = points;
            // SideSizes = GetSideSizesFromPoints();
            _bigDiameter = SideSizes[0];
            _smallDiameter = SideSizes[1];
            
        }

        /// <summary>
        /// Конструктор создания овала, использующий центральную 
        /// точку, значения перпендикулярных радиусов и материал.
        /// </summary>
        /// <param name="material">Материал фигуры./param>
        /// <param name="centerPoint">Точка-центр овала.</param>
        /// <param name="smallRadius">Малый радиус овала.</param>
        /// <param name="bigRadius">Большой радиус овала.</param>
        public Oval(FigureMaterial material, Point centerPoint, double smallRadius, double bigRadius)
                : base(material)
        {
            Points = new Point[] { centerPoint };
            _smallDiameter = smallRadius;
            _bigDiameter = bigRadius;
            _sideSizes = new double[] { _smallDiameter, _bigDiameter };
        }

        public override double GetArea()
        {
            var area = Math.PI * _smallDiameter * _bigDiameter;
            return area;
        }

        public override double GetPerimeter()
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
        public override double[] GetSideSizesFromPoints()
        {
            var (xDifferenct, yDifference) = (_bigDiameter, _smallDiameter);
               // .GetDifferenceOfAxis(Points[0], Points[1]);
            if (xDifferenct > yDifference)
            {
                return new double[] { xDifferenct, yDifference };
            }
            else
            {
                return new double[] { yDifference, xDifferenct };
            }
        }

    }
}
