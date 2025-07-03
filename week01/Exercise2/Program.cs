using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise2 Project.");
        Console.Write("Enter the percentage scored " );
        string grade = Console.ReadLine();
        int scoredGrade = int.Parse(grade);
        string letter = "";
        string sign = "";
        if (scoredGrade >= 90)
        {
            letter = "A";
        }
        else if (scoredGrade < 90 && scoredGrade >= 80)
        {
            letter = "B";
        }
        else if (scoredGrade < 80 && scoredGrade >= 70)
        {
            letter = "C";
        }
        else if (scoredGrade < 70 && scoredGrade >= 60)
        {
            letter = "D";
        }
        else if (scoredGrade < 60)
        {
            letter = "F";
        }
        int rem;
        rem = scoredGrade % 10;
        if (rem >= 7)
        {
            sign = "+";
        }
        else
        {
            sign = "-";
        }

        Console.WriteLine($"Your Grade is {sign}{letter}");
        if (scoredGrade > 70)
        {
            Console.WriteLine("You have pased");
        }
        else
        {
            Console.WriteLine("You can still improve");
        }
    }
}