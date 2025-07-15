public class Journal
{
    public List<Entry> entries;
    public PromptsGenerator promptsGenerator;

    public Journal()
    {
        entries = new List<Entry>();
        promptsGenerator = new PromptsGenerator();
    }

    public void AddEntry(string response)
    {
        string date = DateTime.Now.ToString("yyyy-MM-dd");
        string prompt = promptsGenerator.GetRandomPrompt();
        Entry entry = new Entry(date, prompt, response);
        entries.Add(entry);
    }

    public void DisplayEntries()
    {
        foreach (var entry in entries)
        {
            Console.WriteLine(entry);
            Console.WriteLine("--------------------");
        }
    }
    public void SavetoFile(Journal journal)
    {

        Console.WriteLine("What is the name of the file you want to save to?");
        string filename = Console.ReadLine();
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (var entry in journal.entries)
            {
                writer.WriteLine(entry.ToString());

            }
        }
    }
    public  void LoadfromFile()
    {
        Console.WriteLine("From which file do you want to load the journal?");
        string filename = Console.ReadLine();
        string lines = System.IO.File.ReadAllText(filename);
        string[] entries = lines.Split(new[] { "--------------------" }, StringSplitOptions.RemoveEmptyEntries);
        foreach (var entry in entries)
        {
            string[] parts = entry.Split(new[] { '\n' }, 3);
            if (parts.Length == 3)
            {
                string date = parts[0].Trim();
                string prompt = parts[1].Trim();
                string response = parts[2].Trim();
                Console.WriteLine($"Date: {date} {prompt}");
                Console.WriteLine(response);

            }
        }
    }
}