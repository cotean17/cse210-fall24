using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcomeMessage();

        string username = PromptUsername();
        int userNumber = PromptUserNumber();

        int squaredNumber = SquareNumber(userNumber);

        DisplayResult(username, squaredNumber);
    }

    static void DisplayWelcomeMessage()
    {
        Console.WriteLine("Hey there, welcome to the program!");
    }

    static string PromptUsername()
    {
        Console.Write("Please insert your name: ");
        string name = Console.ReadLine();

        return name;
    }

    static int PromptUserNumber()
    {
        Console.Write("What is your favorite number?: ");
        int number = int.Parse(Console.ReadLine());

        return number;
    }

    static int SquareNumber(int number)
    {
        int square = number * number;
        return square;
    }

    static void DisplayResult(string name, int square)
    {
        Console.WriteLine($"{name}, the square of your number is {square}");
    }
}
