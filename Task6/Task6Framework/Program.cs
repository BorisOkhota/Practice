using System;
using System.Collections.Generic;

namespace Task6
{
    public class Program
    {
        // Функция считывания целочисленного элемента из конкретного диапазона
        public static int ReadInt(int left = -10000, int right = 10000)
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

        public static List<double> arr;

        // Рекурсивное заполнение массива
        public static void Rec(int index, double n)
        {
            double a = arr[index - 1] / 3 - arr[index - 2] / 2 - arr[index - 3] * 2 / 3;
            if (index - 2 > n) return;
            arr.Add(a);
            Rec(index + 1, n);
        }

        static void Input(ref double a1, ref double a2, ref double a3, ref int n, ref int e)
        {
            Console.WriteLine("Введите а1");
            a1 = ReadInt();
            arr.Add(a1);
            Console.WriteLine("Введите а2");
            a2 = ReadInt();
            arr.Add(a2);
            Console.WriteLine("Введите а3");
            a3 = ReadInt();
            arr.Add(a3);
            Console.WriteLine("Введите N");
            n = ReadInt();
            Console.WriteLine("Введите E");
            e = ReadInt();
        }

        public static void Main(string[] args)
        {
            arr = new List<double>();
            double a1 = 0, a2 = 0, a3 = 0, a;
            int n = 0, e = 0;
            Input(ref a1, ref a2, ref a3, ref n, ref e);
            Rec(3, n);
            int count = 0;
            Console.WriteLine("Пары, которые удовлетворяют условию");
            for (int i = 4; i < arr.Count; ++i)
            {
                if (Math.Abs(arr[i] - arr[i - 1]) < e)
                {
                    Console.WriteLine($"{i} {i - 1}");
                    count++;
                }
            }
            Console.WriteLine($"Всего таких пар {count}");
        }
    }
}