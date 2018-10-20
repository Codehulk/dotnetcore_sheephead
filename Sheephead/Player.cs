using System;
using System.Collections.Generic;

namespace Sheephead
{
    public class Player
    {
        public Player(string name)
        {
            Name = name;
            Hand = new Hand();
        }

        public string Name {get; private set;}
        public Hand Hand { get; private set; }
        public IList<Card[]> Tricks { get; private set; }

        internal bool WantsToPick()
        {
            // TODO: Strategy

            throw new NotImplementedException();
        }

        internal Card PlayCard()
        {
            // TODO: Strategy

            throw new NotImplementedException();
        }

        internal int ScoreHand()
        {
            throw new NotImplementedException();
        }

        internal void Pick(Blind blind)
        {
            foreach (var c in blind.Cards)
            {
                Hand.AddCard(c);
            }
        }

        internal Blind Bury()
        {
            // TODO: Strategy
            throw new NotImplementedException();
        }
    }
}
