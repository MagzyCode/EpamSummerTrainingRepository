﻿using System;
using System.Collections.Generic;

namespace Application.Painting
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

        public override int GetHashCode()
        {
            return HashCode.Combine(this);
        }

        public override bool Equals(object obj)
        {
            if (obj is Point point)
            {
                return this == point;
            }
            return false;
        }

        public override string ToString()
        {
            return $"{AbscissaAxisValue},{OrdinateAxisValue}";
        }

        /// <summary>
        /// Статическмй метод по созданию массива точек из массива значений x и y.
        /// Если массив содержать нечётное или нулевое количество координат
        /// будет вызвано исключение Exception с соответствующим сообщением.
        /// </summary>
        /// <param name="values">Массив координат точек, каждая пара значений - точка.</param>
        /// <returns>Возвращает массив точек</returns>
        public static Point[] GetPointsFromArray(double[] values)
        {
            if ((values.Length == 0) || (values.Length % 2 == 1))
            {
                throw new Exception("Невозможно преобразовать данные в массив точек.");
            }

            var list = new List<Point>(values.Length / 2);
            for (int counter = 0; counter < values.Length; counter += 2)
            {
                list.Add(new Point(values[counter], values[counter + 1]));
            }
            var points = list.ToArray();
            return points;
        }

        /// <summary>
        /// Метод, по получению модуля разности осей OX, OY между точками.
        /// </summary>
        /// <param name="first">Первый точка.</param>
        /// <param name="second">Вторая точка.</param>
        /// <returns>Возращается модулей разности осей двух точек.</returns>
        public static (double xDifferenct, double yDifference) GetDifferenceOfAxis(Point first, Point second)
        {
            var yDifference = Math.Abs(first.OrdinateAxisValue - second.OrdinateAxisValue);
            var xDifference = Math.Abs(first.AbscissaAxisValue - second.AbscissaAxisValue);
            return (xDifference, yDifference);
        }


        /// <summary>
        /// Получает расстояние между двумя точками в пространстве.
        /// </summary>
        /// <param name="startPoint">Начальная точка отрезка.</param>
        /// <param name="finishPoint">Конечная точка отрезка.</param>
        /// <returns>Возвращает расстояние между точками.</returns>
        public static double GetLengthBetweenPoints(Point startPoint, Point finishPoint)
        {
            var (xDifferenct, yDifference) = GetDifferenceOfAxis(startPoint, finishPoint);
            var squareXDifference = Math.Pow(xDifferenct, 2);
            var squareYDifference = Math.Pow(yDifference, 2);
            var side = Math.Pow(squareXDifference + squareYDifference, 0.5);
            return side;
        }

        /// <summary>
        /// Оператор сравнения двух точек. Сравнение
        /// идёт по значениям на осях OX, OY.
        /// </summary>
        /// <param name="left">Левый операнд.</param>
        /// <param name="right">Правый операнд.</param>
        /// <returns>Возвращает true в случае равенства значений
        /// по оси OX, OY. В обратно случае возвращается false.</returns>
        public static bool operator == (Point left, Point right)
        {
            if ((left.AbscissaAxisValue == right.AbscissaAxisValue) && 
                    (left.OrdinateAxisValue == right.OrdinateAxisValue))
            {
                return true;
            }
            return false;
        }

        public static bool operator !=(Point left, Point right)
        {
            return !(left == right);
        }



    }
}
