using Poker.Entities;
using Poker.Game;
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
		
		private Vector3 AimDir { get; set; }
		
		public override void Respawn()
		{
			SetModel( "models/citizen/citizen.vmdl" );

			Controller = new PokerController(); // No movement
			Animator = new PokerAnimator();
			Camera = new FirstPersonCamera();

			EnableAllCollisions = true;
			EnableDrawing = true;
			EnableHideInFirstPerson = true;
			EnableShadowInFirstPerson = true;

			base.Respawn();
		}
		
		private bool UpdateAimDir( Player controller, UserInput input )
		{
			if ( Input.CursorAim.LengthSquared < 0.1f )
				return false;
			
			AimDir = Input.CursorAim;
			return true;
		}

		public override void Simulate( Client cl )
		{
			base.Simulate( cl );

			UpdateAimDir( cl.Pawn as Player, Input );

			var traceResult = Trace.Ray( EyePos, EyePos + (AimDir * 120)).Ignore( this ).Radius( 0.5f ).WorldOnly().Run();
			DebugOverlay.Sphere( traceResult.EndPos, 0.5f, Color.Green, depthTest: false );
			
			if ( IsServer && Input.Pressed( InputButton.Attack1 ) )
			{
				var card = new CardEntity();
				card.Position = traceResult.EndPos + (Vector3.Up * 4);
				card.Rotation = Rotation.LookAt( AimDir.WithZ( 0 ) );
				card.Velocity = (traceResult.EndPos - EyePos.WithZ( traceResult.EndPos.z )).Normal * 128;

				// TODO: Rand.Enum
				var suit = (Suit)Rand.Int( (int)Suit.Diamonds, (int)Suit.Clubs );
				var value = (Value)Rand.Int( (int)Value.Two, (int)Value.King );
				card.Card = new Card( suit, value );
				
				card.Dirty();
			}
		}
	}
}
