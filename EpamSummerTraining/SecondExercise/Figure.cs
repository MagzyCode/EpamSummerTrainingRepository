using System;
using System.Collections.Generic;
using System.Text;

namespace FirstTask.SecondExercise
{
    public abstract class Figure
    {
        private protected Lazy<Point[]> _points = new Lazy<Point[]>();
        private protected Lazy<double[]> _sideSizes = new Lazy<double[]>();

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
                return _sideSizes.Value;
            }
        }

        public Figure() 
        { }

        public Figure (Point[] points)
        {
            _points = new Lazy<Point[]>(points);
            // var sideSizes = func?.Invoke();
            // _sideSizes = new Lazy<double[]>(sideSizes);
        }

        public Figure (double[] sideSizes)
        {
            _sideSizes = new Lazy<double[]>(sideSizes);
        }

        public abstract double GetAreaOfFigure();

        public abstract double GetPerimeterOfFigure();

        private protected virtual double[] GetSideSizes()
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

    }
}
