using Application.Figures;
using Application.Painting;
using System;
using System.Collections.Generic;
using System.Text;

namespace XmlFileAccess
{
    public static class XmlParser
    {
        public static ISpecificFigure FigureParse(string type, string points, string color)
        {
            var figurePoints = points.Split(',');
            List<Point> listOfPoints = new List<Point>();

            for (int counter = 0; counter < figurePoints.Length; counter += 2)
            {
                var firstNumber = Convert.ToDouble(figurePoints[counter]);
                var secondNumber = Convert.ToDouble(figurePoints[counter + 1]);
                listOfPoints.Add(new Point(firstNumber, secondNumber));
            }
            var arrayOfPoints = listOfPoints.ToArray();

            var figureColor = (FigureColor)Enum.Parse(typeof(FigureColor), color);

            var result = GetSpecificFigure(arrayOfPoints, figureColor, type);
            return result;
        }



        public static ISpecificFigure GetSpecificFigure(Point[] points, FigureColor color, string type) => type switch
        {
            "Circle" => new Circle(FigureMaterial.NonMaterial, points) { ColorOfFigure = color },
            "Oval" => new Oval(FigureMaterial.NonMaterial, points) { ColorOfFigure = color },
            "Polygon" => new Polygon(FigureMaterial.NonMaterial, points) { ColorOfFigure = color },
            _ => throw new Exception()
        };
    }
}
