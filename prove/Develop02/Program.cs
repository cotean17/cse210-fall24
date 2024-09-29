using System;

namespace DailyJournal
{
    class Program
    {
        static void Main(string[] args)
        {
            Journal journal = new Journal();

            List<string> prompts = new List<string>
            {
                "Who was the most interesting person I interacted with today?",
                "What was the best part of my day?",
                "How did I see the hand of the Lord in my life today?",
                "What was the strongest emotion I felt today?",
                "If I had one thing I could do over today, what would it be?",
                "What was your favorite part of your day? ",
                "What has been something difficult lately?",
                "Who did you see today? and what did you do with them?",
                "What did you learn today?",
                "What have you done lately that took you out of your comfort zone? ",
                "What would you like to do to take care of your body? ",
                "What do you most wish for tomorrow? ",
                "What have you done lately that help you to take care of your spirituality? ",
                "What crazy news have you hear lately? ",
                "How did you demonstrate your love through actions to your family today? ",
            };

            bool quit = false;
            while (!quit)
            {
                Console.WriteLine("\nHey there! Good to see you here and share part of your life with me!");
                Console.WriteLine("Please Select one of the following choices:");
                Console.WriteLine("1. Write");
                Console.WriteLine("2. Display");
                Console.WriteLine("3. Save");
                Console.WriteLine("4. Load");
                Console.WriteLine("5. Quit");

                Console.WriteLine("\nWhat do you want to do? ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        string prompt = GetRandomPrompt(prompts);
                        journal.AddEntry(prompt);
                        break;
                    case "2":
                        journal.DisplayEntries();
                        break;
                    case "3":
                        journal.SaveToFile();
                        break;
                    case "4":
                        journal.LoadFromFile();
                        break;
                    case "5":
                        quit = true;
                        break;
                    default:
                        Console.WriteLine("No valid choice.");
                        break;
                }
            }
            Console.WriteLine("Keep recording memories. Come to share them any time!");
        }

        static string GetRandomPrompt(List<string> prompts)
        {
            Random random = new Random();
            int index = random.Next(prompts.Count);
            return prompts[index];
        }
    }
}