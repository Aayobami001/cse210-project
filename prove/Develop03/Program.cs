// using System;

// class Program
// {
//     static void Main(string[] args)
//     {
//         Console.WriteLine("Hello Develop03 World!");
//     }
// } 

using System;
using System.Collections.Generic;
using System.Linq;

class Reference {
    public string Book { get; private set; }
    public int StartChapter { get; private set; }
    public int StartVerse { get; private set; }
    public int EndChapter { get; private set; }
    public int EndVerse { get; private set; }

    // Constructor for single verse
    public Reference(string book, int chapter, int verse) {
        Book = book;
        StartChapter = chapter;
        StartVerse = verse;
        EndChapter = chapter;
        EndVerse = verse;
    }

    // Constructor for verse range
    public Reference(string book, int startChapter, int startVerse, int endChapter, int endVerse) {
        Book = book;
        StartChapter = startChapter;
        StartVerse = startVerse;
        EndChapter = endChapter;
        EndVerse = endVerse;
    }

    public override string ToString() {
        if (StartChapter == EndChapter && StartVerse == EndVerse) {
            return $"{Book} {StartChapter}:{StartVerse}";
        } else {
            return $"{Book} {StartChapter}:{StartVerse}-{EndChapter}:{EndVerse}";
        }
    }
}

class Word {
    public string Text { get; private set; }
    public bool IsHidden { get; private set; }

    public Word(string text) {
        Text = text;
        IsHidden = false;
    }

    public void Hide() {
        IsHidden = true;
    }

    public override string ToString() {
        return IsHidden ? "_____" : Text;
    }
}

class Scripture {
    public Reference Reference { get; private set; }
    private List<Word> Words { get; set; }
    private Random random;

    public Scripture(Reference reference, string text) {
        Reference = reference;
        Words = text.Split(' ').Select(word => new Word(word)).ToList();
        random = new Random();
    }

    public void HideRandomWords(int count) {
        var visibleWords = Words.Where(word => !word.IsHidden).ToList();
        for (int i = 0; i < count && visibleWords.Count > 0; i++) {
            int index = random.Next(visibleWords.Count);
            visibleWords[index].Hide();
            visibleWords.RemoveAt(index);
        }
    }

    public bool AllWordsHidden() {
        return Words.All(word => word.IsHidden);
    }

    public override string ToString() {
        return $"{Reference}\n{string.Join(" ", Words)}";
    }
}

class Program {
    static void Main(string[] args) {
        // Example scripture: John 3:16
        Reference reference = new Reference("Alma", 37, 38);
        string scriptureText = "And now, my son, I have somewhat to say concerning the things which our fathers call a ball, or director or our father called it liahona, which is, interpreted, a compass, and the lord prepare it.";
        Scripture scripture = new Scripture(reference, scriptureText);

        while (true) {
            Console.Clear();
            Console.WriteLine(scripture);

            if (scripture.AllWordsHidden()) {
                Console.WriteLine("All words are hidden. Good job memorizing!");
                break;
            }

            Console.WriteLine("\nPress Enter to hide more words or type 'quit' to exit.");
            string input = Console.ReadLine();
            if (input.ToLower() == "quit") {
                break;
            }

            scripture.HideRandomWords(3); // Hide a few random words
        }
    }
}
