using System;

namespace Task5
{
    class Program
    {
        static void Main(string[] args)
        {
            bool ok = false;
            int n = 0;                  //размерность матрицы
            string Vivod = null;

            Console.WriteLine("Введите размерность матрицы");
            while (!ok)
            {
                try
                {
                    n = int.Parse(Console.ReadLine());

                    if (n > 0)
                        ok = true;
                    else
                    {
                        ok = false;
                        Console.WriteLine("Введите положительное число");
                    }
                        
                }
                catch (Exception)
                {
                    ok = false;
                    Console.WriteLine("Неверный формат. Введите целое положительное число..");
                }
            }

            int[,] Massivb = new int[n, n];
            Random rnd = new Random(); 
            Console.WriteLine("Введите матрицу");

            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    Massivb[i, j] = rnd.Next(-100, 10);

            bool check = false;
            for (int i = 0; i < n; i++)
            {
                check = false;
                for (int j = 0; j < n; j++)
                    if (Massivb[i, j] > 0)
                    {
                        Vivod += " " + Massivb[i, j].ToString();
                        check = true;
                        break;
                    }

                if (!check)
                    Vivod += " 1";
            }

            Console.WriteLine($"Ваш вывод:{Vivod}");
        }
    }
}
