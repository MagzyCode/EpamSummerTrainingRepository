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

        //public override double GetPerimeterOfFigure()
        //{
        //    double perimeter = _sideSizes.Sum();
        //    return perimeter;
        //}
    }
}
