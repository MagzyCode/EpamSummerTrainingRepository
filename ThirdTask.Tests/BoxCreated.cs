using Application.Figures;
using Application.Painting;
using FiguresCollection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ThirdTask.Tests
{
    public class BoxCreated
    {
        public Box box = new Box();
        public Point[] points = new Point[]
            {
                new Point(-9, -8),
                new Point(-6, -5),
                new Point(-3, -2),
                new Point(-6, 3),
                new Point(-10, 6),
                new Point(-3, 8),
                new Point(3, 3),
                new Point(6, 9),
                new Point(12, 6),
                new Point(7, -1),
                new Point(3, -4),
                new Point(6, -8)
            };

        public BoxCreated()
        {

            box.Figures = new ISpecificFigure[]
            {
                new Circle (FigureMaterial.Film, points[0], 2),
                new Oval (FigureMaterial.Paper, new Point[] { points[0], points[8]}),
                new Polygon (FigureMaterial.Film, new Point[] {points[0], points[3], points[4]}),
                new Circle (FigureMaterial.Paper, new Point[] { points[6], points[9] }),
                new Oval (FigureMaterial.Film, points[10], 4, 10),
                new Polygon (FigureMaterial.Paper, new Point[] {points[2], points[3], points[5], points[6], points[10]}),
                new Circle (FigureMaterial.Film, points[8], 12),
                new Oval (FigureMaterial.Paper, new Point[] { points[3], points[9] }),
                new Polygon (FigureMaterial.Film, new Point[] {points[0], points[1], points[2], points[10], points[11]}),
            };
        }
    }
}
