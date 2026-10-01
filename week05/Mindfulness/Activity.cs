public class Activity
{
    private string _name;
    private string _description;
    private int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
        _duration = 0;
    }

    public void StartActivity()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name}.");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();

        Console.Write("How long, in seconds, would you like for your session? ");
        _duration = int.Parse(Console.ReadLine()!);

        Console.WriteLine();
        Console.WriteLine("Get ready...");
        ShowSpinner(3);
        Console.WriteLine();
    }

    public void EndActivity()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!!");
        ShowSpinner(2);

        Console.WriteLine();
        Console.WriteLine(
            $"You have completed another {_duration} seconds of the {_name}.");

        ShowSpinner(3);
        Console.WriteLine();
    }

    public void ShowSpinner(int seconds)
    {
        string[] symbols = { "|", "/", "-", "\\" };

        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        int index = 0;

        while (DateTime.Now < endTime)
        {
            Console.Write(symbols[index]);
            Thread.Sleep(250);
            Console.Write("\b \b");

            index = (index + 1) % symbols.Length;
        }
    }

    public void ShowCountDown(int seconds)
    {
        DateTime endTime = DateTime.Now.AddSeconds(seconds);

        while (DateTime.Now < endTime)
        {
            int remaining = (int)(endTime - DateTime.Now).TotalSeconds + 1;

            Console.Write(remaining);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }

    public int GetDuration()
    {
        return _duration;
    }
}