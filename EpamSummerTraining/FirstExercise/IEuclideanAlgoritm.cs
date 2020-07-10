using System;
using System.Collections.Generic;
using System.Text;

namespace FirstTask
{
    interface IEuclideanAlgoritm
    {
        int GetEuclideanGCD(int firstNumber, int secondNumber, out TimeSpan executionTime);
        int GetSteinitzGCD(int firstNumber, int secondNumber, out TimeSpan executionTime);
    }
}
