using System;
using System.Linq;

namespace LinqToObjects
{
	class Program
	{
		static void Main(string[] args)
		{
			// Count occurrences of a word in a string
			Console.WriteLine("COUNT OCCURRENCES OF A WORD IN A STRING");
			string text = @"Historically, the world of data and the world of objects" + // @ sign lets you specify string w/o having to escape anything
			  @" have not been well integrated. Programmers work in C# or Visual Basic" +
			  @" and also in SQL or XQuery. On the one side are concepts such as classes," +
			  @" objects, fields, inheritance, and .NET Framework APIs. On the other side" +
			  @" are tables, columns, rows, nodes, and separate languages for dealing with" +
			  @" them. Data types often require translation between the two worlds; there are" +
			  @" different standard functions. Because the object world has no notion of query, a" +
			  @" query can only be represented as a string without compile-time type checking or" +
			  @" IntelliSense support in the IDE. Transferring data from SQL tables or XML trees to" +
			  @" objects in memory is often tedious and error-prone.";

			string searchTerm = "data";

			// Convert string into array of words
			string[] source = text.Split(new char[] { '.', ',', ':', ';', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);

			// Create query, using ToLowerInvariant to match "data" and "Data"
			var matchQuery = from word in source
							 where word.ToLowerInvariant() == searchTerm.ToLowerInvariant()
							 select word;

			int wordCount = matchQuery.Count();
			Console.WriteLine("{0} occurrence(s) of the search term \"{1}\" were found.", wordCount, searchTerm);


			// https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/linq-and-strings

		}
	}
}
