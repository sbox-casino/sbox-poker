using System.Collections.Generic;
using System.Linq;

namespace Poker.Game
{
	/// <summary>
	/// Player card hand - contains cards and allows for cards to be taken and added to
	/// </summary>
	public class HoleCards
	{
		public Card[] Cards { get; private set; } = new Card[2];

		public void DrawFromDeck( ref Deck deck )
		{
			Cards = deck.Deal( 2 ).ToArray();
		}

		public Card Take( int index )
		{
			var card = Cards[index];
			Cards[index] = null;
			return card;
		}
	}
}
