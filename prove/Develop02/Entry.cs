using System;

namespace DailyJournal
{
    class Entry
    {
        public string _prompt;
        public string _answer;
        public string _date;

        public Entry(string prompt, string answer, string date)
        {
            _prompt = prompt;
            _answer = answer;
            _date = date;
        }

        public string GetPrompt()
        {
            return _prompt;
        }

        public string GetAnswer()
        {
            return _answer;
        }

        public string GetDate()
        {
            return _date;
        }

        public override string ToString()
        {
            return $"Date: {_date} - Prompt: {_prompt} \n{_answer}\n";
        }
    }
}