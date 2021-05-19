using Sandbox;
using System;
using System.Linq;

namespace Poker
{
	partial class PokerPlayer : Player
	{
		/*
		 * We don't want poker players to be able to move around the map freely
		 * They should be locked to chairs, and only visible to other clients
		 * We need first person controls and a free mouse (no FPS-style mouselook)
		 */
		public override void Respawn()
		{
			SetModel( "models/citizen/citizen.vmdl" );

			Controller = new PokerController(); // No movement
			Animator = new StandardPlayerAnimator();
			Camera = new FirstPersonCamera();

			EnableAllCollisions = true;
			EnableDrawing = true;
			EnableHideInFirstPerson = true;
			EnableShadowInFirstPerson = true;

			base.Respawn();
		}

		/// <summary>
		/// Called every tick, clientside and serverside.
		/// </summary>
		public override void Simulate( Client cl )
		{
			base.Simulate( cl );
		}

		public override void BuildInput( InputBuilder input )
		{
			base.BuildInput( input );
		}
	}
}
