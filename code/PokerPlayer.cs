using Poker.Entities;
using Poker.Game;
using Poker.Utils;
using Sandbox;

namespace Poker
{
	partial class PokerPlayer : Player
	{
		/*
		 * We don't want poker players to be able to move around the map freely
		 * They should be locked to chairs, and only visible to other clients
		 * We need first person controls and a free mouse (no FPS-style mouselook)
		 */

		[Net] public decimal Money { get; set; } = 1000.00M; // haha s&bux

		private BaseViewModel ViewModelEntity { get; set; }
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

			CreateViewModel();
		}

		private bool UpdateAimDir( Player controller )
		{
			if ( Input.Cursor.Direction.LengthSquared < 0.1f )
				return false;

			AimDir = Input.Cursor.Direction;
			return true;
		}

		void CreateViewModel()
		{
			Host.AssertClient();

			ViewModelEntity = new BaseViewModel();
			ViewModelEntity.Position = Position;
			ViewModelEntity.Owner = Owner;
			ViewModelEntity.EnableViewmodelRendering = true;
			ViewModelEntity.SetModel( "models/viewmodelarms.vmdl" );
		}

		public override void Simulate( Client cl )
		{
			base.Simulate( cl );

			UpdateAimDir( cl.Pawn as Player );

			AimTrace = Trace.Ray( EyePos, EyePos + (AimDir * 120) )
				//.Ignore( cl.Pawn )
				.Radius( 0.25f )
				.WorldOnly()
				.Run();

			RunPickupSystem( cl );

			if ( IsClient )
			{
				if ( AimTrace.Entity is MovableEntity )
				{
					MouseControl.Instance?.SetCursor( MouseControl.Cursor.Pointer );
				}
				else
				{
					MouseControl.Instance?.SetCursor( MouseControl.Cursor.Default );
				}
			}
		}

		public override void FrameSimulate( Client cl )
		{
			base.FrameSimulate( cl );
		}
	}
}
