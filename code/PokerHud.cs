using Poker.UI;
using Poker.Utils;
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
				RootPanel.AddChild<Inspector>();
				RootPanel.AddChild<AgeWarning>();
			}
		}

		/// <summary>
		/// Call this when we've confirmed the user is able to play
		/// </summary>
		public void SetupHud()
		{
			RootPanel.AddChild<LocalPlayerHud>();
			RootPanel.AddChild<ChatBox>();
			RootPanel.AddChild<MouseControl>();
		}
	}
}
