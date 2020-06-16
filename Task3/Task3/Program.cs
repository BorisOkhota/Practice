using System;

namespace Zadacha3
{
    class Program
    {
        static void Main(string[] args)
        {
            double x = 0, y = 0;
            bool ok = false;

            while (!ok)
            {
                try
                {
                    Console.WriteLine("Введите x...");
                    x = double.Parse(Console.ReadLine());
                    Console.WriteLine("Теперь введите y...");
                    y = double.Parse(Console.ReadLine());
                    ok = true;
                }
                catch (Exception)
                {
                    ok = false;
                    Console.WriteLine("Неверный формат. Введите вещественное число..");
                }
            }

            if ((y <= x / 2) && (Math.Pow(x, 2) + Math.Pow(y, 2) <= 1))
                Console.WriteLine("u = " + -3);
            else
                Console.WriteLine("u = " + Math.Pow(y, 2));
            Console.ReadLine();
        }
    }
}
