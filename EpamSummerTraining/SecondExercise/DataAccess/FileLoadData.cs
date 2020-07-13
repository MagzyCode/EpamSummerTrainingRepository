using FirstTask.SecondExercise.DataAccess;
using FirstTask.SecondExercise.Polygons;
using FirstTask.SecondExercise.SmoothCurves;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FirstTask.SecondExercise
{
    /// <summary>
    /// Класс по загрузки данных о фигурах из файла.
    /// </summary>
    public class FileLoadData
    {
        /// <summary>
        /// Путь файла с данными о фигурах.
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// Инициализирует объект типа FileLoadData, используя путь к файлу
        /// </summary>
        /// <param name="path">Путь к файлу</param>
        public FileLoadData(string path = @"../../figures.txt")
        {
            Path = path;
        }

        /// <summary>
        /// Получение массива фигур, используя путь к файлу с данными
        /// </summary>
        /// <returns>Возвращает массив фигур</returns>
        public Figure[] GetFigureFromFile()
        {
            var list = new List<Figure>();
            using (var stream = new StreamReader(Path))
            {
                Figure figure = null;
                while (!stream.EndOfStream)
                {
                    figure = GetFigure(stream.ReadLine());
                    list.Add(figure);
                }
                
            }
            var figures = list.ToArray();
            return figures;
        }

        /// <summary>
        /// Получает фигуру по строке данных из файла с фигурами.
        /// </summary>
        /// <param name="dataString"></param>
        /// <returns>Возвращает фигуру, используя значения точек и типа</returns>
        private Figure GetFigure(string dataString)
        {
            var dataFields = dataString.Split(';');
            var typeOfFigure = (FigureEnum)Enum.Parse(typeof(FigureEnum), dataFields[0]);
            var arrayOfPointValues = dataFields[1].
                    Split(',').
                    Select(i => i.Replace('.', ',')).
                    Select(i => Convert.ToDouble(i)).
                    ToArray();
            Point[] points = Point.GetPointsFromArray(arrayOfPointValues);
            Figure figure = CreateFigure(typeOfFigure, points);
            return figure;
        }

        /// <summary>
        /// Получает фигуру, используя перечисления FigureEnum и точек
        /// </summary>
        /// <param name="figure">Перечисление по состоянмю фигуры</param>
        /// <param name="points">Точки вершин для инициализации фигуры</param>
        /// <returns>Возвращет фигуруа</returns>
        private Figure CreateFigure(FigureEnum figure, Point[] points) => figure switch
        {
            FigureEnum.Circle => new Circle(points),
            FigureEnum.Oval => new Oval(points),
            FigureEnum.Triangle => new Triangle(points),
            FigureEnum.Rectangle => new Rectangle(points),
            FigureEnum.Polygon => new Polygon(points),
            _ => throw new Exception()
        };
    }
}
