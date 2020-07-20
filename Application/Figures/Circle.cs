using Application.Painting;
using System;

namespace Application.Figures
{
    public class Circle : Figure, ISpecificFigure
    {
        /// <summary>
        /// Значение радиуса круга
        /// </summary>
        private double _radius;


        public Circle()
        { }

        /// <summary>
        /// Инициализирует сущность Circle, использую точки произвольной линии
        /// в качестве диаметра круга.
        /// </summary>
        /// <param name="points">Точки произвольной линии, берущейся в качестве диаметра круга</param>
        public Circle(Point[] points)
        {
            _points = points;
            _sideSizes = GetSideSizesFromPoints();
            _radius = GetRadius();
        }

        /// <summary>
        /// Инициализирует сущность Circle, используя точку в качестве центра круга,
        /// также инициализируя его радиус
        /// </summary>
        /// <param name="center">Центральная точка круга</param>
        /// <param name="raduis">Радиус круга</param>
        public Circle(Point center, double raduis)
        {
            _points = new Point[] { center };
            _radius = raduis;
            _sideSizes = new double[] { _radius * 2 };
        }


        /// <summary>
        /// Значение радиуса круга
        /// </summary>
        public double Radius
        {
            private get
            {
                return _radius;
            }
            set
            {
                if (value > 0)
                {
                    _radius = value;
                }
            }
        }

        /// <summary>
        /// Значение диаметра круга
        /// </summary>
        public double Diameter
        {
            get
            {
                return 2 * _radius;
            }
        }

        public FigureColor ColorOfFigure { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public double GetArea()
        {
            var area = Math.PI * Math.Pow(_radius, 2);
            return area;
        }

        public double GetPerimeter()
        {
            var perimeter = 2 * Math.PI * _radius;
            return perimeter;
        }

        /// <summary>
        /// Метод получения радиуса, использующий значение диагонали
        /// </summary>
        /// <returns>Получает радиус круга из его диаметра</returns>
        private double GetRadius()
        {
            double radius = _sideSizes[0] / 2;
            return radius;
        }
    }
}
