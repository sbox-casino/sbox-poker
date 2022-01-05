using Sandbox;
using System.Collections.Generic;

namespace Poker.Entities
{
	[Library( "ent_chip_stack" )]
	public partial class ChipStackEntity : ModelEntity
	{
		private Vector3 ChipSize = new( 1.95f, 1.95f, 0.185f );
		private List<ChipEntity> chips = new();

		public override void Spawn()
		{
			base.Spawn();

			if ( Rand.Int( 0, 1 ) == 1 )
			{
				SetMaterialGroup( 1 );
			}
			else
			{
				RenderColor = Rand.Color();
			}

			var chipCount = Rand.Int( 2, 100 );
			var value = (ChipValue)Rand.Int( (int)ChipValue.One, (int)ChipValue.FiveThousand );

			// This is very shit and needs optimizing down into a proper mesh
			for ( int i = 0; i < chipCount; ++i )
			{
				ChipEntity chipEntity = new();
				chipEntity.Value = value;
				chipEntity.Position = Position.WithZ( Position.z + (ChipSize.z * i) );
				chipEntity.PhysicsEnabled = false;
				chipEntity.PhysicsClear();

				chips.Add( chipEntity );
			}

			SetupPhysicsFromOBB( PhysicsMotionType.Dynamic, -(ChipSize / 2), (ChipSize / 2).WithZ( ChipSize.z * chips.Count ) );
		}

		[Event.Tick]
		public void OnTick()
		{
			for ( int i = 0; i < chips.Count; ++i )
			{
				var chip = chips[i];
				chip.Position = Position + (Rotation.Up * ChipSize.z * i);
				chip.Rotation = Rotation;
			}
		}
	}
}
