using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Ask the user for the scripture reference and text
        Console.Write("Enter the scripture reference (example, John 3:16): ");
        string referenceInput = Console.ReadLine();
        Reference reference = new Reference(referenceInput);

        Console.WriteLine("\nFor the scripture text, here is the church scriptures website if you would like to copy & paste the scripture from it:");
        Console.WriteLine("https://www.churchofjesuschrist.org/study/scriptures?lang=eng&platform=web");
        Console.WriteLine("\nEnter the scripture text: ");
        string scriptureText = Console.ReadLine();

        // Create a Scripture object with the user input
        Scripture scripture = new Scripture(reference, scriptureText);

        // Main loop hides words when enter is pressed
        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayedScripture());
            Console.WriteLine("\nPress Enter to hide more words or type 'quit' to exit.");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
                break;

            scripture.HideWords();

            if (scripture.VerseCompleted())
            {
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayedScripture());
                Console.WriteLine("\nGood job completing this round of memorizing your scripture!");
                Console.ReadKey();
                break;
            }
        }
    }
}

class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private Random _random;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        _random = new Random();

        foreach (var word in text.Split(' '))
        {
            _words.Add(new Word(word));
        }
    }

    public string GetDisplayedScripture()
    {
        return _reference.ToString() + "\n" + string.Join(" ", _words);
    }

    public void HideWords()
    {
        int wordsToHide = Math.Min(3, _words.Count);

        for (int i = 0; i < wordsToHide; i++)
        {
            int index = _random.Next(_words.Count);
            _words[index].Hide();
        }
    }

    public bool VerseCompleted()
    {
        foreach (var word in _words)
        {
            if (!word.IsHidden())
                return false;
        }
        return true;
    }
}

class Reference
{
    private string _text;

    public Reference(string text)
    {
        _text = text;
    }

    public override string ToString()
    {
        return _text;
    }
}

class Word
{
    private string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    public void Hide()
    {
        _isHidden = true;
    }

    public bool IsHidden()
    {
        return _isHidden;
    }

    public override string ToString()
    {
        if (_isHidden)
        {
            return "_";
        }
        else
        {
            return _text;
        }
    }
}