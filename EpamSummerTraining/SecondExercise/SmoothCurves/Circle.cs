using System;
using System.Collections.Generic;
using System.Text;

namespace FirstTask.SecondExercise.SmoothCurves
{
    class Circle : Figure
    {
        private double _radius = default;

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

        public Circle(Point firstPoint, Point secondPoint)
        {
            _points = new Lazy<Point[]>(new Point[] { firstPoint, secondPoint });
            _sideSizes = GetSideSizesFromPoints();
            _radius = GetRadius();
        }

        public Circle(Point center, double raduis)
        {
            _points = new Lazy<Point[]>(new Point[] { center });
            _radius = raduis;
        }

        public override double GetAreaOfFigure()
        {
            var area = Math.PI * Math.Pow(_radius, 2);
            return area;
        }

        public override double GetPerimeterOfFigure()
        {
            var perimeter = 2 * Math.PI * _radius;
            return perimeter;
        }

        private double GetRadius()
        {
            double radius = Figure.GetLengthBetweenPoints(Points[0], Points[1]) / 2;
            return radius;
        }
    }
}
