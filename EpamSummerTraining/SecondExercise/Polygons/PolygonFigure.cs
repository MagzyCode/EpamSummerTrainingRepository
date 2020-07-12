using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FirstTask.SecondExercise.Polygons
{
    public abstract class PolygonFigure : Figure
    {
        public PolygonFigure()
        { }

        public PolygonFigure(double[] sideSizes) : base(sideSizes) 
        { }

        public PolygonFigure(Point[] points) : base(points) 
        {
            _sideSizes = GetSideSizesFromPoints();
        }

        public override double[] GetSideSizesFromPoints()
        {
            var listOfSides = new List<double>();
            for (int counter = 1; counter < Points.Length - 1; counter++)
            {
                var differenceAxisOrdinate = Math.Pow(Points[counter].OrdinateAxisValue -
                    Points[counter + 1].OrdinateAxisValue, 2);
                var differenceAxisAbscissa = Math.Pow(Points[counter].AbscissaAxisValue -
                    Points[counter + 1].AbscissaAxisValue, 2);
                var side = Math.Pow(differenceAxisAbscissa + differenceAxisOrdinate, 0.5);
                listOfSides.Add(side);
            }
            var arrayOfSides = listOfSides.ToArray();
            return arrayOfSides;
        }

        public override double GetPerimeterOfFigure()
        {
            double perimeter = _sideSizes.Sum();
            return perimeter;
        }
    }
}
