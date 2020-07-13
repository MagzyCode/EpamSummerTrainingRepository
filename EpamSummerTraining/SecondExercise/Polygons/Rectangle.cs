using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FirstTask.SecondExercise.Polygons
{
    public class Rectangle : Figure
    {
        /// <summary>
        /// Инициализирует объект типа Quadrangle, используя значения сторон прямоугольника
        /// </summary>
        /// <param name="sideSizes">Значения сторон прямоугольника</param>
        public Rectangle(double[] sideSizes) : base(sideSizes)
        { }

        /// <summary>
        /// Инициализирует объект типа Quadrangle, используя 
        /// значения верхней левой и правой нижней вершины.
        /// </summary>
        /// <param name="sideSizes">Значения сторон прямоугольника</param>
        public Rectangle(Point[] points) : base(points)
        { }

        public override double GetAreaOfFigure()
        {
            double area = SideSizes[0] * SideSizes[1];
            return area;
        }

        public override double GetPerimeterOfFigure()
        {
            double perimeter = _sideSizes.Sum() * 2;
            return perimeter;
        }
    }
}
