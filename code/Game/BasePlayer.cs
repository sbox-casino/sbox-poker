namespace Poker.Game
{
	/// <summary>
	/// Generic base player for others to derive from
	/// </summary>
	public class BasePlayer
	{
		public HoleCards Hand { get; }
		public string ID { get; }

		public BasePlayer( string id )
		{
			Hand = new HoleCards();
			ID = id;
		}
	}
}
