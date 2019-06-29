﻿using System;
using System.Diagnostics;

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