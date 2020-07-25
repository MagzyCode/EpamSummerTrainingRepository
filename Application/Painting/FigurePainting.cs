using Application.Figures;

namespace Application.Painting
{
    public static class FigurePainting
    {
        /// <summary>
        /// Метод по рисованию на фигуре. В случае невозможности покрасить
        /// фигуру, вызывается исключение DrawingNotPossibleException.
        /// </summary>
        /// <param name="figure">Фигура для окраски.</param>
        /// <param name="color">Цветка краски.</param>
        public static void Paint (ref ISpecificFigure figure, FigureColor color)
        {
            if (figure.IsFigureDyed == false)
            {
                figure.ColorOfFigure = color;
                figure.IsFigureDyed = true;
            }
            else
            {
                throw new DrawingNotPossibleException();
            }
        }
    }
}
