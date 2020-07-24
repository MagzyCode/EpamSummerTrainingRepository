using Application.Figures;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Painting
{
    public static class FigurePainting
    {
        public static void Paint (ref ISpecificFigure figure, FigureColor color)
        {
            var canPaint = IsPaintingPossible(figure);
            if (canPaint)
            {
                figure.ColorOfFigure = color;
                figure.IsFigureDyed = true;
            }
        }

        private static bool IsPaintingPossible(ISpecificFigure figure)
        {
            if ((figure.ColorOfFigure == FigureColor.Transparent) ||
                    (figure.IsFigureDyed.Value == true))
            {
                throw new DrawingNotPossibleException();
            }
            return true;
        }
    }
}
