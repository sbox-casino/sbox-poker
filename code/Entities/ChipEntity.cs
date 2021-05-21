using Poker.Game;
using Poker.Utils;
using Sandbox;

namespace Poker.Entities
{
	[Library( "ent_chip" )]
	public partial class ChipEntity : MovableEntity
	{
		public override void Spawn()
		{
			base.Spawn();
			SetModel( "Models/chip.vmdl" );
			SetupPhysicsFromModel( PhysicsMotionType.Dynamic );

			RenderColor = Rand.Color().ToColor32();
		}
	}
}
