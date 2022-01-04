using Sandbox;
using Sandbox.UI;
using Sandbox.UI.Construct;

namespace Poker.UI
{
	public partial class PokerEntry : ScoreboardEntry
	{
		public Label HandsPlayed;
		public Label HandsWon;

		public Label PnL;
		public Label Cash;

		public PokerEntry()
		{
			AddClass( "entry" );

			PlayerName = Add.Label( "PlayerName", "name" );

			HandsPlayed = Add.Label( "", "hands-played" );
			HandsWon = Add.Label( "", "hands-won" );
			PnL = Add.Label( "", "pnl" );
			Cash = Add.Label( "", "cash" );

			Ping = Add.Label( "", "ping" );
		}

		public override void UpdateFrom( Client client )
		{
			PlayerName.Text = client.GetValue<string>( "name" );

			HandsPlayed.Text = "0";
			HandsWon.Text = "0";
			PnL.Text = "$0";
			Cash.Text = "$0";

			Ping.Text = client.GetValue<int>( "ping", 0 ).ToString();

			SetClass( "me", Local.Client != null && client.PlayerId == Local.Client.PlayerId );
		}
	}
}
