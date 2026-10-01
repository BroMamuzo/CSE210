public class ListingActivity : Activity
{
    private List<string> _prompts;
    private Random _random;

    public ListingActivity()
        : base(
            "Listing Activity",
            "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
        _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };

        _random = new Random();
    }

    public void Run()
    {
        StartActivity();

        Console.WriteLine("List as many responses as you can to the following prompt:");
        Console.WriteLine();

        string prompt = _prompts[_random.Next(_prompts.Count)];
        Console.WriteLine($"--- {prompt} ---");

        Console.WriteLine();
        Console.WriteLine("You have a few seconds to think...");
        ShowCountDown(5);

        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("Start listing your responses.");
        Console.WriteLine("Press Enter after each response.");

        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());
        int count = 0;

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string response = Console.ReadLine() ?? "";

            if (DateTime.Now >= endTime)
            {
                break;
            }

            if (!string.IsNullOrWhiteSpace(response))
            {
                count++;
            }
        }

        Console.WriteLine();
        Console.WriteLine($"You listed {count} items.");

        EndActivity();
    }
}