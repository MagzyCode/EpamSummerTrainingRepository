using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace FirstTask.SecondExercise.SmoothCurves
{
    public class Circle : Figure
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

        public double Diameter
        {
            
            get
            {
                return 2 * _radius; 
            }
        }

        public Circle()
        { }


        public Circle(Point[] points)
        {
            _points = points;
            _sideSizes = GetSideSizesFromPoints();
            _radius = GetRadius();
        }

        public Circle(Point firstPoint, Point secondPoint)
        {
            _points = new Point[] { firstPoint, secondPoint };
            _sideSizes = GetSideSizesFromPoints();
            _radius = GetRadius();
        }

        public Circle(Point center, double raduis)
        {
            _points = new Point[] { center };
            _radius = raduis;
            _sideSizes = new double[] { _radius * 2 };
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
            double radius = _sideSizes[0] / 2;
            return radius;
        }
    }
}
