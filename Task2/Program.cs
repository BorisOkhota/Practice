using System;

namespace Zadacha2
{
    class Program
    {
        static void Main(string[] args)
        {
            string Dannie = Console.ReadLine();

            int S = int.Parse(Dannie.Split(' ')[0]);
            int K = int.Parse(Dannie.Split(' ')[1]);

            int[] chisloMax = new int[K];
            int[] chisloMin = new int[K];

            for (int i = 0; i < K; i++)
            {
                chisloMin[i] = 0;
                chisloMax[i] = 0;
            }

            for (int i = 0; i < K; i++)
            {
                if (S != 0)
                    if (S > 9)
                    {
                        chisloMax[i] = 9;
                        chisloMin[K - 1 - i] = 9;
                        S = S - 9;
                    }
                    else
                    {
                        if ((K - 1) == i)
                        {
                            chisloMin[0] = S;
                            chisloMax[i] = S;
                            S = 0;
                        }
                        else
                        {
                            chisloMax[i] = S;
                            chisloMin[K - 1 - i] = S - 1;
                            chisloMin[0] = 1;
                            S = 0;
                        }
                    }
            }

            for (int i = 0; i < K; i++)
                Console.Write(chisloMax[i]);

            Console.Write(" ");

            for (int i = 0; i < K; i++)
                Console.Write(chisloMin[i]);
        }
    }
}
