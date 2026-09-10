using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your favorite number? ");
        string answer = Console.ReadLine() ?? "";
        int number = int.Parse(answer);

        for (int i = 1; i <= 5; i++)
        {
            Console.WriteLine($"{i}: {number}");
        }
    }
}
