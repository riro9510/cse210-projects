using System;

class Program
{
    static void Main(string[] args)
    {
       Random random = new Random();
        bool playAgain = true;

        while (playAgain)
        {

            int magicNumber = random.Next(1, 101);
            int guess = 0;
            int guessCount = 0;

            Console.WriteLine("Welcome to Guess My Number!");
            Console.WriteLine($"(The magic number is between 1 and 100.)");
            Console.WriteLine($"current magicNumber is {magicNumber}");

            while (guess != magicNumber)
            {
            
                Console.Write("What is your guess? ");
                
              
                while (!int.TryParse(Console.ReadLine(), out guess) || guess < 1 || guess > 100)
                {
                    Console.WriteLine("Please enter a valid number between 1 and 100.");
                }
                
                guessCount++;

                
                if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine("You guessed it!");
                }
            }

       
            Console.WriteLine($"You made {guessCount} guesses.");

         
            Console.Write("Do you want to play again? (yes/no): ");
            string response = Console.ReadLine().ToLower();
            playAgain = response == "yes";
        }

        Console.WriteLine("Thank you for playing!");
    }
}