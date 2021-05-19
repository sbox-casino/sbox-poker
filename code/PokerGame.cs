using System;
using System.Linq;
using Sandbox;

namespace Poker
{
	[Library( "poker" )]
	public partial class PokerGame : Sandbox.Game
	{
		public PokerGame()
		{
			if ( IsServer )
			{
				Log.Info( "My Gamemode Has Created Serverside!" );
				new PokerHudEntity();
			}

			if ( IsClient )
			{
				Log.Info( "My Gamemode Has Created Clientside!" );
			}
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
		}
	}

}
