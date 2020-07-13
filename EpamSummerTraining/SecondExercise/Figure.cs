using System;
using System.Collections.Generic;

namespace FirstTask.SecondExercise
{
    public abstract class Figure
    {

        private protected Point[] _points = default;
        private protected double[] _sideSizes = default;

        /// <summary>
        /// Массив точек фигуры.
        /// </summary>
        public Point[] Points 
        {
            get
            {
                return _points;
            }
            set
            {
                _points = value;
            }
        }
        /// <summary>
        /// Массив длин сторон фигуры.
        /// </summary>
        public double[] SideSizes
        {
            get
            {
                return _sideSizes;
            }
            set
            {
                _sideSizes = value;
            }
        }

        public Figure() 
        { }

        /// <summary>
        /// Конструктор создания фигуры по значению вершин фигуры.
        /// </summary>
        /// <param name="points">Массив вершин фигуры.</param>
        public Figure (Point[] points)
        {
            _points = points;
            _sideSizes = GetSideSizesFromPoints();
        }

        /// <summary>
        /// Конструктор создания фигуры по значению сторон фигуры.
        /// </summary>
        /// <param name="sideSizes">Массив значений сторон фигуры.</param>
        public Figure (double[] sideSizes)
        {
            _sideSizes = sideSizes;
        }

        /// <summary>
        /// Получает площадь фигуры.
        /// </summary>
        /// <returns>Возвращает площадь фигуры.</returns>
        public abstract double GetAreaOfFigure();

        /// <summary>
        /// Получает периметр фигуры.
        /// </summary>
        /// <returns>Возвращает периметр фигуры.</returns>
        public abstract double GetPerimeterOfFigure();

        /// <summary>
        /// Получает массив значений сторон фигуры, основываясь на вершинах фигуры.
        /// </summary>
        /// <returns>Возвращает массив значений сторон фигуры.</returns>
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

        /// <summary>
        /// Получает расстояние между двумя точками в пространстве.
        /// </summary>
        /// <param name="startPoint">Начальная точка отрезка.</param>
        /// <param name="finishPoint">Конечная точка отрезка.</param>
        /// <returns>Возвращает расстояние между точками.</returns>
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

        public override int GetHashCode()
        {
            return HashCode.Combine(this);
        }

        /// <summary>
        /// Сравнивает две фигуры основываячь на их типе и площади.
        /// </summary>
        /// <param name="obj">Фигура для сравнения.</param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            var figure = obj as Figure;
            var isAreaEquals = GetAreaOfFigure() == figure.GetAreaOfFigure();
            return isAreaEquals;
        }
    }
}
