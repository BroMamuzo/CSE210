using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter your first number: ");
        int number1 = int.Parse(Console.ReadLine() ?? "");

        Console.Write("Enter your second number: ");
        int number2 = int.Parse(Console.ReadLine() ?? "");

        int result = AddNumbers(number1, number2);

        Console.WriteLine($"The sum is: {result}");
    }

    static int AddNumbers(int firstNumber, int secondNumber)
    {
        return firstNumber + secondNumber;
    }
}
