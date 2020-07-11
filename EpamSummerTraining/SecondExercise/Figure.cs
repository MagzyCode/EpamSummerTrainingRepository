using System;
using System.Collections.Generic;
using System.Text;

namespace FirstTask.SecondExercise
{
    public abstract class Figure
    {
        private protected Lazy<Point[]> _points = default;
        private protected Lazy<double[]> _sideSizes = default;

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

        public Figure(params Point[] points)
        {
            _points = new Lazy<Point[]>(points);
        }

        public Figure(params double[] sideSizes)
        {
            _sideSizes = new Lazy<double[]>(sideSizes);
        }

        public abstract double GetAreaOfFigure();

        public abstract double GetPerimeterOfFigure();

    }
}
