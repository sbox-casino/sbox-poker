using System;
using Sandbox;

namespace Poker.Entities
{
	[Library( "ent_chip" )]
	public partial class ChipEntity : MovableEntity
	{
		public ChipValue Value { get; private set; }
		
		public override void Spawn()
		{
			base.Spawn();
			SetModel( "Models/chip.vmdl" );
			SetupPhysicsFromModel( PhysicsMotionType.Dynamic );

			PhysicsBody.EnableAutoSleeping = true;

			SetValue( (ChipValue) Rand.Int( (int)ChipValue.One, (int)ChipValue.FiveThousand ) );
		}

		public void SetValue( ChipValue value )
		{
			RenderColor = new();

			Value = value;

			switch ( value )
			{
				case ChipValue.One:
					RenderColor = Color32.White;
					break;
				case ChipValue.Two:
					RenderColor = Color32.Yellow;
					break;
				case ChipValue.Five:
					RenderColor = Color32.Red;
					break;
				case ChipValue.Ten:
					RenderColor = Color32.Blue;
					break;
				case ChipValue.Twenty:
					RenderColor = Color32.Gray;
					break;
				case ChipValue.TwentyFive:
					RenderColor = Color32.Green;
					break;
				case ChipValue.Fifty:
					RenderColor = new Color32( 255, 165, 0 ); // Orange
					break;
				case ChipValue.OneHundred:
					RenderColor = new Color32( 165, 42, 42 ); // Brown
					break;
				case ChipValue.TwoHundredAndFifty:
					RenderColor = new Color32( 254, 113, 220 ); // Pink
					break;
				case ChipValue.FiveHundred:
					RenderColor = new Color32( 153, 50, 204 ); // Purple
					break;
				case ChipValue.OneThousand:
					RenderColor = new Color32( 128, 0, 32 ); // Burgundy
					break;
				case ChipValue.TwoThousand:
					RenderColor = Color32.Cyan;
					break;
				case ChipValue.FiveThousand:
					// TODO: Gold
					SetMaterialGroup( 1 );
					RenderColor = Color32.Black;
					break;
			}
		}
	}

	// this is so dumb LOL
	// can squeeze this into less than a byte tho 👌
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
