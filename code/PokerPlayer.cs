using Poker.Game;
using Sandbox;

namespace Poker
{
	public partial class PokerPlayer : Player
	{
		/*
		 * We don't want poker players to be able to move around the map freely
		 * They should be locked to chairs, and only visible to other clients
		 * We need first person controls and a free mouse (no FPS-style mouselook)
		 */

		[Net] public decimal Money { get; set; } = 1000.00M; // haha s&bux
		[Net] public HoleCards Hand { get; set; }

		private Vector3 AimDir { get; set; }
		private TraceResult AimTrace { get; set; }

		public override void Respawn()
		{
			SetModel( "models/citizen/citizen.vmdl" );

			Controller = new PokerController(); // No movement
			Animator = new PokerAnimator();
			Camera = new PokerCamera();

			EnableAllCollisions = true;
			EnableDrawing = true;
			EnableHideInFirstPerson = true;
			EnableShadowInFirstPerson = true;

			base.Respawn();
		}

		public override void ClientSpawn()
		{
			base.ClientSpawn();
		}

		private void UpdateAimDir()
		{
			if ( Input.Cursor.Direction.LengthSquared < 0.1f )
				return;

			AimDir = Input.Cursor.Direction;
		}

		public override void Simulate( Client cl )
		{
			base.Simulate( cl );

			UpdateAimDir();

			AimTrace = Trace.Ray( EyePos, EyePos + (AimDir * 120) )
				.Ignore( this )
				.Radius( 0.25f )
				.WorldOnly()
				.Run();
		}

		public override void FrameSimulate( Client cl )
		{
			base.FrameSimulate( cl );
		}
	}
}
