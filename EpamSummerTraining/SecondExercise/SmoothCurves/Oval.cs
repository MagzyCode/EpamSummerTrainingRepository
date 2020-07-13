using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace FirstTask.SecondExercise.SmoothCurves
{
    public class Oval : Figure
    {
        private double _smallDiameter = default;
        private double _bigDiameter = default;

        public Oval(Point[] points)
        {
            _points = points;
            _sideSizes = GetOvalSides();
            _smallDiameter = _sideSizes[1];
            _bigDiameter = _sideSizes[0];
        }

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
