using System.Collections.Generic;

namespace Poker.Game
{
    /// <summary>
    ///     Player card hand - contains cards and allows for cards to be taken and added to
    /// </summary>
    public class Hand
    {
        public List<Card> CardList { get; private set; }
        
        public Hand()
        {
            CardList = new();
        }

        public void DrawFromDeck( ref Deck deck, int count )
        {
	        CardList.AddRange( deck.Deal( count ) );
        }

        public Card Take( int index )
        {
            var card = CardList[index];
            CardList.RemoveAt( index );
            return card;
        }
    }
}
