using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment assignment1 = new Assignment("John", "Algebra");
        Console.WriteLine(assignment1.GetSummary());
        MathAssignment mathAssignment = new MathAssignment("Jane", "Calculus", "Section 5.1", "Problems 1-10");
        Console.WriteLine(mathAssignment.GetHomeWorkList());
        WritingAssignment writingAssignment = new WritingAssignment("Alice", "History", "The Renaissance");
        Console.WriteLine(writingAssignment.GetWritingInformation());
       
    }
}