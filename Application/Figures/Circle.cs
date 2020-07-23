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

        public Circle(ISpecificFigure figure, Point[] points) : base(figure, points)
        { }

        /// <summary>
        /// Инициализирует сущность Circle, использую точки произвольной линии
        /// в качестве диаметра круга.
        /// </summary>
        /// <param name="points">Точки произвольной линии, берущейся в качестве диаметра круга</param>
        public Circle(FigureMaterial material, Point[] points) : base(points, material)
        {
            Radius = GetRadius();
        }

        /// <summary>
        /// Инициализирует сущность Circle, используя точку в качестве центра круга,
        /// также инициализируя его радиус
        /// </summary>
        /// <param name="center">Центральная точка круга</param>
        /// <param name="raduis">Радиус круга</param>
        public Circle(FigureMaterial material, Point center, double raduis) : base(material)
        {
            Points = new Point[] { center };
            Radius = raduis;
            SideSizes = new double[] { _radius * 2 };
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

        public override double GetArea()
        {
            var area = Math.PI * Math.Pow(Radius, 2);
            return area;
        }

        public override double GetPerimeter()
        {
            var perimeter = 2 * Math.PI * Radius;
            return perimeter;
        }

        /// <summary>
        /// Метод получения радиуса, использующий значение диагонали
        /// </summary>
        /// <returns>Получает радиус круга из его диаметра</returns>
        private double GetRadius()
        {
            double radius = SideSizes[0] / 2;
            return radius;
        }
    }
}
