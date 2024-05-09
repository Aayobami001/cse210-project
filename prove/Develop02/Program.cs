// using System;

// class Program
// {
//     static void Main(string[] args)
//     {
//         Console.WriteLine("Hello Develop02 World!");
//     }
// }

using System;
using System.Collections.Generic;
using System.IO;

class Entry {
    public string Prompt { get; set; }
    public string Response { get; set; }
    public string Date { get; set; }
    public string AdditionalInfo { get; set; }

    public Entry(string prompt, string response, string date, string additionalInfo) {
        Prompt = prompt;
        Response = response;
        Date = date;
        AdditionalInfo = additionalInfo;
    }

    public override string ToString() {
        return $"{Date}: {Prompt}\nResponse: {Response}\nAdditional Info: {AdditionalInfo}\n";
    }
}

class Journal {
    private List<Entry> entries;

    public Journal() {
        entries = new List<Entry>();
    }

    public void AddEntry(string prompt, string response, string date, string additionalInfo) {
        entries.Add(new Entry(prompt, response, date, additionalInfo));
    }

    public void DisplayJournal() {
        foreach (Entry entry in entries) {
            Console.WriteLine(entry);
        }
    }

    public void SaveToFile(string filename) {
        using (StreamWriter writer = new StreamWriter(filename)) {
            foreach (Entry entry in entries) {
                writer.WriteLine($"{entry.Date}|{entry.Prompt}|{entry.Response}|{entry.AdditionalInfo}");
            }
        }
    }

    public void LoadFromFile(string filename) {
        entries.Clear();
        using (StreamReader reader = new StreamReader(filename)) {
            string line;
            while ((line = reader.ReadLine()) != null) {
                string[] parts = line.Split('|');
                if (parts.Length == 4) {
                    string date = parts[0];
                    string prompt = parts[1];
                    string response = parts[2];
                    string additionalInfo = parts[3];
                    entries.Add(new Entry(prompt, response, date, additionalInfo));
                }
            }
        }
    }
}

class Program {
    static void Main(string[] args) {
        Console.WriteLine("Welcome to the Journal Program!");
        Console.WriteLine("Please select one of the following choice below 👇🏽");

        Journal journal = new Journal();
        bool exit = false;

        while (!exit) {
            Console.WriteLine("\n1. Write a new entry");
            Console.WriteLine("2. Display my journal");
            Console.WriteLine("3. Save my journal to a file");
            Console.WriteLine("4. Load my journal from a file");
            Console.WriteLine("5. Quit");
            Console.Write("What will you like to do?🤷‍♀️: ");
            string choice = Console.ReadLine();

            switch (choice) {
                case "1":
                    WriteNewEntry(journal);
                    break;
                case "2":
                    journal.DisplayJournal();
                    break;
                case "3":
                    Console.Write("Enter filename to save: ");
                    string saveFilename = Console.ReadLine();
                    journal.SaveToFile(saveFilename);
                    Console.WriteLine("Journal saved to file.");
                    break;
                case "4":
                    Console.Write("Enter filename to load: ");
                    string loadFilename = Console.ReadLine();
                    journal.LoadFromFile(loadFilename);
                    Console.WriteLine("Journal loaded from file.");
                    break;
                case "5":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
                    break;
            }
        }
    }

    static void WriteNewEntry(Journal journal) {
        string[] prompts = {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?"
        };

        Random random = new Random();
        int index = random.Next(prompts.Length);
        string prompt = prompts[index];

        Console.WriteLine($"Prompt: {prompt}");
        Console.Write("Your response: ");
        string response = Console.ReadLine();

        Console.Write("Enter additional information: ");
        string additionalInfo = Console.ReadLine();

        string date = DateTime.Now.ToString("yyyy-MM-dd");

        journal.AddEntry(prompt, response, date, additionalInfo);
    }
}

