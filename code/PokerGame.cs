using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using Poker.Entities;
using Poker.Game;
using Sandbox;

namespace Poker
{
	[Library( "poker" )]
	public partial class PokerGame : Sandbox.Game
	{
		public PokerHudEntity PokerHudEntity { get; set; }
		public PokerGame()
		{
			if ( IsServer )
			{
				PokerHudEntity = new PokerHudEntity();

				CardTest();
			}
		}

		[ServerCmd( "recreatehud" )]
		public static void RecreateHud()
		{
			(PokerGame.Current as PokerGame).PokerHudEntity.Delete();
			(PokerGame.Current as PokerGame).PokerHudEntity = new();
		}
		
		public override void ClientJoined( Client client )
		{
			base.ClientJoined( client );

			var player = new PokerPlayer();
			client.Pawn = player;

			player.Respawn();
		}
		
		public override void MoveToSpawnpoint( Entity pawn )
		{
			if ( !IsServer )
				return;
			
			var playerCount = Entity.All.OfType<Player>().Count();

			var spawnPoints = Entity.All
				.OfType<SpawnPoint>().ToArray();
			var spawnpoint = spawnPoints[playerCount];

			if ( spawnpoint == null )
			{
				Log.Warning( "Couldn't find spawnpoint!" );
			}

			pawn.Transform = spawnpoint.Transform;
			pawn.EyeRot = spawnpoint.Rotation;
			pawn.EyeRot = Rotation.From( pawn.EyeRot.Angles().WithPitch( 40 ) );
		}

		[ServerCmd( "create_game" )]
		public static void CreateGame()
		{
			new PokerGameMachine().Run();
		}

		public void CardTest()
		{
			// Spawn every card as a test

			for ( Suit suit = Suit.Diamonds; suit <= Suit.Clubs; ++suit )
			{
				for ( Value value = Value.Two; value <= Value.King; ++value )
				{
					var card = new CardEntity();
					card.Position = (Vector3.Right * (int)value * 10) + (Vector3.Backward * (int)suit * 10) +
					                (Vector3.Up * 100);
					card.Rotation = Rotation.LookAt( Vector3.Up );

					card.Card = new Card( suit, value );
					card.Dirty();
				}	
			}
		}
	}

}
