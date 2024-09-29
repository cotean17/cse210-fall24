using System;

namespace DailyJournal
{
    class Journal
    {
        public List<Entry> entries;

        public Journal()
        {
            entries = new List<Entry>();
        }

        public void AddEntry(string prompt)
        {
            Console.Write(prompt + " ");
            string answer = Console.ReadLine();
            string date = DateTime.Now.ToString("mm/dd/yyyy");
            entries.Add(new Entry(prompt, answer, date));
        }

        public void DisplayEntries()
        {
            foreach (Entry entry in entries)
            {
                Console.WriteLine(entry.ToString());
            }
        }
        public void SaveToFile()
        {
            Console.Write("Enter Filename: ");
            string filename = Console.ReadLine();

            using (StreamWriter writer = new StreamWriter(filename))
            {
                writer.WriteLine("Date,Prompt,Answer");

                foreach (Entry entry in entries)
                {
                    writer.WriteLine($"{entry.GetDate()},{entry.GetPrompt().Replace(",", ",,")},{entry.GetAnswer().Replace(",", ",,")}");
                }
            }

            Console.WriteLine("Saved");
        }

        public void LoadFromFile()
        {
            Console.Write("Enter filename: ");
            string filename = Console.ReadLine();
            entries.Clear();

            using (StreamReader reader = new StreamReader(filename))
            {
                string headerLine = reader.ReadLine();

                while (!reader.EndOfStream)
                {
                    string entryLine = reader.ReadLine();
                    string[] fields = entryLine.Split(',');

                    string date = fields[0];
                    string prompt = fields[1].Replace(",,", ",");
                    string answer = fields[2].Replace(",,", ",");

                    entries.Add(new Entry(prompt, answer, date));
                }
            }

            Console.WriteLine("Loaded");
        }
    }
}