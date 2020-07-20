using System;

namespace Application.Painting
{
    public class DrawingNotPossibleException : Exception
    {
        public DrawingNotPossibleException() : base("Невозможно вырезать фигуру.")
        { }
    }
}
