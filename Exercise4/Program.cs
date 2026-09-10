using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<string> names = new List<string>();

        Console.Write("Enter a name: ");
        names.Add(Console.ReadLine() ?? "");

        Console.Write("Enter another name: ");
        names.Add(Console.ReadLine() ?? "");

        Console.WriteLine("\nNames in the list:");

        foreach (string name in names)
        {
            Console.WriteLine(name);
        }
    }
}
