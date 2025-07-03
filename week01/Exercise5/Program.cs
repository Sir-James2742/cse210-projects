using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise5 Project.");
        DisplayMessage();
        string userName = PromptUserName();
        int userNumber = PromptUserNumber();
        int squaredNumber = SquareNumber(userNumber);   
        DisplayResult(userName,  squaredNumber);

    }
    static void DisplayMessage()
    {
        Console.WriteLine("welcome to this program");
    }
    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();
        return name;
    }
    static int PromptUserNumber()
    {
        Console.Write("Enter your favorite number: ");
        string number = Console.ReadLine();
        int num = int.Parse(number);
        return num;
    }
    static int SquareNumber(int number)
    {
        return number * number;
    }
    static void DisplayResult(string name,  int squaredNumber)
    {
        Console.WriteLine($"{name}, the square of your number is {squaredNumber}.");
    }
}