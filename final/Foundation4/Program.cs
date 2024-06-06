// using System;

// class Program
// {
//     static void Main(string[] args)
//     {
//         Console.WriteLine("Hello Foundation4 World!");
//     }
// }

using System;
using System.Collections.Generic;

// Base Activity Class
public abstract class Activity
{
    private DateTime date;
    private int duration; // in minutes

    public Activity(DateTime date, int duration)
    {
        this.date = date;
        this.duration = duration;
    }

    public DateTime GetDate()
    {
        return date;
    }

    public int GetDuration()
    {
        return duration;
    }

    public abstract double GetDistance();
    public abstract double GetSpeed(); // in mph or kph
    public abstract double GetPace(); // in min per mile or min per km

    public string GetSummary()
    {
        return $"{date.ToShortDateString()} {this.GetType().Name} ({duration} min): Running Distance {GetDistance():0.0} miles, Speed Covered {GetSpeed():0.0} mph, Running Pace {GetPace():0.0} min per mile";
    }
}

// Running Class
public class Running : Activity
{
    private double distance; // in miles

    public Running(DateTime date, int duration, double distance)
        : base(date, duration)
    {
        this.distance = distance;
    }

    public override double GetDistance()
    {
        return distance;
    }

    public override double GetSpeed()
    {
        return (distance / GetDuration()) * 60;
    }

    public override double GetPace()
    {
        return GetDuration() / distance;
    }
}

// Cycling Class
public class Cycling : Activity
{
    private double speed; // in mph

    public Cycling(DateTime date, int duration, double speed)
        : base(date, duration)
    {
        this.speed = speed;
    }

    public override double GetDistance()
    {
        return (speed * GetDuration()) / 60;
    }

    public override double GetSpeed()
    {
        return speed;
    }

    public override double GetPace()
    {
        return 60 / speed;
    }
}

// Swimming Class
public class Swimming : Activity
{
    private int laps;

    public Swimming(DateTime date, int duration, int laps)
        : base(date, duration)
    {
        this.laps = laps;
    }

    public override double GetDistance()
    {
        return laps * 50 / 1000.0 * 0.62; // convert meters to miles
    }

    public override double GetSpeed()
    {
        return (GetDistance() / GetDuration()) * 60;
    }

    public override double GetPace()
    {
        return GetDuration() / GetDistance();
    }
}

// Main Program
public class Program
{
    public static void Main()
    {
        Console.WriteLine("\nPolymorphism With Excersice Tracking");
        // Create activities
        Running running = new Running(new DateTime(2024, 6, 06), 30, 3.0);
        Cycling cycling = new Cycling(new DateTime(2024, 6, 06), 45, 15.0); // 15 mph
        Swimming swimming = new Swimming(new DateTime(2024, 6, 06), 30, 20); // 20 laps

        // Store activities in a list
        List<Activity> activities = new List<Activity> { running, cycling, swimming };

        // Display summaries
        foreach (var activity in activities)
        {
            Console.WriteLine("\n");
            Console.WriteLine(activity.GetSummary());
        }
    }
}
