using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FirstTask.SecondExercise
{
    public class Triangle : Figure
    {
        /// <summary>
        /// Инициализирует объект типа Triangle, используя значения сторон.
        /// </summary>
        /// <param name="sideSizes">Массив сторон треугольника</param>
        public Triangle(double[] sideSizes) : base(sideSizes)
        { }

        /// <summary>
        /// Инициализирует объект типа Triangle, используя вершины треугольника.
        /// </summary>
        /// <param name="points"></param>
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

        public override double GetPerimeterOfFigure()
        {
            double perimeter = _sideSizes.Sum();
            return perimeter;
        }
    }
}
