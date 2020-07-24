using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Figures
{
    class CuttingNotPossibleException : Exception
    {
        public CuttingNotPossibleException() : base("Невозможно вырезать фигуру")
        {

        }
    }
}
