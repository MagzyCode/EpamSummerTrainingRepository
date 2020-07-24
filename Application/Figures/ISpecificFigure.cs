using Application.Painting;
using System;

namespace Application.Figures
{
    public interface ISpecificFigure : ICloneable
    {
        Point[] Points { get; set; }

        FigureColor ColorOfFigure { get; set; }

        bool? IsFigureDyed { get; set; }

        double Area { get; }

        double Perimeter { get; }

        double GetPerimeter();

        double GetArea();
    }
}
