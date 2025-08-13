public class Activity
{
    private string _name;
    private string _description;
    private int _duration;

    public string getName()
    {
        return _name;
    }
    public void setName(string name)
    {
        _name = name;
    }
    public string getDescription()
    {
        return _description;
    }
    public void setDescription(string description)
    {
        _description = description;
    }
    public int getDuration()
    {
        return _duration;
    }
    public void setDuration(int duration)
    {
        _duration = duration;
    }
    public Activity(string name, string description )
    {
        _name = name;
        _description = description;
        
    }
    public string DisplayStartingMessage()
    {
        return $"Welcome to {_name} activity:\n \n {_description} ";
    }
    public string DisplayEndingMessage()
    {
        return $"\nWell done! You have completed the {_name} activity for {_duration} seconds.";
    }
    public void ShowSpinner(int seconds)
    {
        List<string> spinner = new List<string> { "|", "/", "-", "\\" ,  };
        
        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        int i = 0;
        while (DateTime.Now < endTime)
        {
            string s = spinner[i];
            Console.Write(s);
            Thread.Sleep(500);
            Console.Write("\b \b");
            i++;
            if (i >= spinner.Count)
            {
                i = 0;
            }

        }
    }
    public void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            System.Threading.Thread.Sleep(1000);
            Console.Write("\b \b");
        }
        Console.WriteLine("\rStarting now!");
    }
    public void DotCountdown(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            Console.Write(".");
            System.Threading.Thread.Sleep(1000);
        }
        Console.WriteLine();
    }
}