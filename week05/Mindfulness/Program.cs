class Program
{
    static void Main(string[] args)
    {
        // Creativity and exceeding requirements:
        // This program keeps a session history by counting how many times
        // each mindfulness activity is completed during the current session.

        int breathingCount = 0;
        int reflectionCount = 0;
        int listingCount = 0;

        bool running = true;

        while (running)
        {
            Console.Clear();

            Console.WriteLine("Mindfulness Program");
            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflecting activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. Show session history");
            Console.WriteLine("  5. Quit");
            Console.WriteLine();
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine() ?? "";

            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    BreathingActivity breathing = new BreathingActivity();
                    breathing.Run();
                    breathingCount++;
                    PauseBeforeMenu();
                    break;

                case "2":
                    ReflectionActivity reflection = new ReflectionActivity();
                    reflection.Run();
                    reflectionCount++;
                    PauseBeforeMenu();
                    break;

                case "3":
                    ListingActivity listing = new ListingActivity();
                    listing.Run();
                    listingCount++;
                    PauseBeforeMenu();
                    break;

                case "4":
                    Console.WriteLine("Session History");
                    Console.WriteLine();
                    Console.WriteLine($"Breathing activities completed: {breathingCount}");
                    Console.WriteLine($"Reflection activities completed: {reflectionCount}");
                    Console.WriteLine($"Listing activities completed: {listingCount}");
                    Console.WriteLine();
                    Console.WriteLine("Press Enter to return to the menu.");
                    Console.ReadLine();
                    break;

                case "5":
                    running = false;
                    Console.WriteLine("Thank you for using the Mindfulness Program.");
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please select a number from 1 to 5.");
                    Thread.Sleep(1500);
                    break;
            }
        }
    }

    static void PauseBeforeMenu()
    {
        Console.WriteLine();
        Console.WriteLine("Returning to the menu...");
        Thread.Sleep(1500);
    }
}
