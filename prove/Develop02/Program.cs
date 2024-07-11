using System;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.IO;

class Program
{
    private static Journal journal = new Journal();
    private static List<string> promptList = new List<string>
    {
        "What was the best moment in your day?",
        "Who did you make laugh today?",
        "Where did you go today?",
        "What did you travel today?"
    };

    static void Main(string[] args)
    {
        bool running = true;

        while (running)
        {
            Console.WriteLine("\nWelcome to the Journal App!\nPlease select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.WriteLine("What would you like to do?");
            string selected = Console.ReadLine();

            switch (selected)
            {
                case "1":
                    WriteNewEntry();
                    break;
                case "2":
                    journal.ShowEntries();
                    break;
                case "3":
                    LoadJournalFromFile();
                    break;
                case "4":
                    SaveJournalToFile();
                    break;
                case "5":
                    running = false;
                    break;
            }
        }
    }

    private static void WriteNewEntry()
    {
        Random rand = new Random();
        int promptIndex = rand.Next(promptList.Count);
        string prompt = promptList[promptIndex];

        Console.WriteLine(prompt);
        string response = Console.ReadLine();

        string date = DateTime.Now.ToShortDateString();
        Entry entry = new Entry(prompt, response, date);
        journal.AddEntry(entry);
    }

    private static void SaveJournalToFile()
    {
        Console.Write("Enter filename to save to: ");
        string filename = Console.ReadLine();
        journal.SaveToFile(filename);
    }

    private static void LoadJournalFromFile()
    {
        Console.Write("Enter filename to load from: ");
        string filename = Console.ReadLine();
        journal.LoadFromFile(filename);
    }

    public class Entry
    {
        private string _prompt;
        public string Prompt
        {
            get { return _prompt; }
            set { _prompt = value; }
        }

        private string _response;
        public string Response
        {
            get { return _response; }
            set { _response = value; }
        }

        private string _date;
        public string Date
        {
            get { return _date; }
            set { _date = value; }
        }

        public Entry(string prompt, string response, string date)
        {
            Prompt = prompt;
            Response = response;
            Date = date;
        }

        public override string ToString()
        {
            return $"{Date} - {Prompt}\n{Response}\n";
        }
    }

    public class Journal
    {
        private List<Entry> entries = new List<Entry>();

        public void AddEntry(Entry entry)
        {
            entries.Add(entry);
        }

        public void ShowEntries()
        {
            foreach (var entry in entries)
            {
                Console.WriteLine(entry.ToString());
            }
        }

        public void SaveToFile(string file)
        {
            using (StreamWriter outputFile = new StreamWriter(file))
            {
                foreach (var entry in entries)
                {
                    outputFile.WriteLine($"{entry.Date}|{entry.Prompt}|{entry.Response}");
                }
            }
        }

        public void LoadFromFile(string file)
        {
            if (File.Exists(file))
            {
                entries.Clear();
                string[] lines = File.ReadAllLines(file);

                foreach (string line in lines)
                {
                    string[] parts = line.Split('|');
                    if (parts.Length == 3)
                    {
                        entries.Add(new Entry(parts[1], parts[2], parts[0]));
                    }
                }
            }
            else
            {
                Console.WriteLine("Could not find file.");
            }
        }
    }
}
