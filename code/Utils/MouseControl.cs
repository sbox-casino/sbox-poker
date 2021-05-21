using Sandbox;
using Sandbox.UI;

namespace Poker.Utils
{
	/// <summary>
	/// Simple mouse hack that makes use of the available SCSS properties to control things like the mouse pointer etc
	/// </summary>
	public class MouseControl : Panel
	{
		public static MouseControl Instance { get; private set; }
		
		/// <summary>
		/// Supported cursor types
		/// </summary>
		public enum Cursor
		{
			None,
			Default,
			Text,
			Progress,
			Wait,
			Pointer
		}

		public MouseControl()
		{
			Instance = this;
			SetClass( "cursor-hack", true );
			StyleSheet.Parse( ".cursor-hack { position: absolute; top: 0; left: 0; right: 0; bottom: 0; pointer-events: visible; }" );
			Style.Dirty();
		}

		public void SetCursor( Cursor cursor )
		{
			Style.Cursor = cursor.ToString().ToLower();
			Style.Dirty();
		}
	}
}
