using System;
using System.Threading;
using System.Collections.Generic;

public abstract class MindfulnessActivity
{
    private string _name;
    private string _description;
    private int _duration;

    public string ReceiveName() => _name;
    public void SetName(string name) => _name = name;

    public string ReceiveDescription() => _description;
    public void SetDescription(string description) => _description = description;

    public int ReceiveDuration() => _duration;
    public void SetDuration(int duration) => _duration = duration;

    public void Start()
    {
        Console.WriteLine($"Starting {_name}...");
        Console.WriteLine(_description);
        Console.Write("Enter the duration (in seconds): ");
        _duration = int.Parse(Console.ReadLine());

        Console.WriteLine("\nPrepare to begin...");
        Pause(3);
        
        RunActivity();
        
        Console.WriteLine($"You have completed the {_name} activity for {_duration} seconds. Well done!");
        Pause(3);
    }

    protected void Pause(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            Console.Write(".");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }

    protected abstract void RunActivity();
}

public class BreathingActivity : MindfulnessActivity
{
    public BreathingActivity()
    {
        SetName("\nBreathing Activity");
        SetDescription("\nThis activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.");
    }

    protected override void RunActivity()
    {
        int elapsedTime = 0;
        while (elapsedTime < ReceiveDuration())
        {
            Console.WriteLine("Breathe in...");
            Pause(3);
            Console.WriteLine("Breathe out...");
            Pause(3);
            elapsedTime += 6;
        }
    }
}

public class ReflectionActivity : MindfulnessActivity
{
    private static List<string> Prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private static List<string> Questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectionActivity()
    {
        SetName("\nReflection Activity");
        SetDescription("\nThis activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.");
    }

    protected override void RunActivity()
    {
        Random rand = new Random();
        Console.WriteLine(Prompts[rand.Next(Prompts.Count)]);
        Pause(3);

        int elapsedTime = 0;
        while (elapsedTime < ReceiveDuration())
        {
            Console.WriteLine(Questions[rand.Next(Questions.Count)]);
            Pause(5);
            elapsedTime += 5;
        }
    }
}

public class ListingActivity : MindfulnessActivity
{
    private static List<string> Prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity()
    {
        SetName("\nListing Activity");
        SetDescription("\nThis activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");
    }

    protected override void RunActivity()
    {
        Random rand = new Random();
        Console.WriteLine(Prompts[rand.Next(Prompts.Count)]);
        Pause(3);

        Console.WriteLine("Start listing items:");
        List<string> items = new List<string>();
        int elapsedTime = 0;

        while (elapsedTime < ReceiveDuration())
        {
            string item = Console.ReadLine();
            if (!string.IsNullOrEmpty(item))
            {
                items.Add(item);
            }
            elapsedTime++;
        }

        Console.WriteLine($"You listed {items.Count} items.");
    }
}

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Choose an activity:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Exit");
            Console.Write("select an activity to begin! ");

            string choice = Console.ReadLine();

            MindfulnessActivity activity;

            switch (choice)
            {
                case "1":
                    activity = new BreathingActivity();
                    break;
                case "2":
                    activity = new ReflectionActivity();
                    break;
                case "3":
                    activity = new ListingActivity();
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    continue;
            }

            activity.Start();
        }
    }
}