using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FirstTask.SecondExercise
{
    class Triangle : Polygons.PolygonFigure
    {
        
        public Triangle(double[] sideSizes) : base(sideSizes)
        { }

        public Triangle(Point[] points) : base(points) 
        { }

        public override double GetAreaOfFigure()
        {
            double halfOfPerimeter = GetPerimeterOfFigure() / 2;
            var tempResult = halfOfPerimeter * (halfOfPerimeter - SideSizes[0]) *
                    (halfOfPerimeter - SideSizes[1]) * (halfOfPerimeter - SideSizes[2]);
            var area = Math.Pow(tempResult, 0.5);
            return area;
        }
    }
}
