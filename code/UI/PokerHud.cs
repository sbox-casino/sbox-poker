using Poker.UI;
using Sandbox.UI;

namespace Poker
{
	public partial class PokerHudEntity : Sandbox.HudEntity<RootPanel>
	{
		public static PokerHudEntity Instance;

		public PokerHudEntity()
		{
			if ( IsClient )
			{
				Instance = this;
				SetupHud();
			}
		}

		/// <summary>
		/// Call this when we've confirmed the user is able to play
		/// </summary>
		public void SetupHud()
		{
			RootPanel.AddChild<LocalPlayerHud>();
			RootPanel.AddChild<ChatBox>();
			RootPanel.AddChild<PlayerInfo>();
			RootPanel.AddChild<Scoreboard<PokerEntry>>();
		}
	}
}
