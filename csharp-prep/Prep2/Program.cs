using System;

class Program
{
    static void Main(string[] args)
    {
        // Ask user for their grade percentage
        Console.Write("Enter your grade percentage: ");
        // string answer = Console.ReadLine();
        // int percent = int.parse(answer);
        double gradePercentage = Convert.ToDouble(Console.ReadLine());

        // Initialize the letter grade variable
        char letter = ' ';
        // string letter = "";

        // Determine the letter grade
        if (gradePercentage >= 90)
        {
            letter = 'A';
        }
        else if (gradePercentage >= 80)
        {
            letter = 'B';
        }
        else if (gradePercentage >= 70)
        {
            letter = 'C';
        }
        else if (gradePercentage >= 60)
        {
            letter = 'D';
        }
        else
        {
            letter = 'F';
        }

        // Determine the sign (+, -, or none)
        char sign;
        int lastDigit = (int)gradePercentage % 10;
        if (lastDigit >= 7)
        {
            sign = '+';
        }
        else if (lastDigit < 3)
        {
            sign = '-';
        }
        else
        {
            sign = ' ';
        }

        // Print the letter grade
        Console.WriteLine("Your letter grade is: " + letter + sign);

        // Check if the user passed the course and display a message accordingly
        if (gradePercentage >= 70)
        {
            Console.WriteLine("Congratulations! You passed the course.");
        }
        else
        {
            Console.WriteLine("Don't worry, keep working hard for next time!");
        }
    }
}