using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using BinaryTree.Classes;

namespace Scratchpad
{
	class Program
	{
		static void Main(string[] args)
		{
			// Demo how negative int is rendered as string
			Console.WriteLine("RENDER NEGATIVE INTEGER AS STRING");

			int num = -123;
			string str = num.ToString();
			Console.WriteLine($"Int as str: {str}"); // "-123"
			char c = str[0];
			Console.WriteLine($"str[0]: {c}"); // '-'


			// Demo method to reverse an integer
			Console.WriteLine("\nREVERSE AN INTEGER");
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
			Console.WriteLine("SUM BINARY SEARCH TREE NODE VALUES IN SPECIFIED RANGE");

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
			Console.WriteLine($"Final sum: {sum}\n"); // 23


			// Demo UniqueMorseRepresentations() method
			Console.WriteLine("UNIQUE MORSE CODE REPRESENTATIONS");

			string[] words = new string[] { "rwjje", "attjje", "auyyn", "lqtktn", "lmjwn" };

			int count1 = UniqueMorseRepresentations(words);
			Console.WriteLine($"Input string contains {{0}} unique Morse code representation(s).\n", count1);


			// Demo RemoveOuterParentheses() methods
			Console.WriteLine("REMOVE OUTER PARENTHESES");

			string input1 = "(()())(())";
			string input2 = "(()())(())(()(()))";
			string input3 = "()()";

			Console.WriteLine($"\"{RemoveOuterParentheses(input1)}\""); // Expect "()()()"
			Console.WriteLine($"\"{RemoveOuterParentheses(input2)}\""); // Expect "()()()()(())"
			Console.WriteLine($"\"{RemoveOuterParentheses(input3)}\""); // Expect ""
			Console.WriteLine();

			Console.WriteLine($"\"{RemoveOuterParenthesesFaster(input1)}\""); // Expect "()()()"
			Console.WriteLine($"\"{RemoveOuterParenthesesFaster(input2)}\""); // Expect "()()()()(())"
			Console.WriteLine($"\"{RemoveOuterParenthesesFaster(input3)}\"\n"); // Expect ""


			// Demo IsUnivalTree
			Console.WriteLine("IS A GIVEN BINARY TREE A UNIVALUED TREE?");

			// Instantiate univalued tree
			BinaryTree<int> binTree1 = new BinaryTree<int>();
			binTree1.Root = new Node<int>(1);
			binTree1.Root.LeftChild = new Node<int>(1);
			binTree1.Root.RightChild = new Node<int>(1);
			binTree1.Root.LeftChild.LeftChild = new Node<int>(1);
			binTree1.Root.LeftChild.RightChild = new Node<int>(1);
			binTree1.Root.RightChild.RightChild = new Node<int>(1);
			Console.WriteLine($"Is binTree1 univalued? {IsUnivalTree(binTree1.Root)}");

			// Instantiate non-univalued tree
			BinaryTree<int> binTree2 = new BinaryTree<int>();
			binTree2.Root = new Node<int>(2);
			binTree2.Root.LeftChild = new Node<int>(2);
			binTree2.Root.RightChild = new Node<int>(3);
			binTree2.Root.LeftChild.LeftChild = new Node<int>(2);
			binTree2.Root.LeftChild.RightChild = new Node<int>(2);
			Console.WriteLine($"Is binTree2 univalued? {IsUnivalTree(binTree2.Root)}\n");


			// Demo method to defang IP address
			Console.WriteLine("DEFANG AN IP ADDRESS");

			string decimalIP = "192.0.2.235";
			Console.WriteLine($"DECIMAL IP\nOriginal: {decimalIP}");
			Console.WriteLine($"Defanged: {DefangIPAddr(decimalIP)}\n");

			string hexIP = "0xC0.0x00.0x02.0xEB";
			Console.WriteLine($"HEX IP\nOriginal: {hexIP}");
			Console.WriteLine($"Defanged: {DefangIPAddr(hexIP)}\n");

			string octalIP = "0300.0000.0002.0353";
			Console.WriteLine($"OCTAL IP\nOriginal: {octalIP}");
			Console.WriteLine($"Defanged: {DefangIPAddr(octalIP)}\n");

			string emptyString = "";
			Console.WriteLine($"EMPTY STRING\nOriginal: {emptyString}");
			Console.WriteLine($"Output: {DefangIPAddr(emptyString)}\n");

			string invalidAddress = "000012..123.123";
			Console.WriteLine($"EMPTY STRING\nOriginal: {invalidAddress}");
			Console.WriteLine($"Output: {DefangIPAddr(invalidAddress)}\n");


			// Demo FindNumberOfSharedElements method
			int[] array1 = { 13, 27, 35, 40, 49, 55, 59 };
			int[] array2 = { 17, 35, 39, 40, 55, 58, 80 };
			//Console.WriteLine($"Number of shared elements: {FindNumberOfSharedElements(array1, array2)}");
		}

