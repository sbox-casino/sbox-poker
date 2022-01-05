using Sandbox;

namespace Poker
{
	public class PokerController : BasePlayerController
	{
		public float EyeHeight => 64.0f;

		public override void FrameSimulate()
		{
			UpdateEyePos();
		}

		public override void Simulate()
		{
			UpdateEyePos();
		}

		private void UpdateEyePos()
		{
			EyePosLocal = Vector3.Up * (EyeHeight * Pawn.Scale);
			EyePosLocal += TraceOffset;
		}
	}
}
