using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratorTask8
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 3; i < 100; ++i)
            {
                Random rnd = new Random();
                StreamWriter sw = new StreamWriter($"test{i}.txt");
                int n = rnd.Next(100);
                int m = rnd.Next(100);
                int k = rnd.Next(100);
                sw.WriteLine(n);
                sw.WriteLine(m);
                sw.WriteLine(k);
                int[,] arr = new int[n,m];
                for(int j = 0; j < n; ++j)
                {
                    for (int w = 0; w < m; ++w)
                        arr[j, w] = 0;
                }
                for (int j = 0; j < m; ++j)
                {
                    int a = rnd.Next(n);
                    int b = rnd.Next(n);
                    arr[a, j] = 1;
                    arr[b, j] = 1;
                }

                for (int j = 0; j < n; ++j)
                {
                    for (int w = 0; w < m; ++w)
                    {
                        sw.Write(arr[j, w] + " ");
                    }
                    sw.WriteLine();
                }
                sw.Close();
            }
        }
    }
}
