using Sandbox;
using Sandbox.UI;
using System;
using System.Linq;

public class InspectorTarget : Panel
{
	public new const bool HasHovered = false;
	public new const bool AcceptsFocus = false;
	private Label _infoPanel;

	public InspectorTarget()
	{
		_infoPanel = this.AddChild<Label>();
		_infoPanel.AddClass( "info" );

	}

	public override void Tick()
	{
		base.Tick();

		var root = FindRootPanel();

		if ( root != null && root.Style != null )
		{
			var panel = InspectorUtils.GetHoveredPanel( root, root.MousePos ) ?? root;

			string classList;
			if ( panel.Class.Any() )
			{
				classList = panel.Class.Select( ( i ) => $".{i}" ).Aggregate( ( i, j ) => i + j );
			}
			else
			{
				classList = "";
			}

			_infoPanel.Text = $"{panel.ElementName} {Math.Round( panel.Box.Rect.width, 1 )}x{Math.Round( panel.Box.Rect.height, 1 )} {classList}";

			var left = panel.Box.Left;
			var top = panel.Box.Top;
			var width = panel.Box.Rect.width;
			var height = panel.Box.Rect.height;

			this.Style.Left = Length.Pixels( ScaleFromScreen * left );
			this.Style.Top = Length.Pixels( ScaleFromScreen * top );
			this.Style.Width = Length.Pixels( ScaleFromScreen * width );
			this.Style.Height = Length.Pixels( ScaleFromScreen * height );
			this.Style.Dirty();

			// Place info panel inside or left of component if too close to top/left of screen.
			var right = Screen.Width - left - height;
			_infoPanel.SetClass( "move_down", top <= 18 );
			_infoPanel.SetClass( "move_left", right < 64 );
		}
	}
}

public class Inspector : Panel
{
	public Panel CurrentTarget;

	public Inspector()
	{
		this.StyleSheet.Load( "/ui/Inspector.scss" );
		this.AddChild<InspectorTarget>();

		// Renderer won't listen to z-index in css class of Panel. [bug]
		this.Style.ZIndex = 10000;
	}

	private static bool enabled_ = false;

	[ClientCmd( name: "inspector" )]
	public static void ToggleInspector()
	{
		enabled_ = !enabled_;
	}

	public override void Tick()
	{
		base.Tick();

		this.SetClass( "enabled", enabled_ );
	}
}


static class InspectorUtils
{
	/**
	 *		HasHovered wasn't working for certain Panels, decided to code a working utility.
	 *		Recursively finds Panel being hovered over.
	 */
	public static Panel GetHoveredPanel( Panel p, Vector2 mousePos )
	{
		if ( p.HasClass( "inspector_container" ) || p.IsDeleting )
		{
			return null;
		}

		var foundChild = p;
		var root = p.FindRootPanel();
		var rootPos = root.MousePos;

		foreach ( var child in p.Children )
		{
			var left = child.Box.Left;
			var top = child.Box.Top;
			var right = child.Box.Right;
			var bottom = child.Box.Bottom;

			if ( child.IsVisibleSelf )
			{
				if ( (left <= rootPos.x && right >= rootPos.x && top <= rootPos.y && bottom >= rootPos.y) )
				{
					foundChild = GetHoveredPanel( child, mousePos ) ?? foundChild;
				}
			}
		}
		return foundChild;
	}
}
