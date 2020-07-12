using System;
using System.Collections.Generic;
using System.Text;

namespace FirstTask.SecondExercise
{
    public class Point
    {
        /// <summary>
        /// Значение точки на оси OY
        /// </summary>
        public double OrdinateAxisValue { get; set; }
        /// <summary>
        /// Значение точки на оси OX
        /// </summary>
        public double AbscissaAxisValue { get; set; }

        public Point(double xPoint, double yPoint)
        {
            OrdinateAxisValue = yPoint;
            AbscissaAxisValue = xPoint;
        }

        public override string ToString()
        {
            return  $"({AbscissaAxisValue}, {OrdinateAxisValue})";
        }
    }
}
