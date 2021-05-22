using Sandbox;
using Sandbox.UI;

namespace poker.UI
{
	public class PlayerInfoCard : Panel
	{
		private string AvatarImage { get; set; }
		private string PlayerName { get; set; }
		private string PlayerCash { get; set; }
		private string PlayerStatus { get; set; }

		public PlayerInfoCard( Client client )
		{
			SetTemplate( "PlayerInfoCard.html" );
		}
	}
}
