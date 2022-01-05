using Sandbox;

namespace Poker.Entities
{
	[Library( "ent_chip" )]
	public partial class ChipEntity : ModelEntity
	{
		private ChipValue value = ChipValue.Five;

		public ChipValue Value
		{
			get => value;
			set
			{
				this.value = value;
				RenderColor = new();

				switch ( value )
				{
					case ChipValue.One:
						RenderColor = Color.White;
						break;
					case ChipValue.Two:
						RenderColor = Color.Yellow;
						break;
					case ChipValue.Five:
						RenderColor = Color.Red;
						break;
					case ChipValue.Ten:
						RenderColor = Color.Blue;
						break;
					case ChipValue.Twenty:
						RenderColor = Color.Gray;
						break;
					case ChipValue.TwentyFive:
						RenderColor = Color.Green;
						break;
					case ChipValue.Fifty:
						RenderColor = new Color( 255, 165, 0 ); // Orange
						break;
					case ChipValue.OneHundred:
						RenderColor = new Color( 165, 42, 42 ); // Brown
						break;
					case ChipValue.TwoHundredAndFifty:
						RenderColor = new Color( 254, 113, 220 ); // Pink
						break;
					case ChipValue.FiveHundred:
						RenderColor = new Color( 153, 50, 204 ); // Purple
						break;
					case ChipValue.OneThousand:
						RenderColor = new Color( 128, 0, 32 ); // Burgundy
						break;
					case ChipValue.TwoThousand:
						RenderColor = Color.Cyan;
						break;
					case ChipValue.FiveThousand:
						// TODO: Gold
						SetMaterialGroup( 1 );
						RenderColor = Color.Black;
						break;
				}
			}
		}

		public override void Spawn()
		{
			base.Spawn();
			SetModel( "Models/chip.vmdl" );

			if ( PhysicsEnabled )
				SetupPhysicsFromModel( PhysicsMotionType.Dynamic );

			PhysicsBody.EnableAutoSleeping = true;
		}
	}

	public enum ChipValue : byte
	{
		One,
		Two,
		Five,
		Ten,
		Twenty,
		TwentyFive,
		Fifty,
		OneHundred,
		TwoHundredAndFifty,
		FiveHundred,
		OneThousand,
		TwoThousand,
		FiveThousand
	}
}
