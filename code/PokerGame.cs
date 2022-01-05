using Poker.Game;
using Sandbox;
using System.Linq;

namespace Poker
{
	public partial class PokerGame : Sandbox.Game
	{
		public PokerHudEntity PokerHudEntity { get; set; }
		public PokerGame()
		{
			if ( IsServer )
				PokerHudEntity = new PokerHudEntity();
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

			var spawnPoints = Entity.All.OfType<SpawnPoint>().ToArray();
			var spawnpoint = spawnPoints[playerCount];

			if ( spawnpoint == null )
			{
				Log.Warning( "Couldn't find spawnpoint!" );
			}

			pawn.Transform = spawnpoint.Transform;
			pawn.EyeRot = spawnpoint.Rotation;
			pawn.EyeRot = Rotation.From( pawn.EyeRot.Angles().WithPitch( 45 ) );
		}

		[ServerCmd( "create_game" )]
		public static void CreateGame()
		{
			new PokerGameMachine().Run();
		}
	}
}
