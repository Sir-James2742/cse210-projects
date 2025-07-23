using System;
// I have enabled the users to enter any verse and reference of their choice and also included error handling for invalid inputs. 
class Program
{
    static void Main(string[] args)
    {
       
        Console.Write("Please enter the scripture reference (e.g., 'John 3 16' or 'Proverbs 5 18-20'): ");
        string referenceInput = Console.ReadLine().Trim();
        

        if (string.IsNullOrEmpty(referenceInput))
        {
            Console.WriteLine("Error: Reference cannot be empty.");
            return;
        }

        string[] parts = referenceInput.Split(' ', StringSplitOptions.RemoveEmptyEntries);

       
        if (parts.Length < 3)
        {
            Console.WriteLine("Error: Invalid format. Expected: 'Book Chapter Verse' (e.g., 'John 3 16').");
            return;
        }

        string book = parts[0];
        int chapter, startVerse, endVerse;

        try
        {
            chapter = int.Parse(parts[1]);

         
            string[] verseParts = parts[2].Split('-');
            startVerse = int.Parse(verseParts[0]);
            endVerse = (verseParts.Length > 1) ? int.Parse(verseParts[1]) : startVerse;
        }
        catch (FormatException)
        {
            Console.WriteLine("Error: Chapter and verse must be numbers.");
            return;
        }

        Reference reference = (startVerse == endVerse)
            ? new Reference(book, chapter, startVerse)
            : new Reference(book, chapter, startVerse, endVerse);

        // Get scripture text
        Console.Write("Enter the scripture text: ");
        string text = Console.ReadLine().Trim();

        if (string.IsNullOrEmpty(text))
        {
            Console.WriteLine("Error: Scripture text cannot be empty.");
            return;
        }

        List<Word> words = text.Split(' ')
                       .Select(word => new Word(word))
                       .ToList();
        Scripture scripture = new Scripture(reference, words);

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress Enter to hide words or type 'quit' to exit");

            string input = Console.ReadLine()?.ToLower().Trim();

            if (input == "quit")
                break;

            
            scripture.HideRandomWords(1);

            
            if (scripture.IsCompletelyHidden())
            {
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());
                
                Console.ReadKey();
                break;
            }
        }

    }
}