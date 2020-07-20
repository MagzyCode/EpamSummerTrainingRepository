using Application.Painting;
using System;
using System.Collections.Generic;
using System.Linq;

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
        /// <summary>
        /// Цвет фигуры.
        /// </summary>
        // private protected readonly FigureColor color;

        protected Figure()
        { }

        public Figure(FigureMaterial material)
        { }

        /// <summary>
        /// Конструктор создания фигуры по значению вершин фигуры.
        /// </summary>
        /// <param name="points">Массив вершин фигуры.</param>
        public Figure (/*FigureMaterial material, */Point[] points)
        {
            Points = points;
            SideSizes = GetSideSizesFromPoints();
        }


        public Figure (ISpecificFigure figure)
        {
            // figure.
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
                if (value == null || value.Length == 0)
                {
                    throw new NullReferenceException("Нельзя присвоить координатам null");
                }
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
                if (value == null || value.Length == 0)
                {
                    throw new NullReferenceException("Нельзя присвоить сторонам фигуры null");
                }
                _sideSizes = value;
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
            string stringOfPoints = string.Join<Point>(' ', Points);
            return $" Type: {GetType().Name} \n Points: {stringOfPoints}\n";
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
            if (obj is Figure figure)
            {
                var result = Enumerable.SequenceEqual(Points, figure.Points);
                return result;
            }
            return false;
        }
    }
}
