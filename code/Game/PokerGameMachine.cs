using System;
using System.Linq;
using System.Text;
using Sandbox;

namespace Poker.Game
{
	/// <summary>
	/// Poker game FSM
	/// </summary>
	public class PokerGameMachine
	{
		public PokerGameMachine() { }
		
        private readonly BasePlayer[] players = new BasePlayer[2];
        private Deck deck;

        /// <summary>
        ///     Main game loop
        /// </summary>
        public void Run()
        {
            if ( !Init() )
                return; // Init didn't complete properly - go back to menu
            PlayRound();
        }

        /// <summary>
        ///     Initialize game
        /// </summary>
        /// <returns>Whether setup was successful or not</returns>
        private bool Init()
        {
            Log.Info( "\n=== START GAME ===" );

            // Deck setup
            deck = new Deck();
            deck.Shuffle();

            return true; // Everything set up successfully
        }

        /// <summary>
        ///     Play a round of Poker
        /// </summary>
        private void PlayRound()
        {
	        Log.Info( "\n=== START ROUND ===" );
        }
	}
}
