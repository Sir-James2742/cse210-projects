public class BreathingActivity : Activity
{
    public BreathingActivity(string name, string description)
        : base(name, description)
    {
    }
    List<string> breathingPrompts = new List<string>
    {
        "Breathe in",
        "Hold your breath",
        "Breath out",
        "Hold your breath"
    };
    public void Run()
    {
        Console.WriteLine(DisplayStartingMessage());
        ShowSpinner(3);
        Console.WriteLine("For how long would you like to practice breathing? (in seconds)");
        string duration = Console.ReadLine();
        if (!int.TryParse(duration, out int parsedDuration) || parsedDuration <= 0)
        {
            Console.WriteLine("Invalid duration. Please enter a positive number.");
            return;
        }
        else
        {
            setDuration(parsedDuration);
            ShowCountdown(5);
            DateTime endTime = DateTime.Now.AddSeconds(parsedDuration);
            while (DateTime.Now < endTime)
            {
                foreach (string prompt in breathingPrompts)
                {
                    Console.WriteLine(prompt);
                    DotCountdown(4);
                }
            }
            Console.WriteLine(DisplayEndingMessage());
        }
        
    }
}