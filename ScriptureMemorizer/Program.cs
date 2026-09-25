using System;

class Program
{
    static void Main(string[] args)
    {
        // Creativity feature:
        // This program includes a library of three scriptures.
        // The user can choose which scripture they want to practice.
        Console.WriteLine("Scripture Memorizer");
        Console.WriteLine();
        Console.WriteLine("Choose a scripture:");
        Console.WriteLine("1. John 3:16");
        Console.WriteLine("2. Proverbs 3:5-6");
        Console.WriteLine("3. Philippians 4:13");
        Console.WriteLine();
        Console.Write("Enter your choice: ");

        string choice = Console.ReadLine() ?? "";

        Reference reference;
        string text;

        if (choice == "1")
        {
            reference = new Reference("John", 3, 16);
            text = "For God so loved the world that he gave his only begotten Son that whosoever believeth in him should not perish but have everlasting life";
        }
        else if (choice == "2")
        {
            reference = new Reference("Proverbs", 3, 5, 6);
            text = "Trust in the Lord with all thine heart and lean not unto thine own understanding In all thy ways acknowledge him and he shall direct thy paths";
        }
        else if (choice == "3")
        {
            reference = new Reference("Philippians", 4, 13);
            text = "I can do all things through Christ which strengtheneth me";
        }
        else
        {
            Console.WriteLine("Invalid choice.");
            return;
        }

        Scripture scripture = new Scripture(reference, text);

        while (!scripture.IsCompletelyHidden())
        {
            Console.Clear();
            scripture.Display();

            Console.WriteLine();
            Console.Write("Press Enter to hide words or type 'quit' to exit: ");

            string input = Console.ReadLine() ?? "";

            if (input.ToLower() == "quit")
            {
                return;
            }

            scripture.HideRandomWords(3);
        }

        Console.Clear();
        scripture.Display();
    }
}
