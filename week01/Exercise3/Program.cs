using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise3 Project.");
        string response;
       do
        {
            Random randomNumber = new Random();
            int number = randomNumber.Next(1, 11);
            int noOfGuesses = -1;
            while (noOfGuesses!=number)
            {
                Console.Write("Enter a guess");
                string guess = Console.ReadLine();
                int myGuess = int.Parse(guess);
                if (myGuess < 1 || myGuess > 10)
                {
                    Console.WriteLine("Please enter a number between 1 and 10!");
                    continue;
                }
                if (myGuess > number)
                {
                    Console.WriteLine("Higher");
                }
                else if (myGuess < number)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine("You guessed it");
                    break;
                }

            }
           Console.Write("Do you want to continue(yes/no)");
          response = Console.ReadLine();
        }
        while (response == "yes");
    }
}