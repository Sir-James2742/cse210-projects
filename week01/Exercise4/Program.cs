using System;
using System.Diagnostics.CodeAnalysis;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise4 Project.");
        List<int> numbers = new List<int>();
        int sum = 0;
        int largest = -99999999, smallestPositive = 999999;
        while (true)
        {
            Console.Write("Enter a number and enter 0 to stop: ");
            string response = Console.ReadLine();
            int myNumber = int.Parse(response);
            if (myNumber != 0)
            {
                numbers.Add(myNumber);
            }
            else
            {
                break;
            }

        }
        for (int i = 0; i < numbers.Count; i++)
        {
            sum += numbers[i];
            if (i > largest)
            {
                largest = numbers[i];
            }
            if (numbers[i] <= smallestPositive && numbers[i] > 0)
            {
                smallestPositive = numbers[i];
            }
            

        }
        Console.WriteLine($"The sum is {sum}");
        int average = sum / numbers.Count;
        Console.WriteLine($"The average is {average}");
        Console.WriteLine($"The largest number is {largest}");
        Console.WriteLine($"The smallest positive number is {smallestPositive}");
        

    }
}