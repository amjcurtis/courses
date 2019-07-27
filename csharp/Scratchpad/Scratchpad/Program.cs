using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
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
			Console.WriteLine(str); // "-123"
			char c = str[0];
			Console.WriteLine(c); // '-'

			// Demo method to reverse an integer
			Console.WriteLine();
			int num1 = -123;
			int revdInt = Reverse(num1);

			int num2 = 456;
			int revdInt2 = Reverse(num2);

			int num3 = 78;
			Stopwatch sw = Stopwatch.StartNew();
			int revdInt3 = Reverse(num3);
			sw.Stop();
			Console.WriteLine(sw.Elapsed);

			int num4 = -89;
			sw.Restart();
			int revdInt4 = Reverse(num4);
			sw.Stop();
			Console.WriteLine(sw.Elapsed);

			int num5 = int.MinValue;
			int revdInt5 = Reverse(num5);

			// Demo RangeSumBST() method
			BinarySearchTree<int> bst = new BinarySearchTree<int>();
			bst.Root = new Node<int>(10);
			bst.Root.LeftChild = new Node<int>(5);
			bst.Root.RightChild = new Node<int>(15);
			bst.Root.LeftChild.LeftChild = new Node<int>(3);
			bst.Root.LeftChild.RightChild = new Node<int>(7);
			bst.Root.RightChild.RightChild = new Node<int>(18);
			bst.Root.LeftChild.LeftChild.LeftChild = new Node<int>(1);
			bst.Root.LeftChild.RightChild.LeftChild = new Node<int>(6);

			int sum = RangeSumBST(bst.Root, 6, 10);
			Console.WriteLine($"Final sum: {sum}"); // 23
			Console.WriteLine();

			// Demo UniqueMorseRepresentations() method
			string[] words = new string[] { "rwjje", "aittjje", "auyyn", "lqtktn", "lmjwn" };

			sw.Start();
			int count1 = UniqueMorseRepresentations(words);
			sw.Stop();
			Console.WriteLine(sw.Elapsed);
			Console.WriteLine(count1); // 1

			// Demo RemoveOuterParentheses() method
			string input1 = "(()())(())";
			string input2 = "(()())(())(()(()))";
			string input3 = "()()";

			Console.WriteLine($"\"{RemoveOuterParentheses(input1)}\""); // Expect "()()()"
			Console.WriteLine($"\"{RemoveOuterParentheses(input2)}\""); // Expect "()()()()(())"
			Console.WriteLine($"\"{RemoveOuterParentheses(input3)}\""); // Expect ""
		}


		// Returns string S after removing outermost parentheses of every primitive string in primitive decomposition of S
		public static string RemoveOuterParentheses(string S)
		{
			if (string.IsNullOrEmpty(S)) return S; // Handle empty input string

			char[] chars = S.ToCharArray();

			Stack<char> stack = new Stack<char>();
			StringBuilder sb = new StringBuilder();

			for (int i = 0; i < chars.Length; i++)
			{
				if (stack.Count == 0) // If true, then chars[i] is an outermost opening paren
				{
					stack.Push(chars[i]);
				}
				else // chars[i] is an inner paren
				{
					if (chars[i] == '(')
					{
						stack.Push(chars[i]);
						sb.Append(chars[i]);
					}
					else if (chars[i] == ')')
					{
						if (stack.Count != 1) // If paren isn't last one left on stack (i.e. isn't an outermost paren)
						{
							sb.Append(chars[i]);
						}
						stack.Pop();
					}
				}
			}

			string newS = sb.ToString();
			return newS;
		}

		// Takes in a array of strings and returns the number of distinct representations of all the strings in Morse code.
		// A "representation" is defined as a concatenation of the Morse code values of all the individual letters in a string.
		public static int UniqueMorseRepresentations(string[] words)
		{
			string[] code = new string[] { ".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..", ".---", "-.-", ".-..", "--", "-.", "---", ".--.", "--.-", ".-.", "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--.." };
			//char[] alphabet = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };

			HashSet<string> set = new HashSet<string>();

			foreach (string word in words)
			{
				StringBuilder sb = new StringBuilder();
				foreach (char letter in word)
				{
					//int idx = Array.IndexOf(alphabet, letter);
					//sb.Append(code[idx]);
					sb.Append(code[letter - 97]); // Faster and less memory-intensive than the lines commented out above
				}
				set.Add(sb.ToString()); // No if stmt needed here, since hashset ignores duplicate entries
			}

			return set.Count;
		}


		// Converts any uppercase characters in a string to lowercase
		public static string ToLowerCase(string str)
		{
			char[] chars = str.ToCharArray();
			for (int i = 0; i < chars.Length; i++)
			{
				if (char.IsUpper(chars[i]))
				{
					chars[i] = char.ToLower(chars[i]);
				}
			}
			return new string(chars);
		}


		// Static field for use in RangeSumBST() method
		public static int sum;

		// Sum BST node values within specified range
		public static int RangeSumBST(Node<int> root, int L, int R)
		{
			PreOrder(root, L, R);
			return sum;
		}

		// Recursive preorder tree traversal method for use in RangeSumBST() method
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
	}
}
