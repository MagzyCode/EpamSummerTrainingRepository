using Application.Painting;

namespace Application.Figures
{
    public interface ISpecificFigure
    {
        FigureColor ColorOfFigure { get; set; }

        double GetPerimeter();

        double GetArea();
    }
}
