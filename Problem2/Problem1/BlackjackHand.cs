using System;
using System.Collections.Generic;
using System.Linq;

namespace CardClasses
{
    public class BlackjackHand : Hand
    {
        // Default constructor to create an empty blackjack hand
        public BlackjackHand() : base()
        {
        }

        // Constructor to create a blackjack hand with specified number of cards dealt from a deck
        public BlackjackHand(Deck deck, int numberOfCards) : base(deck, numberOfCards)
        {
        }

        // Method to determine if the hand has an ace
        public bool HasAce()
        {
            return cards.Any(card => card.Value == 1);
        }

        // Method to get the score of the hand
        public int GetScore()
        {
            int score = 0;
            int numberOfAces = 0;

            foreach (Card card in cards)
            {
                if (card.Value > 10) // For face cards (J, Q, K)
                {
                    score += 10;
                }
                else if (card.Value == 1) // For Ace
                {
                    numberOfAces++;
                    score += 11; // Assume Ace as 11 initially
                }
                else // For other cards (2-10)
                {
                    score += card.Value;
                }
            }

            // Adjust score if it busts and there are aces counted as 11
            while (score > 21 && numberOfAces > 0)
            {
                score -= 10;
                numberOfAces--;
            }

            return score;
        }

        // Method to determine if the hand is busted (score > 21)
        public bool IsBusted()
        {
            return GetScore() > 21;
        }

        public override string ToString()
        {
            string output = base.ToString();
            output += $"Score: {GetScore()}\n";
            output += IsBusted() ? "Busted!\n" : "Not Busted\n";
            return output;
        }
    }
}
