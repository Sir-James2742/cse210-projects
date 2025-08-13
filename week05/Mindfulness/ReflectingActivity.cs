public class ReflectingActivity : Activity
{
    private List<string> _prompts;
    private List<string> _questions;

    public ReflectingActivity(string name, string description,  List<string> prompts)
        : base(name, description)
    {
        _prompts = prompts;
        
    }
    public void Run()
    {
        Console.WriteLine(DisplayStartingMessage());
        ShowSpinner(3);
        Console.WriteLine("For how long would you like to reflect? (in seconds)");
        string durationInput = Console.ReadLine();
        if (!int.TryParse(durationInput, out int duration) || duration <= 0)
        {
            Console.WriteLine("Invalid duration. Please enter a positive number.");
            return;
        }
        else
        {
            setDuration(duration);
            DateTime endTime = DateTime.Now.AddSeconds(duration);
            while (DateTime.Now < endTime)
            {
                DisplayPrompt();
                ShowSpinner(3);
                DisplayQuestions();
                Console.WriteLine(DisplayEndingMessage());
               
            }
        }
        
    }
    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        string prompt = _prompts[index];
        return prompt;
    }
    public void DisplayPrompt()
    {
        string prompt = GetRandomPrompt();
        Console.WriteLine(prompt);
    }
    public void DisplayQuestions()
    {
        _questions = new List<string>()
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

        foreach (string question in _questions)
        {
            Console.WriteLine($"_____{question}____");
            ShowSpinner(5);
            Console.WriteLine("");
            
        }
        
    }
   

}