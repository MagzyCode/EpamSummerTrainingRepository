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

        /// <summary>
        /// Конструктор создания "точки" в плоскости с заданными
        /// значениями x и y соотвественно.
        /// </summary>
        /// <param name="xPoint">Значение точки относительно оси ОX</param>
        /// <param name="yPoint">Значение точки относительно оси ОY</param>
        public Point(double xPoint, double yPoint)
        {
            OrdinateAxisValue = yPoint;
            AbscissaAxisValue = xPoint;
        }

        /// <summary>
        /// Статическмй метод по созданию массива точек из массива значений x и y.
        /// </summary>
        /// <param name="values">Массив координат точек, каждая пара значений - точка.</param>
        /// <returns>Возвращает массив точек</returns>
        public static Point[] GetPointsFromArray(double[] values)
        {
            var list = new List<Point>();
            for (int counter = 0; counter < values.Length; counter += 2)
            {
                list.Add(new Point(values[counter], values[counter + 1]));
            }
            var points = list.ToArray();
            return points;
        }

        public override string ToString()
        {
            return  $"({AbscissaAxisValue}, {OrdinateAxisValue})";
        }
    }
}
