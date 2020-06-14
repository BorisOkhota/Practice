using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task8
{
    public class Program
    {
        public static int ReadInt(int left = -100, int right = 100)
        {
            bool ok = false;
            int number = 0;
            do
            {
                try
                {
                    number = int.Parse(Console.ReadLine());
                    if (number >= left && number <= right) ok = true;
                    else
                    {
                        Console.WriteLine($"Ошибка. Число выход за границы. Введите число большее {left} и меньшее {right}");
                        ok = false;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ошибка. Введено не целое число. Введите целое число.");
                    ok = false;
                }
                catch (OverflowException)
                {
                    Console.WriteLine($"Ошибка. Число выход за границы. Введите число большее {left} и меньшее {right}");
                    ok = false;
                }
            } while (!ok);
            return number;
        }

        public static int[] Solve(int n,int m, int[,] matr)
        {
            int[] col = new int[n];//цвета
            int[,] arr = new int[n, n]; //матрица смежности
            for (int i = 0; i < m; ++i)
            {
                int v1 = -1, v2 = -1;
                for (int j = 0; j < n; j++)
                {
                    if (v1 == -1 && matr[j, i] == 1) v1 = j;
                    else if (v2 == -1 && matr[j, i] == 1) v2 = j;
                }
                arr[v1, v2] = 1;
                arr[v2, v1] = 1;
            }
            for (int i = 0; i < n; ++i)
                for (int j = i + 1; j < n; ++j)
                    if (arr[i, j] == 1 && col[j] == col[i])
                        col[j] = col[i] + 1;
            return col;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество вершин");
            int n = ReadInt(0);
            Console.WriteLine("Введите количество ребер");
            int m = ReadInt(0);
            Console.WriteLine("Введите количество красок");
            int k = ReadInt(0);

            int[] col;//цвета
            int[,] matr = new int[n, m];//матрица инциденций
            for(int i = 0; i < n; ++i)
            {
                for(int j=0; j < m; j++)
                {
                    Console.WriteLine($"Введите {i}{j} элемент");
                    matr[i, j] = ReadInt(0, 1);
                }
            }

            bool ok = true;
            for (int i = 0; i < m && ok; ++i)
            {
                int count = 0;
                for (int j = 0; j < n; ++j)
                {
                    count += matr[j, i];
                }
                if (count > 2)
                    ok = false;
            }
            if (!ok)
            {
                throw new Exception();
            }

            col = Solve(n, m, matr);
            int max = col[0];
            for (int j = 1; j < n; ++j)
                if (max < col[j])
                    max = col[j];
            if (max > k || k > n)
                Console.WriteLine("Нельзя раскрасить за такое количество цветов");
            else if (max < k)
            {
                Console.WriteLine("Цвета вершин");
                for (int i = 0; i < n; ++i)
                    Console.Write(col[i] + " ");
            }
        }
    }
}
