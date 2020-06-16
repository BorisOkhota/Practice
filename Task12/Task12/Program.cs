using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task12
{
    public class Program
    {
        public class TreeNode
        {
            public TreeNode(int data)
            {
                Data = data;
            }
            public int Data { get; set; }
            public TreeNode Left { get; set; }
            public TreeNode Right { get; set; } 
            public void Insert(TreeNode node, ref int countComp)
            {
                if (node.Data < Data)
                {
                    countComp++;
                    if (Left == null)
                    {
                        Left = node;
                    }
                    else
                    {
                        Left.Insert(node,ref countComp);
                    }
                }
                else
                {
                    countComp++;
                    if (Right == null)
                    {
                        Right = node;
                    }
                    else
                    {
                        Right.Insert(node,ref countComp);
                    }
                }
            }
            public int[] Transform(List<int> elements, ref int countSwap)
            {
                countSwap += 1;
                if (elements == null)
                {
                    elements = new List<int>();
                }

                if (Left != null)
                {
                    Left.Transform(elements, ref countSwap);
                }

                elements.Add(Data);

                if (Right != null)
                {
                    Right.Transform(elements, ref countSwap);
                }

                return elements.ToArray();
            }
        }

        public static void QuickSort(ref int[] arr, int begin, int end,ref int countComp,ref int countSwap)
        {
            int pivot = arr[(begin + (end - begin) / 2)];
            int left = begin;
            int right = end;
            while (left <= right)
            {
                while (arr[left] < pivot)
                {
                    countComp++;
                    left++;
                }
                while (arr[right] > pivot)
                {
                    countComp++;
                    right--;
                }
                if (left <= right)
                {
                    countComp++;
                    countSwap++;
                    Swap(ref arr[left], ref arr[right]);
                    left++;
                    right--;
                }
            }
            if (begin < right)
            {
                QuickSort(ref arr, begin, left - 1, ref countComp, ref countSwap);
            }
            if (end > left)
            {
                QuickSort(ref arr, right + 1, end, ref countComp, ref countSwap);
            }
        }
        public static int[] TreeSort(int[] array, ref int countComp, ref int countSwap)
        {
            List<int> elements = null;
            var treeNode = new TreeNode(array[0]);
            for (int i = 1; i < array.Length; i++)
            {
                treeNode.Insert(new TreeNode(array[i]),ref countComp);
            }
            return treeNode.Transform(elements, ref countSwap);
        }
        static void Swap(ref int l, ref int r)
        {
            int tmp = l;
            l = r;
            r = tmp;
        }
        public static int ReadInt(int left = 0, int right = 10000)
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
        static void Main(string[] args)
        {
            Console.WriteLine("Введите размер массива");
            int n = ReadInt(0);
            int[] arr = new int[n];
            Console.WriteLine("Случайная последовательность чисел");
            int countSwapQuick = 0, countCompQuick = 0;
            int countSwapBin = 0, countCompBin = 0;
            Random rnd = new Random();
            for(int i = 0; i < n; ++i)
            {
                arr[i] = rnd.Next(100);
                Console.Write(arr[i] + " ");
            }
            var arrQuick = arr;
            var arrBin = arr;
            Console.WriteLine();
            arr = TreeSort(arrBin,ref countCompBin, ref countSwapBin);
            QuickSort(ref arrQuick, 0, n - 1, ref countCompQuick, ref countSwapQuick);
            Console.WriteLine($"Результат быстрой сортировки");
            for(int i = 0; i < n; ++i)
            {
                Console.Write(arrQuick[i].ToString() + " ");
            }
            Console.WriteLine($"\n Сортировка сделала {countCompQuick} сравнений и {countSwapQuick} перестановок");
            Console.WriteLine($"Результат сортировки бинарным деревом");
            for (int i = 0; i < n; ++i)
            {
                Console.Write(arrBin[i].ToString() + " ");
            }
            Console.WriteLine($"\n Сортировка сделала {countCompBin} сравнений и {countSwapBin} перестановок\n");
            //////////////////
            ///
            //////////////////
            Console.WriteLine("Возрастающая последовательность чисел");
            countSwapQuick = 0; countCompQuick = 0;
            countSwapBin = 0; countCompBin = 0;
            for (int i = 0; i < n; ++i)
            {
                arr[i] = i+1;
                Console.Write(arr[i] + " ");
            }
             arrQuick = arr;
            arrBin = arr;
            Console.WriteLine();
            arr = TreeSort(arrBin, ref countCompBin, ref countSwapBin);
            QuickSort(ref arrQuick, 0, n - 1, ref countCompQuick, ref countSwapQuick);
            Console.WriteLine($"Результат быстрой сортировки");
            for (int i = 0; i < n; ++i)
            {
                Console.Write(arrQuick[i].ToString() + " ");
            }
            Console.WriteLine($"\n Сортировка сделала {countCompQuick} сравнений и {countSwapQuick} перестановок");
            Console.WriteLine($"Результат сортировки бинарным деревом");
            for (int i = 0; i < n; ++i)
            {
                Console.Write(arrBin[i].ToString() + " ");
            }
            Console.WriteLine($"\n Сортировка сделала {countCompBin} сравнений и {countSwapBin} перестановок\n");
            //////////////////////
            ///
            /////////////////////
            Console.WriteLine("Убывающая последовательность чисел");
            countSwapQuick = 0; countCompQuick = 0;
            countSwapBin = 0; countCompBin = 0;
            for (int i = 0; i < n; ++i)
            {
                arr[i] = n-i;
                Console.Write(arr[i] + " ");
            }
            arrQuick = arr;
            arrBin = arr;
            Console.WriteLine();
            arr = TreeSort(arrBin, ref countCompBin, ref countSwapBin);
            QuickSort(ref arrQuick, 0, n - 1, ref countCompQuick, ref countSwapQuick);
            Console.WriteLine($"Результат быстрой сортировки");
            for (int i = 0; i < n; ++i)
            {
                Console.Write(arrQuick[i].ToString() + " ");
            }
            Console.WriteLine($"\n Сортировка сделала {countCompQuick} сравнений и {countSwapQuick} перестановок");
            Console.WriteLine($"Результат сортировки бинарным деревом");
            for (int i = 0; i < n; ++i)
            {
                Console.Write(arrBin[i].ToString() + " ");
            }
            Console.WriteLine($"\n Сортировка сделала {countCompBin} сравнений и {countSwapBin} перестановок");
            Console.ReadLine();
        }
    }
}
