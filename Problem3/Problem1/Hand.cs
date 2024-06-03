using System;
using System.Collections.Generic;

namespace CardClasses
{
    public class Hand
    {
        protected List<Card> cards;

        public Hand()
        {
            cards = new List<Card>();
        }

        public Hand(Deck deck, int numberOfCards)
        {
            cards = new List<Card>();
            for (int i = 0; i < numberOfCards; i++)
            {
                if (!deck.IsEmpty)
                {
                    cards.Add(deck.Deal());
                }
            }
        }

        public int NumCards
        {
            get
            {
                return cards.Count;
            }
        }

        public bool IsEmpty
        {
            get
            {
                return cards.Count == 0;
            }
        }

        public void AddCard(Card card)
        {
            cards.Add(card);
        }

        public Card Discard(Card card)
        {
            if (cards.Contains(card))
            {
                cards.Remove(card);
                return card;
            }
            return null;
        }

        public Card GetCard(int index)
        {
            if (index >= 0 && index < cards.Count)
            {
                return cards[index];
            }
            return null;
        }

        public bool Contains(Card card)
        {
            return cards.Contains(card);
        }

        public bool Contains(int value, int suit)
        {
            return cards.Exists(c => c.Value == value && c.Suit == suit);
        }

        public bool Contains(int value)
        {
            return cards.Exists(c => c.Value == value);
        }

        public int IndexOf(Card card)
        {
            return cards.IndexOf(card);
        }

        public int IndexOf(int value, int suit)
        {
            return cards.FindIndex(c => c.Value == value && c.Suit == suit);
        }

        public int IndexOf(int value)
        {
            return cards.FindIndex(c => c.Value == value);
        }

        public override string ToString()
        {
            string output = "";
            foreach (Card c in cards)
            {
                output += (c.ToString() + "\n");
            }
            return output;
        }
    }
}
