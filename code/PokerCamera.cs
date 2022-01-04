using Sandbox;

namespace Poker
{
	// FirstPersonCamera clone with lower FOV
	public class PokerCamera : Camera
	{
		Vector3 lastPos;

		public override void Activated()
		{
			var pawn = Local.Pawn;
			if ( pawn == null ) return;

			Position = pawn.EyePos;
			Rotation = pawn.EyeRot;

			lastPos = Position;
		}

		public override void Update()
		{
			var pawn = Local.Pawn;
			if ( pawn == null ) return;

			var eyePos = pawn.EyePos;

			Position = Vector3.Lerp( eyePos.WithZ( lastPos.z ), eyePos, 20.0f * Time.Delta );
			Rotation = pawn.EyeRot;

			FieldOfView = 80;

			Viewer = pawn;
			lastPos = Position;
		}
	}
}
