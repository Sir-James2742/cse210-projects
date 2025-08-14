using System;
// I have added negative goals to reduce the number of points when negative events occur
class Program
{
    static void Main(string[] args)
    {

        GoalManager manager = new GoalManager();
        string filename = "goals.txt";

        manager.LoadGoals(filename);

        Console.WriteLine("Welcome to the Goal Tracker Program!");

        bool running = true;
        while (running)
        {
            manager.DisplayScore();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Record Event");
            Console.WriteLine("4. Save Goals");
            Console.WriteLine("5. Load Goals");
            Console.WriteLine("6. Quit");

            Console.Write("Select a choice from the menu: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateNewGoal(manager);
                    break;
                case "2":
                    manager.DisplayGoals();
                    break;
                case "3":
                    RecordGoalCompletion(manager);
                    break;
                case "4":
                    manager.SaveGoals(filename);
                    Console.WriteLine("Goals saved successfully!");
                    break;
                case "5":
                    manager.LoadGoals(filename);
                    Console.WriteLine("Goals loaded successfully!");
                    break;
                case "6":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }

        Console.WriteLine("Goodbye!");
    }

    static void CreateNewGoal(GoalManager manager)
    {
        Console.WriteLine("\nThe types of Goals are:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.WriteLine("4. Negative Goal -Creative");
        Console.WriteLine("5. Progress Goal -Creative");

        Console.Write("Which type of goal would you like to create? ");
        string typeChoice = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();

        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();

        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());

        Goal goal = null;

        switch (typeChoice)
        {
            case "1":
                goal = new SimpleGoal(name, description, points);
                break;
            case "2":
                goal = new EternalGoal(name, description, points);
                break;
            case "3":
                Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                int targetCount = int.Parse(Console.ReadLine());
                Console.Write("What is the bonus for accomplishing it that many times? ");
                int bonusPoints = int.Parse(Console.ReadLine());
                goal = new ChecklistGoal(name, description, points, targetCount, bonusPoints);
                break;
            case "4":
                goal = new NegativeGoal(name, description, points);
                break;
            case "5":
                Console.Write("What is the target progress amount? ");
                int targetProgress = int.Parse(Console.ReadLine());
                goal = new ProgressGoal(name, description, points, targetProgress);
                break;
            default:
                Console.WriteLine("Invalid goal type.");
                return;
        }

        manager.AddGoal(goal);
        Console.WriteLine("Goal added successfully!");
    }

    static void RecordGoalCompletion(GoalManager manager)
    {
        manager.DisplayGoals();
        if (manager.GetGoals().Count == 0) return;

        Console.Write("Which goal did you accomplish? ");
        if (int.TryParse(Console.ReadLine(), out int goalIndex) && goalIndex > 0 && goalIndex <= manager.GetGoals().Count)
        {
            manager.RecordGoalCompletion(goalIndex - 1);
        }
        else
        {
            Console.WriteLine("Invalid goal selection.");
        }
    }
}


public static class GoalManagerExtensions
{
    public static List<Goal> GetGoals(this GoalManager manager)
    {
        
        var field = typeof(GoalManager).GetField("_goals", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        return (List<Goal>)field.GetValue(manager);
    }
}
