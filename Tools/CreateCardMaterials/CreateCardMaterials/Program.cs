using System;
using System.IO;

// WARNING: mess

namespace CreateCardMaterials
{
    class Program
    {
	    public enum Value
	    {
	        Two,
	        Three,
	        Four,
	        Five,
	        Six,
	        Seven,
	        Eight,
	        Nine,
	        Ten,
	        
	        Ace,
	        Jack,
	        Queen,
	        King
	    }

	    public enum Suit
	    {
	        Diamonds,
	        Hearts,
	        Spades,
	        Clubs
	    }

	    public static string GetTextureName( Suit suit, Value value )
	    {
		    // Texture name format:
		    // card(Suit)(numeric value or J/Q/K)

		    string ConvertValue( Value value )
		    {
			    if ( value < Value.Ace )
			    {
				    return ((int)value + 2).ToString();
			    }
			    // First char of value as uppercase
			    return value.ToString()[0].ToString().ToUpper();
		    }

		    return $"{suit}{ConvertValue( value )}";
	    }


	    public static string GetTexturePath(Suit suit, Value value)
	    {
	        const string baseDirectory = "/Textures/Cards";
			return Path.Combine( baseDirectory, "card" + GetTextureName(suit, value) + ".png" );
	    }

	    private static string baseDir = @"E:\Games\SteamLibrary\steamapps\common\sbox\addons\poker";
	    
        static void Main( string[] args )
        {
	        for ( int suitIndex = 0; suitIndex <= (int)Suit.Clubs; ++suitIndex )
            {
	            for ( int valueIndex = 0; valueIndex <= (int)Value.King; ++valueIndex )
	            {
		            var suit = (Suit)suitIndex;
		            var value = (Value)valueIndex;
		            var texturePath = (baseDir + GetTexturePath( suit, value )).Replace( "\\", "/" );
		            Console.WriteLine( $"{suit} {value}: {texturePath} : Exists: {File.Exists(texturePath)}" );

		            var materialPath = @$"{baseDir}\Materials\{Path.GetFileNameWithoutExtension( texturePath )}.vmat";
		            Console.WriteLine($"Writing material {materialPath}");

		            var template = new BaseMaterial( texturePath );
		            File.WriteAllText( materialPath, template.TransformText() );
		            
		            Console.WriteLine("Wrote material");
	            }
            }
            
            
            Console.WriteLine("== == VMDL == ==");
            for ( int suitIndex = 0; suitIndex <= (int)Suit.Clubs; ++suitIndex )
            {
	            for ( int valueIndex = 0; valueIndex <= (int)Value.King; ++valueIndex )
	            {
		            var suit = (Suit)suitIndex;
		            var value = (Value)valueIndex;

		            var template = new BaseVmdlEntry( GetTextureName( suit, value ) );
		            Console.WriteLine( template.TransformText());
	            }
            }
            
            Console.WriteLine("== == Done == ==");
        }
    }
}
