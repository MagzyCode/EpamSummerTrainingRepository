using System;
using System.Collections.Generic;
using System.Text;

namespace FirstTask.SecondExercise.SmoothCurves
{
    class Oval : Figure
    {
        private double _smallDiameter = default;
        private double _bigDiameter = default;

        public Oval(Point centerPoint, double smallRadius, double bigRadius)
        {
            _points = new Lazy<Point[]>(new Point[] { centerPoint });
            _smallDiameter = smallRadius;
            _bigDiameter = bigRadius;
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

    }
}
