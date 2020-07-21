using Application.Painting;

namespace Application.Figures
{
    public interface ISpecificFigure
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
