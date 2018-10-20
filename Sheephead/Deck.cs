using System;
using System.Collections.Generic;

namespace Sheephead
{
    public class Deck
    {
        private List<Card> Cards {get;set;}

        public Deck()
        {
            Cards = new List<Card>();

            Cards.Add(new Card(Suit.Clubs, Rank.Ace));
            Cards.Add(new Card(Suit.Clubs, Rank.Eight));
            Cards.Add(new Card(Suit.Clubs, Rank.Jack));
            Cards.Add(new Card(Suit.Clubs, Rank.King));
            Cards.Add(new Card(Suit.Clubs, Rank.Nine));
            Cards.Add(new Card(Suit.Clubs, Rank.Queen));
            Cards.Add(new Card(Suit.Clubs, Rank.Seven));
            Cards.Add(new Card(Suit.Clubs, Rank.Ten));

            Cards.Add(new Card(Suit.Spades, Rank.Ace));
            Cards.Add(new Card(Suit.Spades, Rank.Eight));
            Cards.Add(new Card(Suit.Spades, Rank.Jack));
            Cards.Add(new Card(Suit.Spades, Rank.King));
            Cards.Add(new Card(Suit.Spades, Rank.Nine));
            Cards.Add(new Card(Suit.Spades, Rank.Queen));
            Cards.Add(new Card(Suit.Spades, Rank.Seven));
            Cards.Add(new Card(Suit.Spades, Rank.Ten));

            Cards.Add(new Card(Suit.Hearts, Rank.Ace));
            Cards.Add(new Card(Suit.Hearts, Rank.Eight));
            Cards.Add(new Card(Suit.Hearts, Rank.Jack));
            Cards.Add(new Card(Suit.Hearts, Rank.King));
            Cards.Add(new Card(Suit.Hearts, Rank.Nine));
            Cards.Add(new Card(Suit.Hearts, Rank.Queen));
            Cards.Add(new Card(Suit.Hearts, Rank.Seven));
            Cards.Add(new Card(Suit.Hearts, Rank.Ten));

            Cards.Add(new Card(Suit.Diamonds, Rank.Ace));
            Cards.Add(new Card(Suit.Diamonds, Rank.Eight));
            Cards.Add(new Card(Suit.Diamonds, Rank.Jack));
            Cards.Add(new Card(Suit.Diamonds, Rank.King));
            Cards.Add(new Card(Suit.Diamonds, Rank.Nine));
            Cards.Add(new Card(Suit.Diamonds, Rank.Queen));
            Cards.Add(new Card(Suit.Diamonds, Rank.Seven));
            Cards.Add(new Card(Suit.Diamonds, Rank.Ten));
        }


        public void Shuffle()
        {
            throw new NotImplementedException();
        }

        public Card this[int index]
        {
            get
            {
                return Cards[index];
            }
        }

    }
}
