using System;
using System.Security.Claims;

class Program
{
    static void Main(string[] args)
    {
        //Console.WriteLine("Hello! What is the magic number? ");
        //string userInput = Console.ReadLine();
        //int magicNumber = int.Parse(userInput)
        
        // Random number
        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 200);

        int guessNumber = -1;

        while (guessNumber != magicNumber)
        {
            Console.Write("What is your guess? ");
            guessNumber = int.Parse(Console.ReadLine());
            
            if(guessNumber > magicNumber)
            {
                Console.WriteLine("a little bit lower"); 
            }
            if(guessNumber < magicNumber)
            {
                Console.WriteLine(" a little bit higher"); 
            }
            if(guessNumber == magicNumber)
            {
                Console.WriteLine("That's the one!"); 
            }
        }
       
    }
}