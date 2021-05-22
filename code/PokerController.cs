using Sandbox;

namespace Poker
{
	/// <summary>
	/// Basic controller
	/// We don't need any movement - this is poker
	/// </summary>
	public class PokerController : BasePlayerController
	{
		public float EyeHeight => 64.0f;
		
		public PokerController() { }
		
		public override void FrameSimulate() { }

		public override void Simulate()
		{
			EyePosLocal = Vector3.Up * (EyeHeight * Pawn.Scale);
			EyePosLocal += TraceOffset;
		}
	}
}
