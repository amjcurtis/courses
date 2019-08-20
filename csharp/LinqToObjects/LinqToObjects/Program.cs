using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AndrewsUtilityCode.Classes;

namespace LinqToObjects
{
	class Program
	{
		static void Main(string[] args)
		{
			///////////////////////////////////////////
			// Count occurrences of a word in a string
			///////////////////////////////////////////
			
			Console.WriteLine("COUNT OCCURRENCES OF A WORD IN A STRING\n");

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
			string[] source = text.Split(new char[] { ' ', '.', ',', ':', ';', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);

			// Create query, using ToLowerInvariant to match "data" and "Data"
			var matchQuery = from word in source
							 where word.ToLowerInvariant() == searchTerm.ToLowerInvariant()
							 select word;

			int wordCount = matchQuery.Count();
			Console.WriteLine("{0} occurrence(s) of the search term \"{1}\" were found.", wordCount, searchTerm);

			///////////////////////////////////////////
			// Query for sentences containing specified sets of words
			///////////////////////////////////////////

			Console.WriteLine("\nQUERY FOR SENTENCES CONTAINING SPECIFIED SETS OF WORDS\n");

			// Split text block into sentences
			string[] sentences = text.Split(new char[] { '.', '?', '!' });

			// Define search terms (or could populate dynamically at runtime)
			string[] searchTerms = { "Historically", "data", "integrated" };

			// Find sentences containing all terms in search terms array
			var sentenceQuery = from sentence in sentences
								let words = sentence.Split(new char[] { ' ', '.', ',', ':', ';', '!', '?' }, StringSplitOptions.RemoveEmptyEntries)
								where words.Distinct().Intersect(searchTerms).Count() == searchTerms.Count() // Compares count of unique words matching search terms (case-sensitively) to count of search term array
								select sentence;

			foreach (string sent in sentenceQuery)
			{
				Console.WriteLine(sent);
			}

			///////////////////////////////////////////
			// Query for characters in a string
			///////////////////////////////////////////

			Console.WriteLine("\nQUERY FOR CHARACTERS IN A STRING\n");

			string aString = "ABCDE99F-J74-12-06A";
			Console.WriteLine("Original string: {0}", aString);

			// Select only the chars that are numbers
			IEnumerable<char> stringQuery = from ch in aString
											where Char.IsDigit(ch)
											select ch;

			// Execute query
			foreach (char c in stringQuery)
			{
				Console.Write("{0} ", c);
			}
			Console.WriteLine();

			int count = stringQuery.Count();
			Console.WriteLine("Count = {0}", count);

			// Select all chars before dash
			IEnumerable<char> charsBeforeDash = aString.TakeWhile(c => c != '-');

			// Execute second query
			foreach (char c in charsBeforeDash)
			{
				Console.Write(c);
			}
			Console.WriteLine();

			///////////////////////////////////////////
			// Combine LINQ with Regular Expressions
			///////////////////////////////////////////

			Console.WriteLine("\nCOMBINE LINQ WITH REGEXES");

			string startFolder = @"C:\Program Files (x86)\Microsoft Visual Studio\2017";

			IEnumerable<System.IO.FileInfo> fileList = GetFiles(startFolder);

			// Create Regex to find all things Visual
			System.Text.RegularExpressions.Regex rgx = new System.Text.RegularExpressions.Regex(@"Visual (Basic|C\+\+|C#|Studio)");

			var queryMatchingFiles = from file in fileList
									 where file.Extension == ".htm" // Or try where file.Extension.Contains(".htm")
									 let fileText = System.IO.File.ReadAllText(file.FullName)
									 let matches = rgx.Matches(fileText)
									 where matches.Count > 0
									 select new
									 {
										 name = file.FullName,
										 matchedValues = from System.Text.RegularExpressions.Match match in matches
														 select match.Value
									 };

			// Execute query
			Console.WriteLine("The term \"{0}\" was found in:", rgx.ToString());
			foreach (var hit in queryMatchingFiles)
			{
				// Trim path, then write file name
				string s = hit.name.Substring(startFolder.Length - 1);
				Console.WriteLine(s);

				// For current file, write out all the matching strings
				foreach (var matchItem in hit.matchedValues)
				{
					Console.WriteLine(" {0}", matchItem);
				}
			}

			///////////////////////////////////////////
			// Find set difference between two lists
			///////////////////////////////////////////

			Console.WriteLine("\nFIND SET DIFFERENCE BETWEEN TWO LISTS\n");

			// Create IEnumerable data sources
			string[] names1 = System.IO.File.ReadAllLines(@"../../../names1.txt");
			string[] names2 = System.IO.File.ReadAllLines(@"../../../names2.txt");

			// Create query
			IEnumerable<string> diffQuery = names1.Except(names2);

			// Execute query
			Console.WriteLine("Lines in names1.txt but not in names2.txt:");
			foreach (string name in diffQuery)
			{
				Console.WriteLine(name);
			}

			///////////////////////////////////////////
			// Combine and compare strings
			///////////////////////////////////////////

			Console.WriteLine("\nCOMBINE AND COMPARE STRINGS");

			string[] fileA = System.IO.File.ReadAllLines(@"../../../names1.txt");
			string[] fileB = System.IO.File.ReadAllLines(@"../../../names2.txt");

			// Simple concatenation and sort; duplicates are preserved
			IEnumerable<string> concatQuery = fileA.Concat(fileB)
												   .OrderBy(n => n);

			// Pass query to utility method for execution and writing it to console
			Output.PrintQueryResult(concatQuery, "Simple concat and sort, preserving duplicates:");

			// Concatenate and remove duplicate names based on default string comparer
			IEnumerable<string> uniqueNamesQuery = fileA.Union(fileB)
														.OrderBy(n => n);
			Output.PrintQueryResult(uniqueNamesQuery, "Union removes duplicate names:");

			// Find names common to both files
			IEnumerable<string> sharedNamesQuery = fileA.Intersect(fileB)
														.OrderBy(n => n);
			Output.PrintQueryResult(sharedNamesQuery, "Merge based on intersect:");

			// Find matching fields in each list, then take unique and sort
			string nameMatch = "Garcia";

			IEnumerable<string> tempQuery1 = from name in fileA
											 let n = name.Split(',')
											 where n[0] == nameMatch
											 select name;

			IEnumerable<string> tempQuery2 = from name in fileB
											 let n = name.Split(',')
											 where n[0] == nameMatch
											 select name;

			IEnumerable<string> nameMatchQuery = tempQuery1.Concat(tempQuery2)
														   .Distinct()
														   .OrderBy(n => n);

			Output.PrintQueryResult(nameMatchQuery, $"Concat and take unique based on last name match \"{nameMatch}\":");

			///////////////////////////////////////////
			// Join content from dissimilar files containing related info
			///////////////////////////////////////////

			Console.WriteLine("\nJOIN CONTENT FROM DISSIMILAR FILES ON COMMON FIELD");

			string[] names = System.IO.File.ReadAllLines(@"../../../names.csv");
			string[] scores = System.IO.File.ReadAllLines(@"../../../scores.csv");

			// Join dissimilar spreadsheets on common ID
			IEnumerable<string> scoreQuery1 = from name in names.Skip(1)	   // Skip header row of first file
											  let nameFields = name.Split(',') // Split row into cells
											  from id in scores
											  let scoreFields = id.Split(',')  // Split row into cells
											  where nameFields[2] == scoreFields[0]
											  select nameFields[0] + "," + scoreFields[1] + "," + scoreFields[2] + "," + scoreFields[3] + "," + scoreFields[4];

			Output.PrintQueryResult(scoreQuery1, $"TOTAL NAMES IN LIST: {scoreQuery1.Count()}");

			///////////////////////////////////////////
			// Sort/filter text data by word or field
			///////////////////////////////////////////

			Console.WriteLine("\nSORT/FILTER TEXT DATA BY WORD OR FIELD");

			scores = System.IO.File.ReadAllLines(@"../../../names.csv");
			scores = scores.Skip(1).ToArray(); // Skip header row

			int sortField = 2; // Try any value 0-4

			Console.WriteLine("Sorted highest to lowest by field [{0}]", sortField);

			foreach (string str in RunQuery(scores, sortField))
			{
				Console.WriteLine(str);
			}

			///////////////////////////////////////////
			// Reorder fields of a delimited file
			///////////////////////////////////////////

			Console.WriteLine("\nREORDER FIELDS OF A DELIMITED FILE");

			string[] lines = System.IO.File.ReadAllLines(@"../../../names.csv");

			IEnumerable<string> reorderingQuery = from line in lines.Skip(1) // Skip header row
												  let cell = line.Split(',')
												  orderby cell[2]
												  select cell[2] + "," + cell[1] + " " + cell[0];

			System.IO.File.WriteAllLines(@"../../../names_reordered.csv", reorderingQuery.ToArray());

			Console.WriteLine("names_reordered.csv written to disk");

			///////////////////////////////////////////
			// Populate Object Collections from Multiple Sources
			///////////////////////////////////////////

			Console.WriteLine("\nPOPULATE OBJECT COLLECTIONS FROM MULTIPLE SOURCES");

			// Data sources
			names = System.IO.File.ReadAllLines(@"../../../names.csv");
			scores = System.IO.File.ReadAllLines(@"../../../scores.csv");

			IEnumerable<Student> queryNamesScores = from nameLine in names.Skip(1) // Skip first line (header row) in file
													let splitNameLine = nameLine.Split(',')
													from scoreLine in scores.Skip(1) // Skip first line (header row) in file
													let splitScoreLine = scoreLine.Split(',')
													where Convert.ToInt32(splitNameLine[2]) == Convert.ToInt32(splitScoreLine[0])
													select new Student()
													{
														FirstName = splitNameLine[1],
														LastName = splitNameLine[0],
														ID = Convert.ToInt32(splitNameLine[2]),
														ExamScores = (from scoreAsString in splitScoreLine.Skip(1) // Skip first column (Student ID) in array
																	  select Convert.ToInt32(scoreAsString))
																	  .ToList()
													};

			List<Student> students = queryNamesScores.ToList();

			int i = 1;
			foreach (Student stud in students)
			{
				Console.WriteLine("{0}. Average score of {1} {2} is {3}.", i, stud.FirstName, stud.LastName, stud.ExamScores.Average());
				i++;
			}
			Console.WriteLine();
		}

		/// <summary>
		/// Method for use with LINQ + Regex query
		/// </summary>
		/// <param name="path">Filepath as string.</param>
		/// <returns>List of files.</returns>
		public static IEnumerable<System.IO.FileInfo> GetFiles(string path)
		{
			if (!System.IO.Directory.Exists(path))
			{
				throw new System.IO.DirectoryNotFoundException();
			}

			string[] fileNames = null;
			List<System.IO.FileInfo> files = new List<System.IO.FileInfo>();

			fileNames = System.IO.Directory.GetFiles(path, "*.*", System.IO.SearchOption.AllDirectories);
			foreach (string name in fileNames)
			{
				files.Add(new System.IO.FileInfo(name));
			}

			return files;
		}

		/// <summary>
		/// Returns an enumerable query.
		/// </summary>
		/// <param name="source">Data source that implements IEnumerable.</param>
		/// <param name="num">Integer value.</param>
		/// <returns>Returns query itself, not query results.</returns>
		public static IEnumerable<string> RunQuery(IEnumerable<string> source, int num)
		{
			var query = from line in source
						let fields = line.Split(',')
						orderby fields[num] descending
						select line;

			return query;
		}
	}

	// Class to serve as data model for populating object collections from mult sources
	public class Student
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public int ID { get; set; }
		public List<int> ExamScores { get; set; }
	}
}
