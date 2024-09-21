using System;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        
        // Please note we could use a do-while loop here instead
        int userNumber = -1;
        while (userNumber != 0)
        {
            Console.Write("Enter a number (0 when you're done): ");
            
            string userResponse = Console.ReadLine();
            userNumber = int.Parse(userResponse);
            
            // add numbers to the list if it is not 0
            if (userNumber != 0)
            {
                numbers.Add(userNumber);
            }
        }

        // addition of all the numbers
        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }

        Console.WriteLine($"The total is: {sum}");

        // Average

        float average = ((float)sum) / numbers.Count;
        Console.WriteLine($"The average is: {average}");

        // Finding the largest number in the list
        
        int largestNumber = numbers[0];

        foreach (int number in numbers)
        {
            if (number > largestNumber)
            {
                // if this number is greater than the largestNumber, we have found the new max!
                largestNumber = number;
            }
        }

        Console.WriteLine($"The largest number is: {largestNumber}");
    }
}