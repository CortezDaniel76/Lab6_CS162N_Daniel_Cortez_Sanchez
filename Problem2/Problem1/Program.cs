using System;
using CardClasses;

namespace BlackjackTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck deck = new Deck();
            deck.Shuffle();
            BlackjackHand hand = new BlackjackHand(deck, 2);

            Console.WriteLine("Initial Blackjack Hand:");
            Console.WriteLine(hand);

            hand.AddCard(deck.Deal());

            Console.WriteLine("Blackjack Hand after adding a card:");
            Console.WriteLine(hand);

            Console.WriteLine("Does the hand have an ace?");
            Console.WriteLine(hand.HasAce());

            Console.WriteLine("Current score:");
            Console.WriteLine(hand.GetScore());

            Console.WriteLine("Is the hand busted?");
            Console.WriteLine(hand.IsBusted());
        }
    }
}
