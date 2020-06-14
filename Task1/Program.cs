using System;

namespace Zadacha1
{
    class Program
    {
        static void Main(string[] args)
        {
            string VhodnieDannie1 = Console.ReadLine();
            string VhodnieDannie2 = Console.ReadLine();
            string VhodnieDannie3 = Console.ReadLine();

            string[] Dannie1 = VhodnieDannie1.Split(' ');
            string[] Dannie2 = VhodnieDannie2.Split(' ');
            string[] Dannie3 = VhodnieDannie3.Split(' ');

            int x = int.Parse(Dannie1[0]);
            int y = int.Parse(Dannie1[1]);

            int Vx = int.Parse(Dannie2[0]);
            int Vy = int.Parse(Dannie2[1]);

            int V = int.Parse(Dannie3[0]);
            int t = int.Parse(Dannie3[1]);
            int d = int.Parse(Dannie3[2]);

            Int32 R = (x + Vx * t)*(x + Vx * t) + (y + Vy * t)* (y + Vy * t);

            if ((R < ((d - V * t)*(d - V * t)) && ((d - V * t) >= 0)) || (((d + V * t)*(d + V * t)) < R))
                Console.WriteLine("NO");
            else
                Console.WriteLine("YES");
        }
    }
}
