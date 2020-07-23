using Application.Figures;
using Application.Painting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace XmlFileAccess
{
    public class StreamAccess
    {
        public const string myPath = "figures.xml";

        public void Save(string path)
        {
            
        }

        public void Save(string path, FigureMaterial material)
        {

        }

        public List<ISpecificFigure> LoadFile(string path = myPath)
        {
            using var stream = new StreamReader(path);
            var listOfFigures = new List<ISpecificFigure>();
            var xmlAccess = new XmlAccess();
            var document = new XmlDocument();
            document.Load(stream);
            var root = document.DocumentElement;

            foreach (XmlNode xnode in root.ChildNodes)
            {
                if (xnode.Attributes.Count > 0)
                {
                    string type = xnode.Attributes.GetNamedItem("type").Value;
                    string points = xnode.Attributes.GetNamedItem("points").Value;
                    string color = xnode.Attributes.GetNamedItem("color").Value;
                    var figure = xmlAccess.FigureParse(type, points, color);
                    listOfFigures.Add(figure);
                }
            }
            return listOfFigures;
        }
    }
}
