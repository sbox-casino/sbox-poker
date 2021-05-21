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

			Pos = pawn.EyePos;
			Rot = pawn.EyeRot;

			lastPos = Pos;
		}

		public override void Update()
		{
			var pawn = Local.Pawn;
			if ( pawn == null ) return;

			var eyePos = pawn.EyePos;

			Pos = Vector3.Lerp( eyePos.WithZ( lastPos.z ), eyePos, 20.0f * Time.Delta );
			Rot = pawn.EyeRot;

			FieldOfView = 70;

			Viewer = pawn;
			lastPos = Pos;
		}
	}
}
