using System;
using System.Linq;
using System.Collections.Generic;

namespace linq_exercises
{
	public class Program
	{
		static void Main(string[] args)
		{
			// QUERY #1
			Console.WriteLine("QUERY #1");
			IEnumerable<Student> topStudentsInFirstTest =
				from student in students
				where student.Scores[0] > 90
				select student;

			foreach (Student student in topStudentsInFirstTest)
			{
				Console.WriteLine($"{student.Last}, {student.First}: {student.Scores[0]}");
			}

			// QUERY #2
			Console.WriteLine("\nQUERY #2");
			IEnumerable<Student> studentQuery2 =
				from student in students
				where student.Scores[0] > 90 && student.Scores[3] < 80
				orderby student.Last
				select student;

			foreach (Student student in studentQuery2)
			{
				Console.WriteLine($"{student.Last}, {student.First}: {student.Scores[0]}, {student.Scores[3]}");
			}

			// QUERY #3
			Console.WriteLine("\nQUERY #3");
			var studentsByFirstInitial =    // Query type is now IEnumerable<IGrouping<char, Student>>
				from student in students
				orderby student.Last
				group student by student.Last[0];

			foreach (var studentGroup in studentsByFirstInitial) // studentGroup is of type IGrouping<char, Student>
			{
				Console.WriteLine(studentGroup.Key);
				foreach (Student student in studentGroup)
				{
					Console.WriteLine($"  {student.Last}, {student.First}");
				}
			}
		}

		// Create nested class for data source
		public class Student
		{
			public string First { get; set; }
			public string Last { get; set; }
			public int ID { get; set; }
			public List<int> Scores;
		}

		// Create a data source by using a collection initializer
		static List<Student> students = new List<Student>
		{
			new Student {First = "Svetlana", Last = "Omelchenko", ID = 111, Scores = new List<int> {97, 92, 81, 60}},
			new Student {First = "Claire", Last = "O'Donnell", ID = 112, Scores = new List<int> {75, 84, 91, 39}},
			new Student {First = "Sven", Last = "Mortensen", ID = 113, Scores = new List<int> {88, 94, 65, 91}},
			new Student {First = "Cesar", Last = "Garcia", ID = 114, Scores = new List<int> {97, 89, 85, 82}},
			new Student {First = "Debra", Last = "Garcia", ID = 115, Scores = new List<int> {35, 72, 91, 70}},
			new Student {First = "Fadi", Last = "Fakhouri", ID = 116, Scores = new List<int> {99, 86, 90, 94}},
			new Student {First = "Hanying", Last = "Feng", ID = 117, Scores = new List<int> {93, 92, 80, 87}},
			new Student {First = "Hugo", Last = "Garcia", ID = 118, Scores = new List<int> {92, 90, 83, 78}},
			new Student {First = "Lance", Last = "Tucker", ID = 119, Scores = new List<int> {68, 79, 88, 92}},
			new Student {First = "Terry", Last = "Adams", ID = 120, Scores = new List<int> {99, 82, 81, 79}},
			new Student {First = "Eugene", Last = "Zabokritski", ID = 121, Scores = new List<int> {96, 85, 91, 60}},
			new Student {First = "Michael", Last = "Tucker", ID = 122, Scores = new List<int> {94, 92, 91, 91}},
			new Student {First = "Rodion", Last = "Raskolnikov", ID = 123, Scores = new List<int> {43, 54, 65, 76}}
		};
	}
}
