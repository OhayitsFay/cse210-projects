using System;

class Program
{
    static void Main(string[] args)
    {
        do
        {
            //Core Requirement 1: Ask for the  magic number
            Console.Write("What is the magic number? ");
            int magic_number = int.Parse(Console.ReadLine());

            //Core Requirement 2: Add a loop for the game
            int guess;
            int guess_count = 0;
        
            do
            {
                //Core Requirement 3: Ask for a guess
                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine());
                guess_count++;

                //Core Requirement 4: Check if the guess is higher, lower, or correct
                if (guess < magic_number)
                    Console.WriteLine("Higher");
                else if (guess > magic_number)
                    Console.WriteLine("Lower");
                else
                    Console.WriteLine("You guessed it! ");

            } while (guess != magic_number);

            //Stretch Chaallenge: Inform the user of the number of guesses
            Console.WriteLine($"You guessed the number in the {guess_count} {(guess_count == 1 ? "guess" : "guesses")}.");
            
            //Stretch Challenge: Ask if the user want to play again
            Console.Write("Do you want to play again? (yes/no): ");

        } while (Console.ReadLine().ToLower() == "yes");
    }
}