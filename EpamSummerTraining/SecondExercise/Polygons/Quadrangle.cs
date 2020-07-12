using System;
using System.Collections.Generic;
using System.Text;

namespace FirstTask.SecondExercise.Polygons
{
    class Quadrangle : PolygonFigure
    {

        public Quadrangle(double[] sideSizes) : base(sideSizes)
        { }

        public Quadrangle(Point[] points) : base(points)
        { }

        public override double GetAreaOfFigure()
        {
            throw new NotImplementedException();
        }

    }
}
