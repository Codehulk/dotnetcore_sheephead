using System;
namespace Sheephead
{
    public enum Suit
    {
        Clubs,
        Spades,
        Hearts,
        Diamonds
    }

    public enum Rank
    {
        Ace,
        King,
        Queen,
        Jack,
        Ten,
        Nine,
        Eight,
        Seven
    }

    public class Card
    {
        public Suit Suit
        {
            get;
            private set;
        }

        public Rank Rank
        {
            get;
            private set;
        }

        public Card (Suit suit, Rank rank)
        {
            Suit = suit;
            Rank = rank;
        }
    }
}
