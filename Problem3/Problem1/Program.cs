using System;
using CardClasses;

namespace BlackjackGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int playerWins = 0;
            int dealerWins = 0;
            bool playAgain = true;

            while (playAgain)
            {
                Deck deck = new Deck();
                deck.Shuffle();

                BlackjackHand playerHand = new BlackjackHand(deck, 2);
                BlackjackHand dealerHand = new BlackjackHand(deck, 2);

                Console.WriteLine("Player's Hand:");
                Console.WriteLine(playerHand);

                Console.WriteLine("Dealer's Hand:");
                Console.WriteLine(dealerHand.GetCard(0) + "\nHidden Card");

                // Player's turn
                bool playerStands = false;
                while (!playerHand.IsBusted() && !playerStands)
                {
                    Console.WriteLine("\nDo you want to HIT or STAND?");
                    string input = Console.ReadLine().ToUpper();

                    if (input == "HIT")
                    {
                        playerHand.AddCard(deck.Deal());
                        Console.WriteLine("\nPlayer's Hand:");
                        Console.WriteLine(playerHand);

                        if (playerHand.IsBusted())
                        {
                            Console.WriteLine("Player is busted!");
                        }
                    }
                    else if (input == "STAND")
                    {
                        playerStands = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input, please enter HIT or STAND.");
                    }
                }

                // Dealer's turn
                if (!playerHand.IsBusted())
                {
                    Console.WriteLine("\nDealer's Hand:");
                    Console.WriteLine(dealerHand);

                    while (dealerHand.GetScore() <= 16)
                    {
                        dealerHand.AddCard(deck.Deal());
                        Console.WriteLine("\nDealer hits:");
                        Console.WriteLine(dealerHand);
                    }

                    if (dealerHand.IsBusted())
                    {
                        Console.WriteLine("Dealer is busted!");
                    }
                }

                // Determine the winner
                if (playerHand.IsBusted())
                {
                    Console.WriteLine("Dealer wins this round!");
                    dealerWins++;
                }
                else if (dealerHand.IsBusted() || playerHand.GetScore() > dealerHand.GetScore())
                {
                    Console.WriteLine("Player wins this round!");
                    playerWins++;
                }
                else if (playerHand.GetScore() < dealerHand.GetScore())
                {
                    Console.WriteLine("Dealer wins this round!");
                    dealerWins++;
                }
                else
                {
                    Console.WriteLine("It's a tie!");
                }

                // Display scores
                Console.WriteLine($"\nScore: Player {playerWins} - Dealer {dealerWins}");

                // Ask to play again
                Console.WriteLine("\nDo you want to play again? (yes/no)");
                string response = Console.ReadLine().ToLower();
                playAgain = response == "yes";
            }

            Console.WriteLine("\nThanks for playing!");
        }
    }
}
