// using System;

// class Program
// {
//     static void Main(string[] args)
//     {
//         Console.WriteLine("Hello Develop05 World!");
//     }
// }

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

abstract class Goal
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public int Points { get; protected set; }
    public bool IsCompleted { get; protected set; }

    public Goal(string name, string description, int points)
    {
        Name = name;
        Description = description;
        Points = points;
        IsCompleted = false;
    }

    public abstract void RecordEvent();
    public abstract string Display();
}

class SimpleGoal : Goal
{
    public SimpleGoal(string name, string description, int points) : base(name, description, points) { }

    public override void RecordEvent()
    {
        if (!IsCompleted)
        {
            IsCompleted = true;
            Console.WriteLine($"Goal '{Name}' completed! You earned {Points} points.");
        }
    }

    public override string Display()
    {
        return $"[SimpleGoal] {Name} - {(IsCompleted ? "[X]" : "[ ]")}";
    }
}

class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points) : base(name, description, points) { }

    public override void RecordEvent()
    {
        Console.WriteLine($"Recorded event for '{Name}'. You earned {Points} points.");
    }

    public override string Display()
    {
        return $"[EternalGoal] {Name}";
    }
}

class ChecklistGoal : Goal
{
    public int TargetCount { get; private set; }
    public int CurrentCount { get; private set; }
    public int BonusPoints { get; private set; }

    public ChecklistGoal(string name, string description, int points, int targetCount, int bonusPoints)
        : base(name, description, points)
    {
        TargetCount = targetCount;
        CurrentCount = 0;
        BonusPoints = bonusPoints;
    }

    public override void RecordEvent()
    {
        if (CurrentCount < TargetCount)
        {
            CurrentCount++;
            if (CurrentCount == TargetCount)
            {
                IsCompleted = true;
                Console.WriteLine($"Goal '{Name}' completed! You earned {Points + BonusPoints} points (including bonus).");
            }
            else
            {
                Console.WriteLine($"Recorded event for '{Name}'. You earned {Points} points.");
            }
        }
    }

    public override string Display()
    {
        return $"[ChecklistGoal] {Name} - Completed {CurrentCount}/{TargetCount} times {(IsCompleted ? "[X]" : "[ ]")}";
    }
}

class GoalManager
{
    private List<Goal> goals;
    private int totalPoints;

    public GoalManager()
    {
        goals = new List<Goal>();
        totalPoints = 0;
    }

    public void AddGoal(Goal goal)
    {
        goals.Add(goal);
    }

    public void RecordEvent(string goalName)
    {
        var goal = goals.FirstOrDefault(g => g.Name.Equals(goalName, StringComparison.OrdinalIgnoreCase));
        if (goal != null)
        {
            goal.RecordEvent();
            totalPoints += goal.Points;
            if (goal is ChecklistGoal checklistGoal && checklistGoal.IsCompleted)
            {
                totalPoints += checklistGoal.BonusPoints;
            }
        }
        else
        {
            Console.WriteLine($"Goal '{goalName}' not found.");
        }
    }

    public void DisplayGoals()
    {
        foreach (var goal in goals)
        {
            Console.WriteLine(goal.Display());
        }
    }

    public void DisplayScore()
    {
        Console.WriteLine($"Total Score: {totalPoints}");
    }

