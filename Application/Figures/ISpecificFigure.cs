using Application.Painting;
using System;

namespace Application.Figures
{
    public interface ISpecificFigure : ICloneable
    {
        Point[] Points { get; }

        FigureColor ColorOfFigure { get; }

        bool? IsFigureDyed { get; }

        double Area { get; }

        double Perimeter { get; }

        double GetPerimeter();

        double GetArea();
    }
}
