using Sandbox;
using Sandbox.UI;

namespace Poker.UI
{
	public class PlayerInfoCard : Panel
	{
		public enum InfoStatus
		{
			None,
			Raise,
			Blind,
			Folded
		}

		public string AvatarImage { get; set; }
		public string PlayerName { get; set; }
		public string PlayerCash { get; set; }
		public string PlayerStatus { get; set; }
		public InfoStatus Status { get; set; } = InfoStatus.None;

		public Client Client { get; private set; }
		public PokerPlayer Player { get; private set; }

		public PlayerInfoCard()
		{
			SetTemplate( "UI/PlayerInfoCard.html" );
		}

		public void SetInfo( Client client, PokerPlayer player )
		{
			Client = client;
			Player = player;

			InternalSetInfo();
		}

		private void InternalSetInfo()
		{
			AvatarImage = $"avatar:{Client.PlayerId}";
			PlayerName = Client.Name;
			PlayerCash = $"${Player.Money}";
			Status = InfoStatus.None;
			// PlayerStatus = Status.ToString();
		}

		public void Update()
		{
			if ( !Client.IsValid() )
			{
				Delete();
				return;
			}

			PlayerCash = $"${Player.Money}";
			Status = InfoStatus.None;
		}
	}
}
