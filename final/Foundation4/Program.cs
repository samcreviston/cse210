using System;
using System.Collections.Generic;

class Exercise
{
    private DateTime date;
    private int lengthInMinutes;

    public DateTime Date
    {
        get { return date; }
        set { date = value; }
    }

    public int LengthInMinutes
    {
        get { return lengthInMinutes; }
        set { lengthInMinutes = value; }
    }

    public virtual double GetDistance()
    {
        return 0.0;
    }

    public virtual double GetSpeed()
    {
        return 0.0;
    }

    public virtual double GetPace()
    {
        return 0.0;
    }

    public virtual string GetSummary()
    {
        return $"{date.ToShortDateString()} Activity ({lengthInMinutes} min)";
    }
}

class Running : Exercise
{
    private double distance;

    public double Distance
    {
        get { return distance; }
        set { distance = value; }
    }

    public override double GetDistance()
    {
        return distance;
    }

    public override double GetSpeed()
    {
        return (distance / LengthInMinutes) * 60;
    }

    public override double GetPace()
    {
        return LengthInMinutes / distance;
    }

    public override string GetSummary()
    {
        return $"{Date.ToShortDateString()} Running ({LengthInMinutes} min) - Distance: {distance} miles, Speed: {GetSpeed():0.0} mph, Pace: {GetPace():0.0} min/mile";
    }
}

class Cycling : Exercise
{
    private double speed;

    public double Speed
    {
        get { return speed; }
        set { speed = value; }
    }

    public override double GetDistance()
    {
        return (speed * LengthInMinutes) / 60;
    }

    public override double GetSpeed()
    {
        return speed;
    }

    public override double GetPace()
    {
        return 60 / speed;
    }

    public override string GetSummary()
    {
        return $"{Date.ToShortDateString()} Cycling ({LengthInMinutes} min) - Distance: {GetDistance():0.0} miles, Speed: {speed} mph, Pace: {GetPace():0.0} min/mile";
    }
}

class Swimming : Exercise
{
    private int laps;

    public int Laps
    {
        get { return laps; }
        set { laps = value; }
    }

    public override double GetDistance()
    {
        return laps * 50 / 1000.0 * 0.62;
    }

    public override double GetSpeed()
    {
        return (GetDistance() / LengthInMinutes) * 60;
    }

    public override double GetPace()
    {
        return LengthInMinutes / GetDistance();
    }

    public override string GetSummary()
    {
        return $"{Date.ToShortDateString()} Swimming ({LengthInMinutes} min) - Distance: {GetDistance():0.0} miles, Speed: {GetSpeed():0.0} mph, Pace: {GetPace():0.0} min/mile";
    }
}

class Program
{
    static void Main(string[] args)
    {
        Running running = new Running();
        running.Date = new DateTime(2024, 7, 13);
        running.LengthInMinutes = 42;
        running.Distance = 4.0;

        Cycling cycling = new Cycling();
        cycling.Date = new DateTime(2024, 7, 17);
        cycling.LengthInMinutes = 62;
        cycling.Speed = 11.0;

        Swimming swimming = new Swimming();
        swimming.Date = new DateTime(2024, 7, 20);
        swimming.LengthInMinutes = 86;
        swimming.Laps = 40;

        List<Exercise> activities = new List<Exercise>();
        activities.Add(running);
        activities.Add(cycling);
        activities.Add(swimming);

        foreach (Exercise activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
            Console.WriteLine();
        }
    }
}