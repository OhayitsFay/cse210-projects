using System;

class Program
{
    static void Main(string[] args)
    {
        // Core Requirement 1: Ask for the user's grade percentage
        Console.Write("Enter your grade percentage: ");
        string answer = Console.ReadLine();
        int gradePercentage = int.Parse(answer);

        // Core Requirement 2: Determine and print the letter grade
        string letter;
        if (gradePercentage >= 90)
        {
            letter = "A";
        }
        else if (gradePercentage >= 80)
        {
            letter = "B";
        }
        else if (gradePercentage >= 70)
        {
            letter = "C";
        }
        else if (gradePercentage >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        // Core Requirement 3: Determine and print pass/fail message
        if (gradePercentage >= 70)
        {
            Console.WriteLine($"Congratulations! You passed with a {letter}.");
        }
        else
        {
            Console.WriteLine($"Encouragement for next time! Your grade is {letter}.");
        }
        // Stretch Challenge: Determine the sign
        int lastDigit = gradePercentage % 10;
        string sign = (lastDigit >= 7) ? "+" : (lastDigit < 3) ? "-" : "";

        // Handle exceptional cases
        if (letter == "A" && sign == "+")
        {
            letter = "A-"; // No A+
        }
        else if (letter == "F" && (sign == "+" || sign == "-"))
        {
            sign = ""; // No F+ or F-
        }

        // Display the final grade with sign
        Console.WriteLine($"Your final grade is {letter}{sign}.");
    }
}
