using System;

class Program
{
    static void Main(string[] args)
    {
        Journal theJournal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        Console.WriteLine("Welcome to the Journal Program!");

        bool running = true;

        while (running)
        {
            Console.WriteLine();
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Show number of entries");
            Console.WriteLine("6. Quit");
            Console.Write("What would you like to do? ");

            string choice = Console.ReadLine() ?? "";

            if (choice == "1")
            {
                string prompt = promptGenerator.GetRandomPrompt();

                Console.WriteLine();
                Console.WriteLine($"Prompt: {prompt}");
                Console.Write("> ");

                string response = Console.ReadLine() ?? "";
                string date = DateTime.Now.ToShortDateString();

                Entry newEntry = new Entry(date, prompt, response);
                theJournal.AddEntry(newEntry);

                Console.WriteLine("Entry added successfully.");
            }
            else if (choice == "2")
            {
                theJournal.DisplayAll();
            }
            else if (choice == "3")
            {
                Console.Write("Enter the filename: ");
                string filename = Console.ReadLine() ?? "";

                theJournal.SaveToFile(filename);

                Console.WriteLine("Journal saved successfully.");
            }
            else if (choice == "4")
            {
                Console.Write("Enter the filename: ");
                string filename = Console.ReadLine() ?? "";

                theJournal.LoadFromFile(filename);

                Console.WriteLine("Journal loaded successfully.");
            }
            else if (choice == "5")
            {
                Console.WriteLine(
                    $"You have {theJournal.GetEntryCount()} journal entries."
                );
            }
            else if (choice == "6")
            {
                running = false;
                Console.WriteLine("Thank you for using the Journal Program!");
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
            }
        }
    }

    // Creativity: I exceeded the core requirements by adding an entry
    // counter and additional custom journal prompts.
}