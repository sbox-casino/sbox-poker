using System;
using System.Collections.Generic;
using System.Linq;

namespace Poker.Game
{
    /// <summary>
    ///     Card deck with shuffling and dealing operations
    /// </summary>
    public class Deck
    {
        private List<Card> cardList;
        private bool cardsShuffled;

        public Deck()
        {
            cardList = new List<Card>();

            for ( var suitIndex = 0; suitIndex < 4; ++suitIndex )
            {
	            for ( var valueIndex = 0; valueIndex < 13; valueIndex++ )
	            {
                    cardList.Add( new Card( ( Suit ) suitIndex, ( Value ) valueIndex ) );
	            }
            }
        }

        /// <summary>
        ///     Checks if there are any cards left in the deck.
        /// </summary>
        public bool IsEmpty()
        {
            return cardList.Count == 0;
        }

        /// <summary>
        ///     Randomizes the order of the deck.
        /// </summary>
        public void Shuffle()
        {
            var random = new Random();
            cardList = cardList.OrderBy( a => random.Next( -1, 1 ) ).ToList();

            cardsShuffled = true;
        }

        /// <summary>
        ///     Removes X cards from the deck and returns them.
        /// </summary>
        public IEnumerable<Card> Deal( int count )
        {
	        var cardListClone = new List<Card>( cardList );
            var cards = cardListClone.TakeLast( count );

            cardList.RemoveRange( cardList.Count - count, count );

            return cards;
        }
    }
}
