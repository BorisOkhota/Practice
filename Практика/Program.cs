using System;

namespace Практика
{
    class Program
    {
        static void Main(string[] args)
        {
            double x = int.Parse(Console.ReadLine());
            double f = Math.Pow(x, 4) + (0.5 * Math.Pow(x, 3)) - (4 * Math.Pow(x, 2)) - (3 * x) - 0.5;
        }
    }
}
