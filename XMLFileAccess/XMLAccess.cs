using Application.Figures;
using Application.Painting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace XMLFileAccess
{
    public static class XMLAccess
    {
        public static void Save(List<ISpecificFigure> figures, string path = "figures.xml")
        {
            using var xmlWriter = XmlWriter.Create(path);
            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("figures");

            foreach (ISpecificFigure item in figures)
            {
                xmlWriter.WriteStartElement("figure");
                var type = item.GetType().Name;
                xmlWriter.WriteAttributeString("type", type);
                var stringOfPoints = string.Join<Point>(',', item.Points);
                xmlWriter.WriteAttributeString("points", stringOfPoints);
                var color = item.ColorOfFigure.ToString();
                xmlWriter.WriteAttributeString("color", color);
            }
            
            xmlWriter.WriteEndDocument();
        }

        public static void Save(string path, FigureMaterial material)
        {

        }

        public static void LoadFile(string path)
        {
            //using var stream = new FileStream(path, FileMode.OpenOrCreate);
            //XmlReader xmlReader = XmlReader.Create(stream);


            //while (xmlReader.Read())
            //{
            //    if ((xmlReader.NodeType == XmlNodeType.Element) && (xmlReader.Name == "figure"))
            //    {
            //        if (xmlReader.HasAttributes)
            //            Console.WriteLine(xmlReader.GetAttribute("currency") + ": " + xmlReader.GetAttribute("rate"));
            //    }
            //}
        }
    }
}
