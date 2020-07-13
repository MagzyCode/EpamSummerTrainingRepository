using FirstTask.SecondExercise;
using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var access = new FileLoadData();
            var figures = access.GetFigureFromFile();
            Console.WriteLine(figures[0].Equals(null));
            Console.WriteLine(figures[0].Equals(figures[1]));
            Console.WriteLine(figures[2].Equals(figures[3]));
            Console.WriteLine(figures[4].Equals(figures[5]));
        }
    }
}
