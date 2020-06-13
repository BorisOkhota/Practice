﻿using System;

namespace Zadacha4
{
    class Program
    {
        static void Main(string[] args)
        {
            double xLeft = -1, xRight = 0, e = 0.002;
            bool ok = false;

            /*Console.WriteLine("Введите вещественное число - точность вычисления корня уравнения");
            while (!ok)
            {
                try
                {
                    e = double.Parse(Console.ReadLine());
                    ok = true;
                }
                catch (Exception)
                {
                    ok = false;
                    Console.WriteLine("Неверный формат. Введите вещественное число..");
                }
            }*/

            double x = MethodChord(xLeft, xRight, e);
            Console.WriteLine(x);
            Console.ReadLine();
        }

        public static double MethodChord(double xPred, double xNast, double e)
        {
            double xSled = 0;
            double tmp;

            do
            {
                tmp = xSled;
                xSled = xNast - (func(xNast) * (xPred - xNast) / (func(xPred) - func(xNast)));
                xPred = xNast;
                xNast = tmp;
            } while (Math.Abs(xSled - xNast) > e);

            return xSled;
        }

        public static double func(double x)
        {
            return Math.Pow(x, 4) + (0.5 * Math.Pow(x, 3)) - (4 * Math.Pow(x, 2)) - (3 * x) - 0.5;
        }
    }
}