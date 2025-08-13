using System;
// for cretaivity , I have ensured that no ivalid input can be put for the duration
class Program
{
    static void Main(string[] args)
    {
        
        Console.WriteLine("Welcome to the Mindfulness Program!");
        Console.WriteLine("Please select an activity:");
        Console.WriteLine("1. Breathing Activity");
        Console.WriteLine("2. Reflecting Activity");
        Console.WriteLine("3. Listing Activity");
        Console.WriteLine("4. Exit");

        string choice = Console.ReadLine();
        switch (choice)
        {
            case "1":
                BreathingActivity breathingActivity = new BreathingActivity("Breathing", "Focus on your breath to relax.");
                breathingActivity.Run();
                break;
            case "2":
                List<string> prompts = new List<string> { "Think of a time when you stood up for someone else.", "Think of a time when you did something really difficult.", "Think of a time when you helped someone in need.","3Think of a time when you did something truly selfless." };
                ReflectingActivity reflectingActivity = new ReflectingActivity("Reflecting", "Reflect on your thoughts and feelings.",  prompts);
                reflectingActivity.Run();
                break;
            case "3":
                List<string> listingPrompts = new List<string> { "Who are people that you appreciate?", "What are personal strengths of yours?", 
                "Who are people that you have helped this week?", "When have you felt the Holy Ghost this month?", "Who are some of your personal heroes?" };
                ListingActivity listingActivity = new ListingActivity("Listing", "List items based on prompts.", listingPrompts);
                listingActivity.Run();
                break;
            case "4":
                Console.WriteLine("Exiting the program. Thank you for participating!"); 
                break;    
            default:
                Console.WriteLine("Invalid choice. Please try again.");
                break;
        }
        
    }
}