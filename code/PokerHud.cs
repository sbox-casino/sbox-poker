using Poker.UI;
using Sandbox.UI;

namespace Poker
{
	public partial class PokerHudEntity : Sandbox.HudEntity<RootPanel>
	{
		public PokerHudEntity()
		{
			if ( IsClient )
			{
				RootPanel.AddChild<LocalPlayerHud>();
				RootPanel.AddChild<ChatBox>();
			}
		}
	}
}
