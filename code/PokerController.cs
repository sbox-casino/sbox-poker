using System.Diagnostics;
using Sandbox;
using Sandbox.Rcon;
using Trace = Sandbox.Trace;

namespace Poker
{
	public class PokerController : BasePlayerController
	{
		public float EyeHeight => 64.0f;
		
		public PokerController() { }
		
		public override void FrameSimulate()
		{
			base.FrameSimulate();

			EyeRot = Input.Rotation;
		}

		public override void Simulate()
		{
			EyePosLocal = Vector3.Up * (EyeHeight * Pawn.Scale);
			EyePosLocal += TraceOffset;
			EyeRot = Input.Rotation;
		}
	}
}
