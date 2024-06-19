using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomNumber = new Random();

        int magicNum = randomNumber.Next(1, 11);
        int guess = 0;
        int guessCount = 0;
        Console.WriteLine("Ready, set, GUESS!");

        while (guess != magicNum)
        {
            Console.Write("What is your guess? ");
            guess = int.Parse(Console.ReadLine());
            guessCount++;

            if (guess < magicNum)
            {
                Console.WriteLine("Higher");
            }
            else if (guess > magicNum)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("You guessed it!");
                Console.WriteLine($"It took you {guessCount} guesses.");
            }
        }
    }
}