using System;
using Poker.Entities;
using Sandbox;

namespace Poker
{
	public partial class PokerPlayer
	{
		//
		// Player pickup system
		//

		// Run this on client and server (i.e. in Simulate)
		public void RunPickupSystem( Client client )
		{
			if ( Input.Pressed( InputButton.Attack1 ) && IsServer )
			{
				// Spawn an entity
				SpawnEnt();
			}
		}

		private void SpawnEnt()
		{
			var chip = new ChipStackEntity();
			chip.Position = AimTrace.EndPos + (Vector3.Up * 2);
			chip.Rotation = Rotation.LookAt( AimDir.WithZ( 0 ) );
		}
	}
}
