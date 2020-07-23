using Application.Figures;
using Application.Painting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace XmlFileAccess
{
    public class XmlAccess
    {
        public const string myPath = "figures.xml";

        public void Save(List<ISpecificFigure> figures, string path = myPath)
        {
            using var xmlWriter = XmlWriter.Create(path);
            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("figures");
            
            foreach (ISpecificFigure item in figures)
            {
                WriteElement(item, xmlWriter);
            }
            
            xmlWriter.WriteEndDocument();
        }

        public void Save(List<ISpecificFigure> figures, FigureMaterial material, string path = myPath)
        {
            using var xmlWriter = XmlWriter.Create(path);
            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("figures");

            foreach (ISpecificFigure item in figures)
            {
                if (material == FigureMaterial.Film && item.ColorOfFigure == FigureColor.Transparent)
                {
                    WriteElement(item, xmlWriter);
                }
                else
                {
                    WriteElement(item, xmlWriter);
                }
            }

            xmlWriter.WriteEndDocument();
        }

        

        public List<ISpecificFigure> LoadFile(string path, List<ISpecificFigure> figures)
        {
            using var stream = new FileStream(path, FileMode.OpenOrCreate);
            XmlReader xmlReader = XmlReader.Create(stream);
            figures = new List<ISpecificFigure>();
            
            while (xmlReader.Read())
            {
                if ((xmlReader.NodeType == XmlNodeType.Element) && (xmlReader.Name == "figure"))
                {
                    if (xmlReader.HasAttributes)
                    {
                        var figureType = xmlReader.GetAttribute("type");
                        var figurePoints = xmlReader.GetAttribute("points");
                        var figureColor = xmlReader.GetAttribute("color");
                        ISpecificFigure figure = FigureParse(figureType, figurePoints, figureColor);
                        figures.Add(figure);
                    }
                }
            }
            return figures;
        }

        public ISpecificFigure FigureParse(string type, string points, string color)
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



        public ISpecificFigure GetSpecificFigure(Point[] points, FigureColor color, string type) => type switch
        {
            "Circle" => new Circle(FigureMaterial.NonMaterial, points) { ColorOfFigure = color},
            "Oval" => new Oval(FigureMaterial.NonMaterial, points) { ColorOfFigure = color},
            "Polygon" => new Polygon(FigureMaterial.NonMaterial, points) { ColorOfFigure = color},
            _ => throw new Exception()
        };



        private void WriteElement(ISpecificFigure figure, XmlWriter xmlWriter)
        {
            xmlWriter.WriteStartElement("figure");
            var type = figure.GetType().Name;
            xmlWriter.WriteAttributeString("type", type);
            var stringOfPoints = string.Join<Point>(',', figure.Points);
            xmlWriter.WriteAttributeString("points", stringOfPoints);
            var color = figure.ColorOfFigure.ToString();
            xmlWriter.WriteAttributeString("color", color);
            xmlWriter.WriteEndElement();
        }
    }
}
