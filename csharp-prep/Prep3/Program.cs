using System;

class Program
{
    static void Main(string[] args)
    {
         // Generate a random magic number between 1 and 100
        Random random = new Random();
        int magicNumber = random.Next(1, 101);

        // Initialize guess to a value outside the range of magicNumber to ensure the loop starts
        int guess = -1;

        // Loop until the user guesses the magic number
        while (guess != magicNumber)
        {
            // Ask user for a guess
            Console.Write("Make a guess: ");
            guess = Convert.ToInt32(Console.ReadLine());

            // Check if the guess is correct
            if (guess == magicNumber)
            {
                Console.WriteLine("Congratulations! You guessed it right!");
            }
            else if (guess < magicNumber)
            {
                Console.WriteLine("Try guessing higher next time.");
            }
            else
            {
                Console.WriteLine("Try guessing lower next time.");
            }
        }
    }
}