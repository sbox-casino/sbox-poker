using Sandbox.UI;

/// <summary>
/// You don't need to put things in a namespace, but it doesn't hurt.
/// </summary>
namespace MinimalExample
{
	public partial class MinimalHudEntity : Sandbox.Hud
	{
		public MinimalHudEntity()
		{
			if ( IsClient )
			{
				RootPanel.SetTemplate( "/minimalhud.html" );
			}
		}
	}

}
