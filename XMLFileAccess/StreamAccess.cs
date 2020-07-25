﻿using Application.Figures;
using Application.Painting;
using FiguresCollection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Xml;

namespace XmlFileAccess
{
    public static class StreamAccess
    {
        public const string myPath = "figures.xml";
        public static readonly string documentStart = "<?xml version=\"1.0\" encoding=\"utf - 8\"?>";
        public static readonly (string start, string end) elementsBlock = ("<figures>", "</figures>");

        public static void Save(ISpecificFigure[] figures , string path = myPath)
        {
            var document = documentStart;
            document += elementsBlock.start;
            foreach (var item in figures)
            {
                if (item != null)
                {
                    WriteElement(item, ref document);
                }             
            }
            document += elementsBlock.end;

            using var stream = new StreamWriter(path);
            stream.Write(document);
        }

        public static void Save(ISpecificFigure[] figures, FigureMaterial material, string path = myPath)
        {
            var document = documentStart;
            document += elementsBlock.start;

            foreach (var item in figures)
            {
                if (item != null)
                {
                    if ((material == FigureMaterial.Film) && (item.ColorOfFigure == FigureColor.Transparent))
                    {
                        WriteElement(item, ref document);
                    }
                    else
                    {
                        WriteElement(item, ref document);
                    }
                } 
            }
            document += elementsBlock.end;

            using var stream = new StreamWriter(path);
            stream.Write(document);
        }

        public static ISpecificFigure[] LoadFile(string path = myPath)
        {
            using var stream = new StreamReader(path);
            var arrayOfFigures = new ISpecificFigure[Box.MAX_COUNT_OF_FIGURES];
            var counter = 0;
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
                    var figure = XmlParser.FigureParse(type, points, color);
                    arrayOfFigures[counter++] = figure;
                }
            }
            return arrayOfFigures;
        }

        private static void WriteElement(ISpecificFigure figure, ref string document)
        {
            var type = figure.GetType().Name;
            var stringOfPoints = string.Join<Point>(',', figure.Points);
            var color = figure.ColorOfFigure.ToString();
            document += $"<figure type=\"{type}\" points=\"{stringOfPoints}\" color = \"{color}\" />";
        }
    }
}
