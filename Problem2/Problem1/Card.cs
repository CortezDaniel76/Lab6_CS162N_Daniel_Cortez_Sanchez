using System;

namespace CardClasses
{
    public class Card
    {
        public int Value { get; set; }
        public int Suit { get; set; }

        public Card(int value, int suit)
        {
            Value = value;
            Suit = suit;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Card c = (Card)obj;
            return (Value == c.Value) && (Suit == c.Suit);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode() ^ Suit.GetHashCode();
        }

        public override string ToString()
        {
            string[] suits = { "Hearts", "Diamonds", "Clubs", "Spades" };
            string[] values = { "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King" };

            return $"{values[Value - 1]} of {suits[Suit - 1]}";
        }
    }
}