		/// <summary>
		/// Given two sorted integer arrays, finds number of elements common to both arrays. 
		/// Assumes the arrays are same length and each has all distinct elements.
		/// </summary>
		/// <param name="sortedArray1">First sorted integer array.</param>
		/// <param name="sortedArray2">Second sorted integer array.</param>
		/// <returns>Number of elements contained in both arrays.</returns>
		//public static int FindNumberOfSharedElements(int[] sortedArray1, int[] sortedArray2)
		//{
		//	int count = 0;


		//}

		/// <summary>
		/// Binary search helper method for FindNumberOfSharedElements.
		/// </summary>
		/// <param name="sortedArray">Sorted array of integers.</param>
		/// <param name="value">Integer value to search for in array.</param>
		/// <returns>First index where searched value found, else -1 if value not found.</returns>
		static int BinarySearch(int[] sortedArray, int value)
		{
			int min = 0;
			int max = sortedArray.Length;
			int mid;

			while (min <= max)
			{
				mid = (min + max) / 2;

				if (sortedArray[mid] > value)
				{
					max = mid - 1;
				}
				else if (sortedArray[mid] < value)
				{
					min = mid + 1;
				}
				else // I.e. sortedArray[mid] == value
				{
					return mid; // First index where value was found
				}
			}

			return -1;
		} 

		/// <summary>
		/// Defangs an IP address that uses dot notation by replacing all '.' characters with "[.]"
		/// </summary>
		/// <param name="address">IP address as string.</param>
		/// <returns>Defanged address string.</returns>
		public static string DefangIPAddr(string address)
		{
			// Validate input
			Regex regex = new Regex(@"^([\d\w]{1,4}\.){3}[\d\w]{1,4}$");

			if (!regex.IsMatch(address))
			{
				Console.WriteLine("Invalid IP address string!");
				return null;
			}

			StringBuilder sb = new StringBuilder();

			foreach (char c in address)
			{
				sb.Append((c == '.') ? "[.]" : c.ToString());
			}

			return sb.ToString();
		}


		/// <summary>
		/// Returns new version of input string S after removing outermost parentheses of every primitive string in primitive decomposition of S. 
		/// Assumes S[i] is '(' or ')'. 
		/// Assumes input is valid parenthesis string.
		/// </summary>
		/// <param name="S">Input string.</param>
		/// <returns>New string containing contents of input string with outer sets of parens removed.</returns>
		public static string RemoveOuterParentheses(string S)
		{
			if (string.IsNullOrEmpty(S)) return S; // Handle empty input string

			Stack<char> stack = new Stack<char>();
			StringBuilder sb = new StringBuilder();

			for (int i = 0; i < S.Length; i++)
			{
				if (stack.Count == 0) // If true, then S[i] is an outermost opening paren
				{
					stack.Push(S[i]);
				}
				else // S[i] is an inner paren
				{
					if (S[i] == '(')
					{
						stack.Push(S[i]);
						sb.Append(S[i]);
					}
					else // Assume S[i] is always ')' if not '('
					{
						if (stack.Count != 1) // If paren isn't last one left on stack (i.e. isn't an outermost paren)
						{
							sb.Append(S[i]);
						}
						stack.Pop();
					}
				}
			}

			return sb.ToString();
		}


