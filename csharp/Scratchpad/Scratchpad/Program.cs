using System;

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

			Console.WriteLine();
			int num1 = -123;
			int revdInt = Reverse(num1);
			Console.WriteLine();
			
			int num2 = 456;
			int revdInt2 = Reverse(num2);

			int num3 = 78;
			int revdInt3 = Reverse(num3);

			int num4 = -89;
			int revdInt4 = Reverse(num4);
		}

		// Reverses an integer
		public static int Reverse(int x)
		{
			string intToStr = x.ToString();
			Console.WriteLine($"intToStr: {intToStr}");
			if (intToStr.Length == 1 || (intToStr.Length == 2 && intToStr[0] == '-')) return x;

			char[] charArr = intToStr.ToCharArray();
			char temp;
			int counter = (charArr[0] == '-') ? 1 : 0;
			int len = charArr.Length - 1;
			int halfLen = len / 2;

			for (int i = len; i > halfLen; i--)
			{
				if (i == counter) break;
				temp = charArr[i];
				charArr[i] = charArr[counter];
				charArr[counter] = temp;
				counter++;
			}
			string str = new string(charArr);
			if (Int32.TryParse(str, out int intFromStr))
			{
				Console.WriteLine($"intFromStr: {intFromStr}");
				return intFromStr;
			}
			Console.WriteLine($"str: {str}");
			return x;
		}
	}
}
