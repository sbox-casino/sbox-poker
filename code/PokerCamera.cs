using Sandbox;

namespace Poker
{
	public class PokerCamera : FirstPersonCamera
	{
		public override void Update()
		{
			base.Update();
			FieldOfView = 80;
		}
	}
}
