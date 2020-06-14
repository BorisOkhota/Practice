using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task9
{
    public class List
    {
        public class Node
        {
            public int Data { get; set; }
            public Node Next { get; set; }
            public Node Prev { get; set; }
            public Node(int data)
            {
                Data = data;
                Next = null;
                Prev = null;
            }

            public Node(int data, Node next, Node prev)
            {
                Data = data;
                Next = next;
                Prev = prev;
            }

        }
        private static Node beginning = null;
        public List(int n)
        {
            beginning = CreateList(beginning, 1, n);
        }

        private static Node CreateList(Node p, int number, int maxNumber)
        {
            if (p!=null) p.Prev = p;
            if (p == null || p.Data == 0)
                p = new Node(number);

            if (maxNumber != number)
                p.Next = CreateList(p.Next, number + 1, maxNumber);

            return p;
        }

        public static Node SearchNode(Node p, int number)
        {
            if (p != null)
            {
                if (p.Data == number)
                    return p;
                else
                    return SearchNode(p.Next, number);
            }
            return null;
        }

        public int Search(int number)
        {
            var ans = SearchNode(beginning, number);
            return ans == null ? -1 : ans.Data;
        }

        public void Remove(int number)
        {
            beginning= RemoveNode(beginning, number);
        }

        private static Node RemoveNode(Node p, int number)
        {
            if (p == null)
                return null;
            if (p.Data == number)
                return p.Next;

            return new Node(p.Data, RemoveNode(p.Next, number), p.Prev);
        }

        public string PrintList()
        {
            string str="";
            Node root = beginning;
            if (root == null)
                return ("Список пуст.");
            else
            {
                Node p = root;
                while (p != null)
                {
                    str+=($"{p.Data} ");
                    p = p.Next;
                }
            }
            return str;
        }
    }

    class Program
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
        static void Main(string[] args)
        {
            Console.WriteLine("Введите размер массива");
            int n = ReadInt(0);
            List arr = new List(n);
            arr.PrintList();
            int ans = arr.Search(5);
            Console.WriteLine($"Элемент 5 находится по индексу {ans}");
            arr.Remove(3);
            Console.WriteLine(arr.PrintList());
            ans = arr.Search(3);
            Console.WriteLine("Элемента 3 нет в последоовательности");
        }
    }
}
