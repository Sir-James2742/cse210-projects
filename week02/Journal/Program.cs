// I have saved date prompts and responses in a journal entry.

using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        int choice;
        while (true)
        {
            Console.WriteLine("Choose one of the following options:");
            Console.WriteLine("1. write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Save");
            Console.WriteLine("4. Load");
            Console.WriteLine("5. Exit");

            choice = int.Parse(Console.ReadLine());
            if (choice == 1)
            {
            
                Console.WriteLine(journal.promptsGenerator.GetRandomPrompt());
                string response = Console.ReadLine();
                journal.AddEntry(response);
            }
            else if (choice == 2)
            {
                journal.DisplayEntries();
            }
            else if (choice == 3)
            {

                journal.SavetoFile(journal);
                Console.WriteLine("Journal saved successfully.");
            }
            else if (choice == 4)
            {
             journal.LoadfromFile();
                
            }
            else if (choice == 5)
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid choice, please try again.");
            }
        }
    }
   
    
   
}