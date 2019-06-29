using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LINQCardShuffle.Classes
{
	static class Extensions
	{
		/// <summary>
		/// Extension method for shuffling sequence by interleaving alternating elements of two subsequences
		/// </summary>
		/// <typeparam name="T">generic typeparam</typeparam>
		/// <param name="first">sequence to interleave with second sequence</param>
		/// <param name="second">second sequence to interleave first sequence with</param>
		/// <returns>zipped sequence</returns>
		public static IEnumerable<T> ZipSequenceWith<T>(this IEnumerable<T> first, IEnumerable<T> second)
		{
			var firstIter = first.GetEnumerator();
			var secondIter = second.GetEnumerator();

			while (firstIter.MoveNext() && secondIter.MoveNext())
			{
				yield return firstIter.Current;
				yield return secondIter.Current;
			}
		}

		/// <summary>
		/// Terminal extension method for determining whether two enumerable sequences are equal. 
		/// Returns single value instead of a sequence, hence it's always final ("terminal") method in any query it's used in.
		/// </summary>
		/// <typeparam name="T">generic typeparam</typeparam>
		/// <param name="first">sequence to compare to second sequence</param>
		/// <param name="second">second sequence to compare first sequence to</param>
		/// <returns>boolean value</returns>
		public static bool SequenceEquals<T>(this IEnumerable<T> first, IEnumerable<T> second)
		{
			var firstIter = first.GetEnumerator();
			var secondIter = second.GetEnumerator();

			while (firstIter.MoveNext() && secondIter.MoveNext())
			{
				if (!firstIter.Current.Equals(secondIter.Current))
				{
					return false;
				}
			}

			return true;
		}

		public static IEnumerable<T> LogQuery<T>(this IEnumerable<T> sequence, string tag)
		{
			using (StreamWriter writer = File.AppendText("debug-linqshuffle.log"))
			{
				writer.WriteLine($"Executing query {tag}");
			}

			return sequence;
		}
	}
}
