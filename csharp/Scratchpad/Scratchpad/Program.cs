using System;
using System.Diagnostics;
using BinaryTree.Classes;

namespace Scratchpad
{
	class Program
	{
		static void Main(string[] args)
		{
			// Demo how negative int is rendered as string
			int num = -123;
			string str = num.ToString();
			Console.WriteLine(str); // -123
			char c = str[0];
			Console.WriteLine(c); // -

			// Demo method to reverse an integer
			Console.WriteLine();
			int num1 = -123;
			int revdInt = Reverse(num1);

			int num2 = 456;
			int revdInt2 = Reverse(num2);

			Stopwatch sw1 = new Stopwatch();

			int num3 = 78;
			sw1.Start();
			int revdInt3 = Reverse(num3);
			sw1.Start();
			Console.WriteLine(sw1.ElapsedTicks);

			int num4 = -89;
			sw1.Restart();
			int revdInt4 = Reverse(num4);
			sw1.Stop();
			Console.WriteLine(sw1.ElapsedTicks);

			int num5 = int.MinValue;
			int revdInt5 = Reverse(num5);


			// Instantiate and populate new tree for demo'ing RangeSumBST() method
			BinarySearchTree<int> bst = new BinarySearchTree<int>();
			bst.Root = new Node<int>(10);
			bst.Root.LeftChild = new Node<int>(5);
			bst.Root.RightChild = new Node<int>(15);
			bst.Root.LeftChild.LeftChild = new Node<int>(3);
			bst.Root.LeftChild.RightChild = new Node<int>(7);
			bst.Root.RightChild.RightChild = new Node<int>(18);
			bst.Root.LeftChild.LeftChild.LeftChild = new Node<int>(1);
			bst.Root.LeftChild.RightChild.LeftChild = new Node<int>(6);

			// Demo RangeSumBST() method
			int sum = RangeSumBST(bst.Root, 6, 10);
			Console.WriteLine($"Final sum: {sum}");
		}

	// Reverses an integer
	public static int Reverse(int x)
		{
			if (x > int.MaxValue || x < int.MinValue) return 0;
			string intToStr = x.ToString();
			if (intToStr.Length == 1 || (intToStr.Length == 2 && intToStr[0] == '-')) return x;

			char[] charArr = intToStr.ToCharArray();

			char temp;
			int counter = (charArr[0] == '-') ? 1 : 0;
			for (int i = charArr.Length - 1; i > 0; i--)
			{
				if (counter > i) break;
				temp = charArr[i];
				charArr[i] = charArr[counter];
				charArr[counter] = temp;
				counter++;
			}
			string str = new string(charArr);
			return int.TryParse(str, out int intFromStr) ? intFromStr : 0;
		}

		public static int sum;

		// Sum BST nodes within specified range
		public static int RangeSumBST(Node<int> root, int L, int R)
		{
			PreOrder(root, L, R);
			return sum;
		}

		// Recursive preorder tree traversal method
		public static void PreOrder(Node<int> root, int L, int R)
		{
			if (root != null)
			{
				if (root.Value >= L && root.Value <= R)
				{
					sum += root.Value;
					Console.WriteLine($"root.Value: {root.Value}");
					Console.WriteLine($"sum is now {sum}");
				}
				if (L < root.Value)
				{
					PreOrder(root.LeftChild, L, R);
				}
				if (R > root.Value)
				{
					PreOrder(root.RightChild, L, R);
				}

			}
		}
	}
}
