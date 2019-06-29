using LINQCardShuffle.Classes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQCardShuffle
{
	class Program
	{
		static void Main(string[] args)
		{
			// Create single sequence of all cards by combining each element of Suits seq with each element of Ranks seq
			// The combined from clauses translate into the SelectMany method in LINQ method syntax
			var startDeck = from s in Suits()
							from r in Ranks()
							select new { Suit = s, Rank = r };

			foreach (var card in startDeck) // var necessary for anonymous types
			{
				Console.WriteLine(card);
			}

			// Perform same query using method syntax
			/*
			var startDeckWithMethodSyntax = Suits().SelectMany(suit => Ranks().Select(rank => new { Suit = suit, Rank = rank }));

			Console.WriteLine(Environment.NewLine);
			foreach (var card in startDeckWithMethodSyntax)
			{
				Console.WriteLine(card);
			}
			*/

			// Split deck in two
			var topHalf = startDeck.Take(26);
			var bottomHalf = startDeck.Skip(26);
			var shuffle = topHalf.ZipSequenceWith(bottomHalf);

			foreach (var card in shuffle)
			{
				Console.WriteLine(card);
			}
		}

		static IEnumerable<string> Suits()
		{
			yield return "clubs";
			yield return "diamonds";
			yield return "hearts";
			yield return "spades";
		}

		static IEnumerable<string> Ranks()
		{
			yield return "two";
			yield return "three";
			yield return "four";
			yield return "five";
			yield return "six";
			yield return "seven";
			yield return "eight";
			yield return "nine";
			yield return "ten";
			yield return "jack";
			yield return "queen";
			yield return "king";
			yield return "ace";
		}
	}
}
