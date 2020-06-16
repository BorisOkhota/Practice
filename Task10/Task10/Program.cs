using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task10
{
	public class Tree
	{
		public class Node
		{
			public int data;
			public Node Left, Right;
			public Node()
			{
				data = 0;
				Left = null;
				Right = null;
			}

			public Node(int d)
			{
				data = d;
				Left = null;
				Right = null;
			}
		}

		private static Node beginning = null;
		private static Node iter = null;
		private static int iterArr = 0;
		private static int sizeTree = 0;
		public static int ans;
		public Tree()
		{
			iterArr = 0;
			beginning = null;
			iter = null;
		}

		public Node Ideal(int size, Node p, int[] arr)
		{
			Node r;
			int nl, nr;
			if (size == 0)
			{
				p = null;
				return p;
			}
			nl = size / 2;
			nr = size - nl - 1;
			r = new Node(arr[iterArr]);
			iterArr++;
			r.Left = Ideal(nl, r.Left, arr);
			r.Right = Ideal(nr, r.Right, arr);
			beginning = r;
			return r;
		}
		public void Run(int level, Queue<Node> queue, ref string str)
		{
			int count = 0;
			Queue<Node> tmp = new Queue<Node>();
			if (level == 0)
			{
				count = 1;
				if (beginning.Left != null) tmp.Enqueue(beginning.Left);
				if (beginning.Right != null) tmp.Enqueue(beginning.Right);
			}
			else if (queue.Count != 0)
			{
				count = queue.Count;
				foreach (var v in queue)
				{
					if (v.Left != null) tmp.Enqueue(v.Left);
					if (v.Right != null) tmp.Enqueue(v.Right);
				}
			}
			else
			{
				return;
			}
			str += ($"На уровне {level + 1} {count} вершин\n");
			Run(level + 1, tmp, ref str);
		}
	}
	public class Program
	{
		public static void Main(string[] args)
		{
			var tree = new Tree();
			tree.Ideal(10, new Tree.Node(), new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });
			string str = "";
			tree.Run(0, null, ref str);
			Console.WriteLine(str);
			Console.ReadLine();
		}
	}
}
