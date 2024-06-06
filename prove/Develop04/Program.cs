// using System;

// class Program
// {
//     static void Main(string[] args)
//     {
//         Console.WriteLine("Hello Develop04 World!");
//     }
// }

using System;
using System.IO;
using System.Threading;

abstract class MindfulnessActivity
{
    protected int duration;

    public void StartActivity()
    {
        DisplayStartingMessage();
        PerformActivity();
        DisplayEndingMessage();
    }

    protected void DisplayStartingMessage()
    {
        Console.WriteLine("Welcome to the Mindfulness App.");
        Console.WriteLine($"This activity will help you to {GetDescription()}.");
        Console.WriteLine("How long, in seconds, would you like for your session?");
        duration = int.Parse(Console.ReadLine());
        Console.WriteLine("Get ready...");
        ShowCountdown(4);
    }

    protected void DisplayEndingMessage()
    {
        Console.WriteLine("Kudos! You have completed the activity.");
        Console.WriteLine($"Activity completed in {duration} seconds.");
        ShowCountdown(3);
    }

    protected void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i + " ");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }

    protected abstract void PerformActivity();
    protected abstract string GetDescription();
}

// B
class BreathingActivity : MindfulnessActivity
{
    protected override void PerformActivity()
    {
        int elapsed = 0;
        while (elapsed < duration)
        // for (int i = 0; i < duration; i += 4)
        {
            Console.WriteLine("Breathe in...");
            ShowCountdown(3);
            elapsed += 3;
            
            Console.WriteLine("Now breathe out...");
            ShowCountdown(3);
            elapsed += 3;
        }
    }

    protected override string GetDescription()
    {
        return "relax by walking through breathing in and out slowly. Clear your mind and focus on your breathing, dont forget to relax your back.";
    }
}
// R
class ReflectionActivity : MindfulnessActivity
{
    private readonly string[] prompts = {
        "1. Think of a time when you stood up for someone else.",
        "2. Think of a time when you did something really difficult.",
        "3. Think of a time when you helped someone in need.",
        "4. Think of a time when you did something truly selfless."
    };

    private readonly string[] questions = {
        "> Why was this experience meaningful to you?",
        "> Have you ever done anything like this before?",
        "> How did you get started?",
        "> How did you feel when it was complete?",
        "> What made this time different than other times when you were not as successful?",
        "> What is your favorite thing about this experience?",
        "> What could you learn from this experience that applies to other situations?",
        "> What did you learn about yourself through this experience?",
        "> How can you keep this experience in mind in the future?"
    };

    protected override void PerformActivity()
    {
        Console.WriteLine("Consider the following prompt");
        Console.WriteLine("Now ponder on each of the following question as they relate to this exprience.");
        Random random = new Random();
        string prompt = prompts[random.Next(prompts.Length)];
        Console.WriteLine(prompt);
        ShowCountdown(6);

        int elapsed = 0;
        int count = 0;
        while (elapsed < duration)
        // for (int i = 0; i < duration; i += 10)
        {
            string question = questions[random.Next(questions.Length)];
            Console.WriteLine(question);
            count++;
            elapsed += 5;
            // ShowSpinner(10);
        }
    }

    protected override string GetDescription()
    {
        return "reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in another aspect of your life.";
    }
}
// L
class ListingActivity : MindfulnessActivity
{
    private readonly string[] prompts = {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    protected override void PerformActivity()
    {
        Random random = new Random();
        string prompt = prompts[random.Next(prompts.Length)];
        Console.WriteLine(prompt);
        ShowCountdown(3);

        Console.WriteLine("List as many response you can to the following prompt: ");
        Console.WriteLine("Start listing:");
        int itemCount = 0;
        DateTime startTime = DateTime.Now;

        while ((DateTime.Now - startTime).TotalSeconds < duration)
        {
            Console.ReadLine();
            itemCount++;
        }

        Console.WriteLine($"You listed {itemCount} items.");
    }

    protected override string GetDescription()
    {
        return "reflect on the good things in your life by listing by having you list as many things as you can in a certain area.";
    }
}
// Main
class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Start Breathing Activity");
            Console.WriteLine("2. Start Reflection Activity");
            Console.WriteLine("3. Start Listing Activity");
            Console.WriteLine("4. Quit Activities");
            Console.WriteLine("Select a choice from the menu:");

            int choice = int.Parse(Console.ReadLine());
            MindfulnessActivity activity = null;

            switch (choice)
            {
                case 1:
                    activity = new BreathingActivity();
                    break;
                case 2:
                    activity = new ReflectionActivity();
                    break;
                case 3:
                    activity = new ListingActivity();
                    break;
                case 4:
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    continue;
            }

            activity.StartActivity();
        }
    }
}


