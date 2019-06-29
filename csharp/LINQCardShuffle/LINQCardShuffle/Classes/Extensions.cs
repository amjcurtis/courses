using System;
using System.Collections.Generic;
using System.Text;

namespace LINQCardShuffle.Classes
{
	static class Extensions
	{
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
	}
}
