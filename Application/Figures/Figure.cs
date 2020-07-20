using Application.Painting;
using System;
using System.Collections.Generic;

namespace Application.Figures
{
    public abstract class Figure
    {
        /// <summary>
        /// Координты вершин или центра фигуры.
        /// </summary>
        private protected Point[] _points;
        /// <summary>
        /// Стороны фигуры.
        /// </summary>
        private protected double[] _sideSizes;

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
                _points = value ?? throw new NullReferenceException("Нельзя присвоить координатам null");
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
                _sideSizes = value ?? throw new NullReferenceException("Нельзя присвоить сторонам фигуры null");
            }
        }

        ///// <summary>
        ///// Получает площадь фигуры.
        ///// </summary>
        ///// <returns>Возвращает площадь фигуры.</returns>
        //public abstract double GetAreaOfFigure();

        ///// <summary>
        ///// Получает периметр фигуры.
        ///// </summary>
        ///// <returns>Возвращает периметр фигуры.</returns>
        //public abstract double GetPerimeter();

        /// <summary>
        /// Получает массив значений сторон фигуры, основываясь на вершинах фигуры.
        /// </summary>
        /// <returns>Возвращает массив значений сторон фигуры.</returns>
        public double[] GetSideSizesFromPoints()
        {
            // Соединяем первую и последнюю точку
            double side = Point.GetLengthBetweenPoints(_points[Points.Length - 1], _points[0]);
            var listOfSides = new List<double> { side };
            if (Points.Length >= 2)
            {
                for (int counter = 0; counter < Points.Length - 1; counter++)
                {
                    side = Point.GetLengthBetweenPoints(_points[counter], _points[counter + 1]);
                    listOfSides.Add(side);
                }
            }
            var arrayOfSides = listOfSides.ToArray();
            return arrayOfSides;
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
        //public override bool Equals(object obj)
        //{
        //    if (obj == null || GetType() != obj.GetType())
        //    {
        //        return false;
        //    }
        //    var figure = obj as Figure;
        //    var isAreaEquals = GetAreaOfFigure() == figure.GetAreaOfFigure();
        //    return isAreaEquals;
        //}
    }
}
