using Sandbox;
using Sandbox.UI;
using System.Collections.Generic;
using System.Linq;

namespace Poker.UI
{
	public class PlayerInfo : Panel
	{
		private List<PlayerInfoCard> playerInfoCards = new();
		public PlayerInfo()
		{
			SetTemplate( "UI/PlayerInfo.html" );
		}

		public override void Tick()
		{
			foreach ( var client in Client.All )
			{
				var playerInfoCard = playerInfoCards.FirstOrDefault( x => x.Client == client );
				if ( playerInfoCard == null )
				{
					// Player hasn't been given a place on the HUD yet
					var newCard = AddChild<PlayerInfoCard>();
					var player = client.Pawn as PokerPlayer;
					newCard.SetInfo( client, player );

					playerInfoCards.Add( newCard );
				}
				else
				{
					// Player has a place on the HUD, update it
					playerInfoCard.Update();
				}
			}
		}
	}
}
