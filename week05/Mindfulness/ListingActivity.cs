public class ListingActivity : Activity
{
    private List<string> _prompts;
    private int _count;

    public ListingActivity(string name, string description, List<string> prompts)
        : base(name, description)
    {
        _prompts = prompts;
        _count = 0;
    }
    public void Run()
    {
        Console.WriteLine(DisplayStartingMessage());
        Console.WriteLine("For how long would you like to list items? (in seconds)");
        string durationInput = Console.ReadLine();
        if (!int.TryParse(durationInput, out int duration) || duration <= 0)
        {
            Console.WriteLine("Invalid duration. Please enter a positive number.");
            return;
        }
        else
        {
            DateTime endTime = DateTime.Now.AddSeconds(duration);
            while (DateTime.Now < endTime)
            {
                GetRandomPrompt();
                List<string> userList = GetListFromUser();
                Console.WriteLine($"You listed {userList.Count} items.");
                ShowSpinner(3);
                Console.WriteLine(DisplayEndingMessage());
            }
        }
    }
    public void GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        Console.WriteLine($"_____ {_prompts[index]}____");
        Console.WriteLine("");
    }
    public List<string> GetListFromUser()
    {
        List<string> userList = new List<string>();
        Console.WriteLine("Please enter your responses (type 'done' to finish):");
        string input;
        while ((input = Console.ReadLine()) != "done")
        {
            if (!string.IsNullOrWhiteSpace(input))
            {
                userList.Add(input);
                _count++;
            }
        }
        return userList;
    }

}