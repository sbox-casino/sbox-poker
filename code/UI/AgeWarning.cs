using Sandbox;
using Sandbox.UI;

namespace Poker.UI
{
	//
	// I don't think we actually have to display this legally, because this isn't using real money and therefore
	// probably doesn't count as "real gambling", but I'm going to display it anyway out of moral concern plus I'd
	// rather be safe than sorry when it comes to stuff like this
	//
	// Also it gets rid of annoying kids
	//
	public class AgeWarning : Panel
	{
		public AgeWarning()
		{
			SetTemplate( "UI/AgeWarning.html" );
		}
		
		// TODO: Should we be doing these server-side and logging it?
		public void PlayGame()
		{
			SetClass( "exit", true );
			Task.Delay( 500 );
			PokerHudEntity.Instance.SetupHud();
			Delete();
		}

		public void ExitGame()
		{
			ConsoleSystem.Run( "disconnect" );
		}
	}
}
