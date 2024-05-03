// using System;

// class Program
// {
//     static void Main(string[] args)
//     {
//         Console.WriteLine("Hello Prep4 World!");
//     }
// }

using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        List<int> numbers = new List<int>();

        // Ask the user for a series of numbers
        Console.WriteLine("Enter a series of numbers. Enter 0 to stop.");
        int number;
        do
        {
            Console.Write("Enter a number: ");
             number = Convert.ToInt32(Console.ReadLine());

            if (number != 0)
            {
                numbers.Add(number);
            }
        } while (number != 0);

        // Compute the sum of the numbers
        int sum = numbers.Sum();

        // Compute the average of the numbers
        double average = numbers.Average();

        // Find the maximum number in the list
        int maxNumber = numbers.Max();

        // Print the results
        Console.WriteLine($"Sum of the numbers: {sum}");
        Console.WriteLine($"Average of the numbers: {average}");
        Console.WriteLine($"Maximum number: {maxNumber}");
    }
}
