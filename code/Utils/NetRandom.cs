using System;
using Sandbox;

namespace Poker.Utils
{
	/// <summary>
	/// Predicted networked random to ensure that a random result is identical on server and client
	/// </summary>
	internal partial class NetRandom : BaseNetworkable
	{
		[Net, Local, Predicted] private int RandomSeed { get; set; }
		[Net, Local, Predicted] private int RandomCount { get; set; }

		private float InternalRandomFloat( Random random, float min = -1f, float max = 1f )
		{
			return min + (max - min) * (float)random.NextDouble();
		}

		public Vector3 RandomNet()
		{
			var random = new System.Random( RandomSeed );

			var value = new Vector3( InternalRandomFloat( random ), InternalRandomFloat( random ),
				InternalRandomFloat( random ) ).Normal * InternalRandomFloat( random, 0, 1 );

			// Set new seed before we leave
			RandomSeed = ((int)(Time.Now * 15289.241f) * RandomCount) % int.MaxValue;
			RandomCount++;

			return value;
		}
	}
}
