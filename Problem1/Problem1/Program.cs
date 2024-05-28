using System;
using CardClasses;

namespace CardTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck deck = new Deck();
            deck.Shuffle();
            Hand hand = new Hand(deck, 5);

            Console.WriteLine("Initial Hand:");
            Console.WriteLine(hand);

            Card newCard = deck.Deal();
            hand.AddCard(newCard);

            Console.WriteLine("Hand after adding a card:");
            Console.WriteLine(hand);

            Card cardToDiscard = hand.GetCard(0);
            hand.Discard(cardToDiscard);

            Console.WriteLine("Hand after discarding a card:");
            Console.WriteLine(hand);

            Console.WriteLine("Does the hand contain the discarded card?");
            Console.WriteLine(hand.Contains(cardToDiscard));

            Console.WriteLine("Index of a specific card in the hand:");
            Console.WriteLine(hand.IndexOf(newCard));
        }
    }
}
