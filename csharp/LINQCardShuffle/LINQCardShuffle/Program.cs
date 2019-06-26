﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQCardShuffle
{
	class Program
	{
		static void Main(string[] args)
		{
			var startDeck = from s in Suits()
							from r in Ranks()
							select new { Suit = s, Rank = r };

			foreach (var card in startDeck) // var necessary for anonymous type
			{
				Console.WriteLine(card);
			}
			Console.WriteLine(Environment.NewLine);

			var startDeckWithMethodSyntax = Suits().SelectMany(suit => Ranks().Select(rank => new { Suit = suit, Rank = rank }));

			foreach (var card in startDeckWithMethodSyntax)
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
