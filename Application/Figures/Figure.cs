using Application.Painting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.Figures
{
    public abstract class Figure : ICloneable, ISpecificFigure
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
        /// <summary>
        /// Цвет фигуры.
        /// </summary>
        private protected FigureColor _color;
        #endregion

        #region Constructors

        /// <summary>
        /// Инициализация первоначально цвета для фигуры.
        /// </summary>
        /// <param name="material">Материал для фигуры.</param>
        protected Figure(FigureMaterial material)
        {
            _color = GetStartColor(material);
        }

        /// <summary>
        /// Инициализирует объект типа Figure, основываясь на материале,
        /// из которого будет сделана фигура и точкам на этом материале.
        /// </summary>
        /// <param name="material">Материал для фигуры.</param>
        /// <param name="points">Точки для вырезания</param>
        public Figure (Point[] points, FigureMaterial material) : this(material)
        {
            Points = points;
            SideSizes = GetSideSizesFromPoints();
            Perimeter = GetPerimeter();
            Area = GetArea();
        }

        /// <summary>
        /// Инициализирует объект типа Figure, используя 
        /// существующую фигуру и новые точки для вырезания.
        /// Если площадь новой фигиры по новым точкам будет
        /// больше площади старой фигуры, то будет вызвано
        /// исключение CuttingNotPossibleException.
        /// </summary>
        /// <param name="figure">Исходная фигура.</param>
        /// <param name="newPoints">Точки, для вырезания новой фигуры.</param>
        public Figure (ISpecificFigure figure, Point[] newPoints)
        {
            Points = newPoints;
            Area = GetArea() < figure.GetArea() 
                    ? figure.Area 
                    : throw new CuttingNotPossibleException();
            Perimeter = figure.Perimeter;
            SideSizes = GetSideSizesFromPoints();
            _color = figure.ColorOfFigure;
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
                if ((value == null) || (value.Length == 0))
                {
                    throw new Exception("Невозможно присвоить значение для Points");
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
                if ((value == null) || (value.Length == 0))
                {
                    throw new Exception("Невозможно присвоить значение для SideSizes");
                }
                _sideSizes = value;
            }
        }

        /// <summary>
        /// Задаёт цвет фигуры. В случае, если попытаться
        /// установить плёночной фигуре цвет, то будет вызвано
        /// исключение DrawingNotPossibleException. Если
        /// попытаться изменить цвет в уже закрашенной 
        /// фигуре, то значение присвоено не будет.
        /// </summary>
        public FigureColor ColorOfFigure
        {
            get
            {
                return _color;
            }

            set
            {
                if ((value != FigureColor.Transparent) && (value != FigureColor.PaperDefaultColor) &&
                    IsFigureDyed == false)
                {
                    switch (_color)
                    {    
                        case FigureColor.PaperDefaultColor:
                            {
                                _color = value;
                                IsFigureDyed = true;
                                break;
                            }
                        default: throw new DrawingNotPossibleException();    
                    }
                }
            }
        }

        /// <summary>
        /// Указывает, окрашивали ли фигуру. Если фигуру невозможно
        /// окрасить, возвращает null;
        /// </summary>
        public bool IsFigureDyed { get; set; } = false;
        /// <summary>
        /// Площадь фигуры.
        /// </summary>
        public double Area { get; private set; }
        /// <summary>
        /// Периметр фигуры.
        /// </summary>
        public double Perimeter { get; private set; }

        #endregion

        #region Methods

        /// <summary>
        /// Получает площадь фигуры.
        /// </summary>
        /// <returns>Возвращает площадь фигуры.</returns>
        public abstract double GetArea();

        /// <summary>
        /// Получает периметр фигуры.
        /// </summary>
        /// <returns>Возвращает периметр фигуры.</returns>
        public abstract double GetPerimeter();

        /// <summary>
        /// Получает массив значений сторон фигуры, 
        /// последовательно обходя все вершины фигуры.
        /// </summary>
        /// <returns>Возвращает массив значений сторон фигуры.</returns>
        public virtual double[] GetSideSizesFromPoints()
        {
            // Соединяем первую и последнюю точку
            var indexOfLastPoint = Points.Length - 1;
            double side = Point.GetLengthBetweenPoints(Points[indexOfLastPoint], Points[0]);
            var listOfSides = new List<double> { side };
            if (Points.Length >= 2)
            {
                for (int counter = 0; counter < Points.Length - 1; counter++)
                {
                    side = Point.GetLengthBetweenPoints(Points[counter], Points[counter + 1]);
                    listOfSides.Add(side);
                }
            }
            var arrayOfSides = listOfSides.ToArray();
            return arrayOfSides;
        }

        public object Clone() => Clone();

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
        /// Сравнивает две фигуры основываяcь на их типе и цвете.
        /// </summary>
        /// <param name="obj">Фигура для сравнения.</param>
        /// <returns>Возвращает true в случае равенства 
        /// типов и цветов у двух фигур.</returns>
        public override bool Equals(object obj)
        { 
            if (obj is Figure figure)
            {
                if ((GetType() == figure.GetType()) && 
                        (ColorOfFigure == figure.ColorOfFigure))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Метод задания первоначального цвета для фигуры, 
        /// используя материал для аппликации.
        /// </summary>
        /// <param name="material">Материал фигуры.</param>
        /// <returns>Возвращает цвет по умолчанию
        /// для каждого материала.</returns>
        private FigureColor GetStartColor(FigureMaterial material) => material switch
        {
            FigureMaterial.Film => FigureColor.Transparent,
            FigureMaterial.Paper => FigureColor.PaperDefaultColor,
            _ => throw new Exception()
        };

        #endregion
    }
}