    public void SaveGoals(string filePath)
    {
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            writer.WriteLine(totalPoints);
            foreach (var goal in goals)
            {
                writer.WriteLine($"{goal.GetType().Name}|{goal.Name}|{goal.Description}|{goal.Points}|{goal.IsCompleted}");
                if (goal is ChecklistGoal checklistGoal)
                {
                    writer.WriteLine($"{checklistGoal.CurrentCount}|{checklistGoal.TargetCount}|{checklistGoal.BonusPoints}");
                }
            }
        }
    }

    public void LoadGoals(string filePath)
    {
        // if (File.Exists(filePath))
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                totalPoints = int.Parse(reader.ReadLine());
                goals.Clear();
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var parts = line.Split('|');
                    var type = parts[0];
                    var name = parts[1];
                    var description = parts[2];
                    var points = int.Parse(parts[3]);
                    var isCompleted = bool.Parse(parts[4]);

                    if (type == nameof(SimpleGoal))
                    {
                        var goal = new SimpleGoal(name, description, points);
                        // goal.IsCompleted = isCompleted;
                        goals.Add(goal);
                    }
                    else if (type == nameof(EternalGoal))
                    {
                        var goal = new EternalGoal(name, description, points);
                        goals.Add(goal);
                    }
                    else if (type == nameof(ChecklistGoal))
                    {
                        var currentCount = int.Parse(reader.ReadLine());
                        var targetCount = int.Parse(reader.ReadLine());
                        var bonusPoints = int.Parse(reader.ReadLine());
                        var goal = new ChecklistGoal(name, description, points, targetCount, bonusPoints)
                        {
                            // CurrentCount = currentCount,
                            // IsCompleted = isCompleted
                        };
                        goals.Add(goal);
                    }
                }
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        GoalManager goalManager = new GoalManager();

        // Sample goals for demonstration
        // goalManager.AddGoal(new SimpleGoal("Run Marathon", "Complete a marathon run", 1000));
        // goalManager.AddGoal(new EternalGoal("Read Scriptures", "Read scriptures daily", 100));
        // goalManager.AddGoal(new ChecklistGoal("Attend Temple", "Attend temple 10 times", 50, 10, 500));

        while (true)
        {
            Console.WriteLine("\nEternal Quest Program:");
            Console.WriteLine("1. Display Goals");
            Console.WriteLine("2. Display Score");
            Console.WriteLine("3. Record Event");
            Console.WriteLine("4. Add Goal");
            Console.WriteLine("5. Save Goals");
            Console.WriteLine("6. Load Goals");
            Console.WriteLine("7. Exit");
            Console.Write("Select an option: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    goalManager.DisplayGoals();
                    break;
                case "2":
                    goalManager.DisplayScore();
                    break;
                case "3":
                    Console.Write("Enter goal name to record event: ");
                    var goalName = Console.ReadLine();
                    goalManager.RecordEvent(goalName);
                    break;
                case "4":
                    Console.Write("Enter goal type (Simple, Eternal, Checklist): ");
                    var type = Console.ReadLine();
                    Console.Write("Enter goal name: ");
                    var name = Console.ReadLine();
                    Console.Write("Enter goal description: ");
                    var description = Console.ReadLine();
                    Console.Write("Enter points: ");
                    var points = int.Parse(Console.ReadLine());

                    if (type.Equals("Simple", StringComparison.OrdinalIgnoreCase))
                    {
                        goalManager.AddGoal(new SimpleGoal(name, description, points));
                    }
                    else if (type.Equals("Eternal", StringComparison.OrdinalIgnoreCase))
                    {
                        goalManager.AddGoal(new EternalGoal(name, description, points));
                    }
                    else if (type.Equals("Checklist", StringComparison.OrdinalIgnoreCase))
                    {
                        Console.Write("Enter target count: ");
                        var targetCount = int.Parse(Console.ReadLine());
                        Console.Write("Enter bonus points: ");
                        var bonusPoints = int.Parse(Console.ReadLine());
                        goalManager.AddGoal(new ChecklistGoal(name, description, points, targetCount, bonusPoints));
                    }
                    break;
                case "5":
                    Console.Write("Enter file path to save goals: ");
                    var savePath = Console.ReadLine();
                    goalManager.SaveGoals(savePath);
                    break;
                case "6":
                    Console.Write("Enter file path to load goals: ");
                    var loadPath = Console.ReadLine();
                    goalManager.LoadGoals(loadPath);
                    break;
                case "7":
                    return;
                default:
                    Console.WriteLine("Invalid choice, please try again.");
                    break;
            }
        }
    }
}




