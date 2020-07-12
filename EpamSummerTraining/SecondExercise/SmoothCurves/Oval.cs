using System;
using System.Collections.Generic;
using System.Text;

namespace FirstTask.SecondExercise.SmoothCurves
{
    public class Oval : Figure
    {
        private double _smallDiameter = default;
        private double _bigDiameter = default;

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

    }
}
