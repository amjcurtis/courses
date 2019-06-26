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


		}
	}
}
