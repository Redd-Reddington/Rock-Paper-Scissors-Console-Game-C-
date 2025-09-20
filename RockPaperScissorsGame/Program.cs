using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace RockPaperScissorsGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Rock-Paper-Scissors!");


            Random rnd = new Random();
            int rounds;
            bool playAgain = true;
            int playerScore = 0;
            int computerScore = 0;


            while (playAgain)
            {
                // Set number of rounds
                while (true)
                {
                    Console.Write("Enter number of rounds to play (Best of 3, 5, etc.): ");
                    if (int.TryParse(Console.ReadLine(), out rounds) && rounds > 0)
                        break;
                    Console.WriteLine("Invalid input. Please enter a positive number.");
                }


                string[] choices = { "Rock", "Paper", "Scissors" };


                for (int round = 1; round <= rounds; round++)
                {
                    Console.WriteLine($"\n Round {round} of {rounds}");

                    string playerChoice;
                    while (true)
                    {
                        Console.Write("Choose Rock, Paper, or Scissors: ");
                        playerChoice = Console.ReadLine().Trim().ToLower();

                        if (playerChoice == "rock" || playerChoice == "paper" || playerChoice == "scissors")
                            break;

                        Console.WriteLine("Invalid choice! Try again.");
                    }

                    string computerChoice = choices[rnd.Next(choices.Length)];
                    Console.WriteLine($"Computer chose: {computerChoice}");

                    // Determine round winner
                    if (playerChoice == computerChoice.ToLower())
                    {
                        Console.WriteLine("It's a tie!");
                    }
                    else if ((playerChoice == "rock" && computerChoice == "Scissors") ||
                             (playerChoice == "paper" && computerChoice == "Rock") ||
                             (playerChoice == "scissors" && computerChoice == "Paper"))
                    {
                        Console.WriteLine("You win this round!");
                        playerScore++;
                    }
                    else
                    {
                        Console.WriteLine("Computer wins this round!");
                        computerScore++;
                    }

                    Console.WriteLine($"Score: You {playerScore} - {computerScore} Computer");
                }



                // Final Winner Declaration
                Console.WriteLine("\nFinal Results:");
                if (playerScore > computerScore)
                    Console.WriteLine("[WINNER!] You are the grand champion!");
                else if (computerScore > playerScore)
                    Console.WriteLine("[COMPUTER WINS] Better luck next time!");
                else
                    Console.WriteLine("[DRAW] It's a tie!");
                Console.WriteLine($"Final Score: You {playerScore} - {computerScore} Computer");



                // Reset scores for next game
                playerScore = 0;
                computerScore = 0;



                // Ask if the player wants to play again
                // Play Again Option
                Console.Write("\nWill you play again? (Y/N): ");
                string response = Console.ReadLine().ToUpper();
                playAgain = response == "Y";

                // Clear the console for a fresh start
                Console.WriteLine("Preparing new game...");
                System.Threading.Thread.Sleep(3000); // 3-second delay
                Console.Clear();


                if (playAgain)
                {
                    Console.WriteLine("Great! Let's play again.");
                }
                else
                {
                    Console.WriteLine("Thanks for playing! Goodbye!");
                }



            }

        }
    }
}