		/// <summary>
		/// More memory-efficient version of RemoveOuterParentheses method.
		/// </summary>
		/// <param name="S">Input string.</param>
		/// <returns>New string containing contents of input string with outer sets of parens removed.</returns>
		public static string RemoveOuterParenthesesFaster(string S)
		{
			if (string.IsNullOrEmpty(S)) return S; // Handle empty input string

			int count = 0; // Substitute for a stack
			StringBuilder sb = new StringBuilder();

			for (int i = 0; i < S.Length; i++)
			{
				if (count == 0) // If true, then S[i] is an outermost opening paren
				{
					count++;
				}
				else // S[i] is an inner paren
				{
					if (S[i] == '(')
					{
						count++;
						sb.Append(S[i]);
					}
					else // Assume S[i] is always ')' if not '('
					{
						if (count != 1) // I.e. if paren isn't an outermost paren
						{
							sb.Append(S[i]);
						}
						count--;
					}
				}
			}

			return sb.ToString();
		}

		/// <summary>
		/// Takes in a array of strings and returns the number of distinct representations of all the strings in Morse code. 
		/// A "representation" is defined as a concatenation of the Morse code values of all the individual letters in a string.
		/// </summary>
		/// <param name="words">Array of strings.</param>
		/// <returns>Number of unique Morse code representations of the words in the input array.</returns>
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
					sb.Append(code[char.ToLower(letter) - 97]); // Faster and less memory-intensive than the lines commented out above
				}
				set.Add(sb.ToString()); // No if stmt needed here, since hashset ignores duplicate entries
			}

			return set.Count;
		}


		/// <summary>
		/// Converts any uppercase characters in a string to lowercase.
		/// </summary>
		/// <param name="str">Input string.</param>
		/// <returns>New string that is a lowercase version of input string.</returns>
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

		/// <summary>
		/// Sums binary search tree node values that fall within specified range (inclusive).
		/// </summary>
		/// <param name="root">Root node of tree.</param>
		/// <param name="L">Low boundary of range.</param>
		/// <param name="R">High boundary of range.</param>
		/// <returns>Sum of all node values within the specified range.</returns>
		public static int RangeSumBST(Node<int> root, int L, int R)
		{
			PreOrder(root, L, R);
			return sum;
		}

		/// <summary>
		/// Recursive preorder tree traversal method for use in RangeSumBST() method
		/// </summary>
		/// <param name="root">Tree node to traverse from.</param>
		/// <param name="L">Low boundary of range.</param>
		/// <param name="R">High boundary of range.</param>
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


		/// <summary>
		/// Reverses an integer (signed or unsigned).
		/// </summary>
		/// <param name="x">Integer to reverse.</param>
		/// <returns>Returns integer reversed, or 0 if integer input is outside min or max int value.</returns>
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


		/// <summary>
		/// Checks whether binary tree is univalued, i.e. whether every node in tree has same value.
		/// </summary>
		/// <param name="root">Root node of tree.</param>
		/// <returns>Boolean.</returns>
		public static bool IsUnivalTree(Node<int> root)
		{
			int val = root.Value;
			bool flag = true;
			Preorder(root);
			return flag;

			// Internal recursive traversal method
			void Preorder(Node<int> node)
			{
				Console.WriteLine(node.Value);

				if (node.Value != val)
				{
					flag = false;
				}

				if (node.LeftChild != null)
				{
					Preorder(node.LeftChild);
				}

				if (node.RightChild != null)
				{
					Preorder(node.RightChild);
				}
			}
		}
	}
}
