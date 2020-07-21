using Application.Painting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.Figures
{
    public abstract class Figure : ISpecificFigure
    {
        #region Fields
        /// <summary>
        /// Координты вершин или центра фигуры.
        /// </summary>
        private protected Point[] _points;
        /// <summary>
        /// Стороны фигуры.
        /// </summary>
        private protected double[] _sideSizes;

        #endregion

        #region Constructors
        protected Figure()
        { }

        protected Figure(FigureMaterial material)
        {
            ColorOfFigure = GetFigureColor(material);
        }

        /// <summary>
        /// Инициализирует объект типа Figure, основываясь на материале,
        /// из которого будет сделана фигура и точкам на этом материале.
        /// </summary>
        /// <param name="material">Материал для фигуры.</param>
        /// <param name="points">Точки для вырезания</param>
        public Figure (FigureMaterial material, Point[] points) : this(material)
        {
            Points = points;
            SideSizes = GetSideSizesFromPoints();
            Perimeter = GetPerimeter();
            Area = GetArea();
        }

        /// <summary>
        /// Инициализирует объект типа Figure, использующая 
        /// существующую фигуру и новые точки для вырезания.
        /// </summary>
        /// <param name="figure">Исходная фигура.</param>
        /// <param name="newPoints">Точки, для вырезания новой фигуры.</param>
        public Figure (ISpecificFigure figure, Point[] newPoints)
        {
            Points = newPoints;
            Area = GetArea() < figure.GetArea() 
                    ? figure.Area 
                    : throw new Exception("Вырезаемая фигура должна быть меньше исходной.");
            Perimeter = figure.Perimeter;
            SideSizes = GetSideSizesFromPoints();
            ColorOfFigure = figure.ColorOfFigure;
            IsFigureDyed = figure.IsFigureDyed;
            
        }

        #endregion

        #region Properties

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
        /// <summary>
        /// Показывает цвет фигуры.
        /// </summary>
        public FigureColor ColorOfFigure { get; private set; }
        /// <summary>
        /// Указывает, окрашивали ли фигуру. Если фигуру невозможно
        /// окрасить, возвращает null;
        /// </summary>
        public bool? IsFigureDyed { get; private set; } = false;
        public double Area { get; private set; }
        public double Perimeter { get; private set; }

        #endregion

        #region Methods

        ///// <summary>
        ///// Получает площадь фигуры.
        ///// </summary>
        ///// <returns>Возвращает площадь фигуры.</returns>
        public abstract double GetArea();

        ///// <summary>
        ///// Получает периметр фигуры.
        ///// </summary>
        ///// <returns>Возвращает периметр фигуры.</returns>
        public abstract double GetPerimeter();

        /// <summary>
        /// Получает массив значений сторон фигуры, основываясь на вершинах фигуры.
        /// </summary>
        /// <returns>Возвращает массив значений сторон фигуры.</returns>
        public virtual double[] GetSideSizesFromPoints()
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

        /// <summary>
        /// Метод задания первоначального цвета для фигуры, 
        /// используя материал для аппликации.
        /// </summary>
        /// <param name="material"></param>
        /// <returns></returns>
        private FigureColor GetFigureColor(FigureMaterial material)
        {
            var color = material == FigureMaterial.Film
                    ? FigureColor.Transparent
                    : FigureColor.PaperDefaultColor;
            return color;
        }

        #endregion
    }
}
