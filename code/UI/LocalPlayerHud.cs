using Sandbox;
using Sandbox.UI;

namespace Poker.UI
{
	public class LocalPlayerHud : Panel
	{
		public string PlayerMoney => $"${(Local.Pawn as PokerPlayer)?.Money ?? 0}";

		public LocalPlayerHud()
		{
			SetTemplate( "/UI/LocalPlayerHud.html" );
		}
	}
}

