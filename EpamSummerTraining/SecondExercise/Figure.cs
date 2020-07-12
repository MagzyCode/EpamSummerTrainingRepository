using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FirstTask.SecondExercise
{
    public abstract class Figure
    {
        private protected Lazy<Point[]> _points = new Lazy<Point[]>();
        private protected double[] _sideSizes = default;

        public Point[] Points 
        {
            get
            {
                return _points.Value;
            }
        }

        public double[] SideSizes
        {
            get
            {
                return _sideSizes;
            }
        }

        public Figure() 
        { }

        public Figure (Point[] points)
        {
            _points = new Lazy<Point[]>(points);
        }

        public Figure (double[] sideSizes)
        {
            _sideSizes = sideSizes;
        }

        public abstract double GetAreaOfFigure();
        public abstract double GetPerimeterOfFigure();
        public double[] GetSideSizesFromPoints()
        {
            var listOfSides = new List<double>();
            for (int counter = 0; counter < Points.Length - 1; counter++)
            {
                double side = GetLengthBetweenPoints(Points[counter], Points[counter + 1]);
                listOfSides.Add(side);
            }
            var arrayOfSides = listOfSides.ToArray();
            return arrayOfSides;
        }

        public static double GetLengthBetweenPoints(Point startPoint, Point finishPoint)
        {
            var differenceAxisOrdinate = Math.Pow(startPoint.OrdinateAxisValue -
                    finishPoint.OrdinateAxisValue, 2);
            var differenceAxisAbscissa = Math.Pow(startPoint.AbscissaAxisValue -
                finishPoint.AbscissaAxisValue, 2);
            var side = Math.Pow(differenceAxisAbscissa + differenceAxisOrdinate, 0.5);
            return side;
        }
    }
}
