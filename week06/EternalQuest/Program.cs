using System;

class Program
{
    static void Main(string[] args)
    {
        GoalManager goalManager = new GoalManager();

        bool running = true;

        while (running)
        {
            Console.Clear();

            Console.WriteLine("======================================");
            Console.WriteLine("          ETERNAL QUEST");
            Console.WriteLine("======================================");

            goalManager.DisplayScore();

            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");

            Console.Write("\nSelect a choice: ");
            string choice = Console.ReadLine() ?? "";

            switch (choice)
            {
                case "1":
                    CreateGoal(goalManager);
                    break;

                case "2":
                    Console.Clear();
                    goalManager.DisplayGoals();
                    Pause();
                    break;

                case "3":
                    goalManager.SaveGoals("goals.txt");
                    Pause();
                    break;

                case "4":
                    goalManager.LoadGoals("goals.txt");
                    Pause();
                    break;

                case "5":
                    RecordEvent(goalManager);
                    break;

                case "6":
                    running = false;
                    Console.WriteLine("\nThank you for using Eternal Quest!");
                    break;

                default:
                    Console.WriteLine("\nInvalid choice. Please select 1-6.");
                    Pause();
                    break;
            }
        }
    }

    static void CreateGoal(GoalManager goalManager)
    {
        Console.Clear();

        Console.WriteLine("Create New Goal");
        Console.WriteLine("----------------");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");

        Console.Write("\nWhich type of goal would you like to create? ");
        string goalType = Console.ReadLine() ?? "";

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine() ?? "";

        Console.Write("What is a short description of this goal? ");
        string description = Console.ReadLine() ?? "";

        Console.Write("How many points is this goal worth? ");
        int points = GetIntegerInput();

        if (goalType == "1")
        {
            SimpleGoal goal = new SimpleGoal(
                name,
                description,
                points);

            goalManager.AddGoal(goal);

            Console.WriteLine("\nSimple goal created successfully.");
        }
        else if (goalType == "2")
        {
            EternalGoal goal = new EternalGoal(
                name,
                description,
                points);

            goalManager.AddGoal(goal);

            Console.WriteLine("\nEternal goal created successfully.");
        }
        else if (goalType == "3")
        {
            Console.Write("How many times must this goal be completed? ");
            int targetAmount = GetIntegerInput();

            Console.Write("How many bonus points should be awarded when completed? ");
            int bonus = GetIntegerInput();

            ChecklistGoal goal = new ChecklistGoal(
                name,
                description,
                points,
                targetAmount,
                bonus);

            goalManager.AddGoal(goal);

            Console.WriteLine("\nChecklist goal created successfully.");
        }
        else
        {
            Console.WriteLine("\nInvalid goal type. The goal was not created.");
        }

        Pause();
    }

    static void RecordEvent(GoalManager goalManager)
    {
        Console.Clear();

        goalManager.DisplayGoals();

        if (goalManager.GetGoalCount() == 0)
        {
            Pause();
            return;
        }

        Console.Write("\nWhich goal did you accomplish? ");
        int goalNumber = GetIntegerInput();

        goalManager.RecordEvent(goalNumber);

        Pause();
    }

    static int GetIntegerInput()
    {
        while (true)
        {
            string input = Console.ReadLine() ?? "";

            if (int.TryParse(input, out int number) && number >= 0)
            {
                return number;
            }

            Console.Write("Please enter a valid number: ");
        }
    }

    static void Pause()
    {
        Console.WriteLine("\nPress Enter to continue...");
        Console.ReadLine();
    }

    /*
     * CREATIVITY AND EXCEEDING REQUIREMENTS:
     *
     * I added a level and milestone system to make the Eternal Quest
     * program more engaging. The user earns a new level for every
     * 500 points earned. The current level is displayed together with
     * the score, giving the user an additional sense of progress.
     *
     * I also added validation for numeric input so that the program
     * does not crash when the user enters invalid information.
     */
}
