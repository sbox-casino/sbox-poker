using Poker.Game;
using Poker.Utils;
using Sandbox;

namespace Poker.Entities
{
	[Library( "ent_playing_card" )]
	public partial class CardEntity : ModelEntity
	{
		/// <summary>
		/// The game-side representation of this card
		/// </summary>
		public Card Card { get; set; }
		
		public override void Spawn()
		{
			base.Spawn();
			SetModel( "Models/card.vmdl" );
			SetupPhysicsFromModel( PhysicsMotionType.Dynamic );
		}

		public void Dirty()
		{
			// Material groups match (Suit * ValueCount) + Value + 1
			int materialIndex = ((int)Card.Suit * 13) + (int)Card.Value;
			materialIndex++;
			
			SetMaterialGroup( materialIndex );
		}
	}
}
