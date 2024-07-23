using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

abstract class Goal
{
    private string _name;
    private int _points;
    private bool _Completed;

    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    public int Points
    {
        get { return _points; }
        set { _points = value; }
    }

    public bool Completed
    {
        get { return _Completed; }
        set { _Completed = value; }
    }

    public Goal(string name, int points)
    {
        _name = name;
        _points = points;
        _Completed = false;
    }

    public abstract void RecordProgress();
    public abstract string GetStatus();
}

class SimpleGoal : Goal
{
    public SimpleGoal(string name, int points) : base(name, points) { }

    public override void RecordProgress()
    {
        Completed = true;
    }

    public override string GetStatus()
    {
        if (Completed)
        {
            return "[X] " + Name;
        }
        else
        {
            return "[ ] " + Name;
        }
    }
}

class EternalGoal : Goal
{
    public EternalGoal(string name, int points) : base(name, points) { }

     public override void RecordProgress()
    {
        // No change to be made
    }

    public override string GetStatus()
    {
        return "[ ] " + Name;
    }
}

class ChecklistGoal : Goal
{
    private int _targetCount;
    private int _currentCount;
    private int _bonusPoints;

    public int TargetCount
    {
        get { return _targetCount; }
        set { _targetCount = value; }
    }

    public int CurrentCount
    {
        get { return _currentCount; }
        set { _currentCount = value; }
    }

    public int BonusPoints
    {
        get { return _bonusPoints; }
        set { _bonusPoints = value; }
    }

    public ChecklistGoal(string name, int points, int targetCount, int bonusPoints) : base(name, points)
    {
        _targetCount = targetCount;
        _currentCount = 0;
        _bonusPoints = bonusPoints;
    }

    public override void RecordProgress()
    {
        _currentCount++;
        if (_currentCount >= _targetCount)
        {
            Completed = true;
        }
    }

    public override string GetStatus()
    {
        if (Completed)
        {
            return $"[X] {Name} (Completed {CurrentCount}/{TargetCount})";
        }
        else
        {
            return $"[ ] {Name} (Completed {CurrentCount}/{TargetCount})";
        }
    }
}

class EternalQuest
{
    private List<Goal> goals = new List<Goal>();
    private int totalPoints = 0;

    public void CreateGoal()
    {
        Console.WriteLine("");
        Console.WriteLine("Choose goal type:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.WriteLine("");

        int choice = int.Parse(Console.ReadLine());
        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();
        Console.Write("points for accomplishing goal: ");
        int points = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                goals.Add(new SimpleGoal(name, points));
                break;
            case 2:
                goals.Add(new EternalGoal(name, points));
                break;
            case 3:
                Console.Write("Enter target count: ");
                int targetCount = int.Parse(Console.ReadLine());
                Console.Write("Enter bonus points: ");
                int bonusPoints = int.Parse(Console.ReadLine());
                goals.Add(new ChecklistGoal(name, points, targetCount, bonusPoints));
                break;
        }
    }

    public void ListGoals()
    {
        foreach (var goal in goals)
        {
            Console.WriteLine(goal.GetStatus());
        }
    }

    public void SaveGoals(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(totalPoints);
            foreach (var goal in goals)
            {
                writer.WriteLine($"{goal.GetType().Name},{goal.Name},{goal.Points},{goal.Completed}");
                if (goal is ChecklistGoal checklistGoal)
                {
                    writer.WriteLine($"{checklistGoal.CurrentCount},{checklistGoal.TargetCount},{checklistGoal.BonusPoints}");
                }
            }
        }
    }

   public void LoadGoals(string filename)
{
    // Read all lines from the file into a string array
    string[] lines = System.IO.File.ReadAllLines(filename);

    // First line contains the total points
    totalPoints = int.Parse(lines[0]);

    // Iterate over the remaining lines to create goals
    for (int i = 1; i < lines.Length; i++)
    {
        // Split each line into parts
        string[] parts = lines[i].Split(',');

        // Extract goal type and common properties
        string typeName = parts[0];
        string name = parts[1];
        int points = int.Parse(parts[2]);
        bool Completed = bool.Parse(parts[3]);

        Goal goal = null;

        // Create the appropriate goal object based on the type
        switch (typeName)
        {
            case "SimpleGoal":
                goal = new SimpleGoal(name, points);
                break;
            case "EternalGoal":
                goal = new EternalGoal(name, points);
                break;
            case "ChecklistGoal":
                // Additional properties for ChecklistGoal
                int currentCount = int.Parse(lines[++i]); // Move to the next line for currentCount
                int targetCount = int.Parse(lines[++i]); // Move to the next line for targetCount
                int bonusPoints = int.Parse(lines[++i]); // Move to the next line for bonusPoints
                goal = new ChecklistGoal(name, points, targetCount, bonusPoints) 
                { 
                    CurrentCount = currentCount 
                };
                break;
        }

        // Set the completion status and add the goal to the list
        if (goal != null)
        {
            goal.Completed = Completed;
            goals.Add(goal);
        }
    }
}

    public void RecordProgress()
    {
        Console.WriteLine("");
        Console.WriteLine("Choose a goal to record progress:");
        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].Name}");
        }

        int choice = int.Parse(Console.ReadLine()) - 1;
        if (choice >= 0 && choice < goals.Count)
        {
            goals[choice].RecordProgress();
            totalPoints += goals[choice].Points;
            if (goals[choice] is ChecklistGoal checklistGoal && checklistGoal.Completed)
            {
                totalPoints += checklistGoal.BonusPoints;
            }
        }
    }

    public void ShowScore()
    {
        Console.WriteLine($"Total Points: {totalPoints}");
        Console.WriteLine("Well done! Keep on going!");
    }

    static void Main(string[] args)
    {
        EternalQuest eq = new EternalQuest();
        bool running = true;

        while (running)
        {
            Console.WriteLine("");
            Console.WriteLine("Eternal Quest Main Menu:");
            Console.WriteLine("1. Create new Goal");
            Console.WriteLine("2. List goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record progress");
            Console.WriteLine("6. Show Score");
            Console.WriteLine("7. Exit");

            Console.Write("selection:");
            int choice = int.Parse(Console.ReadLine());
            Console.WriteLine("");

            switch (choice)
            {
                case 1:
                    eq.CreateGoal();
                    break;
                case 2:
                    eq.ListGoals();
                    break;
                case 3:
                    Console.Write("Enter filename to save: ");
                    string saveFile = Console.ReadLine();
                    eq.SaveGoals(saveFile);
                    break;
                case 4:
                    Console.Write("Enter filename to load: ");
                    string loadFile = Console.ReadLine();
                    eq.LoadGoals(loadFile);
                    break;
                case 5:
                    eq.RecordProgress();
                    break;
                case 6:
                    eq.ShowScore();
                    break;
                case 7:
                    running = false;
                    break;
            }
        }
    }
}
