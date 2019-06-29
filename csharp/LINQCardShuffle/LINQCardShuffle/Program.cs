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
			// Build single sequence (deck) of all cards by combining each element of Suits sequence with each element of Ranks sequence
			// The combined from clauses translate into the SelectMany method in LINQ method syntax
			var startDeck = from s in Suits()
							from r in Ranks()
							select new { Suit = s, Rank = r };

			Console.WriteLine("BUILD DECK OF CARDS");
			foreach (var card in startDeck) // var necessary for anonymous types
			{
				Console.WriteLine(card);
			}
			Console.WriteLine();

			// Perform same query using method syntax
			/*
			var startDeckWithMethodSyntax = Suits().SelectMany(suit => Ranks().Select(rank => new { Suit = suit, Rank = rank }));

			foreach (var card in startDeckWithMethodSyntax)
			{
				Console.WriteLine(card);
			}
			*/

			// Split deck in two
			var topHalf = startDeck.Take(26);
			var bottomHalf = startDeck.Skip(26);

			// Shuffle the deck
			Console.WriteLine("DEMO DECK SHUFFLE");
			var shuffle = topHalf.ZipSequenceWith(bottomHalf);

			foreach (var card in shuffle)
			{
				Console.WriteLine(card);
			}
			Console.WriteLine();

			// Count number of shuffles required to reproduce original sequence of cards
			Console.WriteLine("COUNT NUMBER OF SHUFFLES REQUIRED TO REPRODUCE ORIGINAL DECK SEQUENCE");
			int times = 0;
			shuffle = startDeck;
			do
			{
				shuffle = shuffle.Take(26).ZipSequenceWith(shuffle.Skip(26));

				foreach (var card in shuffle)
				{
					Console.WriteLine(card);
				}
				times++;
				Console.WriteLine($"times = {times}");

			} while (!startDeck.SequenceEquals(shuffle));

			Console.WriteLine($"Shuffles needed to reproduce original deck sequence: {times}");
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
