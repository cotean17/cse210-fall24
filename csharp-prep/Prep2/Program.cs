using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What was your porcentage?");
        string userInput = Console.ReadLine();
        int number = int.Parse(userInput);

        string letter = "";

        if (number >= 90)
        {
            letter = "A";
        }
        else if (number >= 80)
        {
            letter = "B";
        }
        else if (number >= 70)
        {
            letter = "C";
        }
        else if (number >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        Console.WriteLine($"Your grade this semester is: {letter}");

        if (number >= 70)
        {
            Console.WriteLine("Congrats, you passed!");
        }
        else
        {
            Console.WriteLine("Maybe next semester!");
        }
    }
}