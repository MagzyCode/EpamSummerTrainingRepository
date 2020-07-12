using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FirstTask.SecondExercise
{
    public abstract class Figure
    {
        private protected Point[] _points = default;
        private protected double[] _sideSizes = default;

        public Point[] Points 
        {
            get
            {
                return _points;
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
            _points = points;
        }

        public Figure (double[] sideSizes)
        {
            _sideSizes = sideSizes;
        }

        public abstract double GetAreaOfFigure();
        public abstract double GetPerimeterOfFigure();
        public double[] GetSideSizesFromPoints()
        {
            double side = GetLengthBetweenPoints(_points[Points.Length - 1], _points[0]);
            var listOfSides = new List<double> { side };
            for (int counter = 0; counter < Points.Length - 1; counter++)
            {
                side = GetLengthBetweenPoints(_points[counter], _points[counter + 1]);
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

        public override string ToString()
        {
            string stringOfPoints = _points == null ? string.Empty : ("Points: " + String.Join<Point>(' ', _points));
            string stringOfSides = String.Join(' ', _sideSizes);
            return $" Type: {this.GetType().Name} \n Sides: {stringOfSides} \n {stringOfPoints}";
        }
    }
}
