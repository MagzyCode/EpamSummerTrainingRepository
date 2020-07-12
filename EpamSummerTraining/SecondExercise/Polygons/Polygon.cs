using System;
using System.Collections.Generic;
using System.Linq;

namespace FirstTask.SecondExercise.Polygons
{
    public class Polygon : PolygonFigure
    {
        private const int NUMBER_OF_MINIMUM_POINTS = 3;

        public Polygon(params Point[] points) : base(points)
        { }

        public Polygon(double[] sides) : base(sides)
        { }

        public override double GetAreaOfFigure()
        {
            if (_points.Length < NUMBER_OF_MINIMUM_POINTS)
            {
                return -1.0;
            }
            List<double> xValues = _points.Select(i => i.AbscissaAxisValue).
                Concat(new List<double>() { _points[0].AbscissaAxisValue}).
                ToList();
            List<double> yValues = _points.Select(i => i.OrdinateAxisValue).
                Concat(new List<double>() { _points[0].OrdinateAxisValue }).
                ToList();
            var firstCalculation = xValues.
                Take(xValues.Count - 1).
                Select(i => i * yValues[xValues.IndexOf(i) + 1]).
                Sum();
            var secondCalculation = yValues.
                Take(yValues.Count - 1).
                Select(i => i * xValues[yValues.IndexOf(i) + 1]).
                Sum();
            var result = (firstCalculation - secondCalculation) / 2;
            return result;
        }

        public override double GetPerimeterOfFigure()
        {
            double perimeter = _sideSizes.Sum();
            return perimeter;
        }
    }
}
