using FirstTask.SecondExercise.DataAccess;
using FirstTask.SecondExercise.Polygons;
using FirstTask.SecondExercise.SmoothCurves;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;

namespace FirstTask.SecondExercise
{
    public class FileLoadData
    {
        public string Path { get; set; }

        public FileLoadData(string path = @"../../figures.txt")
        {
            Path = path;
        }

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

        private Figure CreateFigure(FigureEnum figure, Point[] points) => figure switch
        {
            FigureEnum.Circle => new Circle(points),
            FigureEnum.Oval => new Oval(points),
            FigureEnum.Triangle => new Triangle(points),
            FigureEnum.Quadrangle => new Quadrangle(points),
            FigureEnum.Polygon => new Polygon(points),
            _ => throw new Exception()
        };
    }
}
