using System;

namespace Poker.Game
{
    /// <summary>
    ///     Generic base player for others to derive from
    /// </summary>
    public class BasePlayer
    {
        public Hand Hand { get; }
        public string ID { get; }
        
        public BasePlayer( string id )
        {
            Hand = new Hand();
            ID = id;
        }
    }
}
