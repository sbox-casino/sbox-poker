using Sandbox;

namespace Poker.Entities
{
	[Library( "ent_chip_stack" )]
	public partial class ChipStackEntity : MovableEntity
	{
		public override void Spawn()
		{
			base.Spawn();
			SetModel( "Models/chip.vmdl" );
			SetupPhysicsFromModel( PhysicsMotionType.Dynamic );

			if ( Rand.Int( 0, 1 ) == 1 )
			{
				SetMaterialGroup( 1 );
			}
			else
			{
				RenderColor = Rand.Color().ToColor32();
			}
			
			// TODO: Generate chip mesh on the fly or something
		}
	}
}
