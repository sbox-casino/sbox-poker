using Sandbox;

namespace Poker.Utils
{
	/// <summary>
	/// Predicted networked random to ensure that a random result is identical on server and client
	/// </summary>
	public partial class NetRandom : NetworkClass
	{
		[NetLocalPredicted] private int RandomSeed { get; set; }
		[NetLocalPredicted] private int RandomCount { get; set; }

		public Vector3 RandomNet()
		{
			var random = new System.Random( RandomSeed );
			
			float RandomFloat(float min = -1f, float max = 1f) => min + (max - min) * (float)random.NextDouble();
			var value = new Vector3( RandomFloat(), RandomFloat(), RandomFloat() ).Normal * RandomFloat( 0, 1 );
			
			// Set new seed before we leave
			RandomSeed = (int)(Time.Now * 15289.241f) * RandomCount;
			RandomCount++;
			
			return value;
		}
	}
}
