using Application.Figures;
using Application.Painting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace XmlFileAccess
{
    public static class XmlAccess
    {
        public const string myPath = "figures.xml";

        public static void Save(List<ISpecificFigure> figures, string path = myPath)
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

        public static void Save(List<ISpecificFigure> figures, FigureMaterial material, string path = myPath)
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

        public static List<ISpecificFigure> LoadFile(string path, List<ISpecificFigure> figures)
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
                        ISpecificFigure figure = XmlParser.FigureParse(figureType, figurePoints, figureColor);
                        figures.Add(figure);
                    }
                }
            }
            return figures;
        }

        private static void WriteElement(ISpecificFigure figure, XmlWriter xmlWriter)
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
