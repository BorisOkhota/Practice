using System;
using System.Collections.Generic;
using System.Linq;

namespace Task7
{
    public class Node
    {
        public int Number { get; set; }
        public Node Left { get; set; } 
        public Node Right { get; set; } 
        public bool IsEnd { get; set; } 

        public Node(int number)
        {
            Number = number;
            Left = Right = null;
            IsEnd = false;
        }
    }
    public class Tree
    {
        public Tree()
        {
            root = new Node(-1);
        }

        public Node root { get; set; }
        public static List<string> words;

        public static void ShowTree(Node p, int l)
        {
            if (p != null)
            {
                ShowTree(p.Right, l + 5);
                for (int i = 0; i < l; i++)
                    Console.Write(" ");
                Console.WriteLine("{0,10:F4}", p.Number);
                ShowTree(p.Left, l + 5);
            }
        }

        public static void GenerateEndpoints(Node p, int currentLength, int length)
        {
            if (currentLength != length - 1)
            {
                if (p.Left != null && p.Left.IsEnd == false)
                    GenerateEndpoints(p.Left, currentLength + 1, length);
                else if (p.Left == null)
                {
                    p.Left = new Node(0);
                    GenerateEndpoints(p.Left, currentLength + 1, length);
                }

                else if (p.Right != null && p.Right.IsEnd == false)
                    GenerateEndpoints(p.Right, currentLength + 1, length);
                else if (p.Right == null)
                {
                    p.Right = new Node(1);
                    GenerateEndpoints(p.Right, currentLength + 1, length);
                }
            }
            else
            {
                if (p.Left == null || p.Left.IsEnd == false)
                {
                    p.Left = new Node(0);
                    p.Left.IsEnd = true;
                }
                else if (p.Right == null || p.Right.IsEnd == false)
                {
                    p.Right = new Node(1);
                    p.Right.IsEnd = true;
                }
            }
        }

        public static void GenerateWords(Node p, string word)
        {
            if (p != null && p.IsEnd == false)
            {
                word += p.Number;
                GenerateWords(p.Left, word);
                GenerateWords(p.Right, word);
            }
            else if (p != null && p.IsEnd == true)
            {
                word += p.Number;
                word = word.Remove(0, 2);
                words.Add(word);
            }
        }
    }
    public class Program
    {
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

        static bool CheckLengths(int[] lengths)
        {
            double sum = 0;
            foreach (int num in lengths)
                sum += 1 / Math.Pow(2, num);

            if (sum <= 1)
                return true;
            return false;
        }

        public static Tree Solve(int[] lengthsOfWords)
        {
            lengthsOfWords = lengthsOfWords.OrderBy(num => num).ToArray();
            Tree tree = new Tree();
            foreach (int length in lengthsOfWords)
                Tree.GenerateEndpoints(tree.root, 0, length);

            Tree.words = new List<string>(lengthsOfWords.Length);
            Tree.GenerateWords(tree.root, string.Empty);
            return tree;
        }

        static void Main(string[] args)
        {
            bool isOk;
            Console.WriteLine("Введите количество кодовых слов");
            int n = ReadInt(0);
            int[] lengthsOfWords= new int[n];
            do
            {
                Console.WriteLine("Введите длины кодовых слов");
                for(int i = 0; i < n; ++i)
                {
                    Console.WriteLine($"Введите длину {i+1} слова");
                    lengthsOfWords[i] = ReadInt(0);
                }
                isOk = CheckLengths(lengthsOfWords);
                if (!isOk)
                    Console.WriteLine("Ошибка! Введенные длины кодовых слов не прошли проверку по неравенству Макмиллана. Повторите ввод.");
            } while (!isOk);
            var tree = Solve(lengthsOfWords);
            if (Tree.words.Count > n)
            {
                Console.WriteLine("Нельзя составить");
            } else
            {
                Console.Write("Построенный суффиксный двоичный код: ");
                foreach (string word in Tree.words)
                {
                    string str = "";
                    for (int i = word.Length - 1; i >= 0; --i)
                        str += word[i];
                    Console.Write($"{str} ");
                }

                Console.WriteLine();
            }
        }
    }
}
