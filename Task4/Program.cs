using System;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            double xLeft = -1, xRight = 0, e = 0.002;
            bool ok = false;

            Console.WriteLine("Введите вещественное число - точность вычисления корня уравнения");
            while (!ok)
            {
                try
                {
                    e = double.Parse(Console.ReadLine());
                    if (e >= 0 && e <= 1) ok = true;
                    else
                    {
                        Console.WriteLine($"Ошибка. Число выход за границы. Введите число большее {0} и меньшее {1}");
                        ok = false;
                    }
                }
                catch (FormatException)
                {
                    ok = false;
                    Console.WriteLine("Неверный формат. Введите вещественное число..");
                }
                catch (OverflowException)
                {
                    Console.WriteLine($"Ошибка. Число выход за границы. Введите число большее {0} и меньшее {1}");
                    ok = false;
                }
            }

            double x = MethodChord(xLeft, xRight, e);
            Console.WriteLine(x);
            Console.ReadLine();
        }

        public static double MethodChord(double xPred, double xNast, double e)
        {
            double xSled = 0;
            double tmp;

            while (Math.Abs(xNast - xPred) > e)
            {
                xPred = xNast - (xNast - xPred) * func(xNast) / (func(xNast) - func(xPred));
                xNast = xPred - (xPred - xNast) * func(xPred) / (func(xPred) - func(xNast));
            }
            return xPred;
        }

        public static double func(double x)
        {
            return Math.Pow(x, 4) + (0.5 * Math.Pow(x, 3)) - (4 * Math.Pow(x, 2)) - (3 * x) - 0.5;
        }
    }
}
