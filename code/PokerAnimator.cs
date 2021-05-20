using Sandbox;

namespace Poker
{
	public class PokerAnimator : PawnAnimator
	{
		public override void Simulate()
		{
			SetParam( "b_grounded", true );
			SetParam( "b_noclip", false );
			SetParam( "b_swim", false ); // You can't swim in poker.

			Vector3 aimPos = Pawn.EyePos + Input.Rotation.Forward * 200;
			Vector3 lookPos = aimPos;

			SetLookAt( "lookat_pos", EyePosLocal );
			SetLookAt( "aimat_pos", EyePosLocal );
		}
	}
}
