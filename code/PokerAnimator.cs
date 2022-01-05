using Sandbox;

namespace Poker
{
	public class PokerAnimator : PawnAnimator
	{
		public override void Simulate()
		{
			SetParam( "b_grounded", true );

			SetLookAt( "lookat_pos", EyePosLocal );
			SetLookAt( "aimat_pos", EyePosLocal );
		}
	}
}
