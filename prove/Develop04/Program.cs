using System;
using System.Collections.Generic;
using System.Threading;


public class Program
{
    static void Main()
    {
        Dictionary<string, int> activityLog = new Dictionary<string, int>();

        while (true)
        {
            Console.WriteLine("Mindfulness Program Menu:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Meditation Activity");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice (1-5): ");
            Console.WriteLine();

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                        RunActivity(new BreathingActivity(GetDuration()), "Breathing", activityLog);
                        break;
                    case 2:
                        RunActivity(new ReflectionActivity(GetDuration()), "Reflection", activityLog);
                        break;
                    case 3:
                        RunActivity(new ListingActivity(GetDuration()), "Listing", activityLog);
                        break;
                    case 4:
                        RunActivity(new MeditationActivity(GetDuration()), "Meditation", activityLog);
                        break;
                    case 5:
                        Console.WriteLine("Exiting the program. Goodbye!");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }
    }

    static void RunActivity(MindfulnessActivity activity, string activityName, Dictionary<string, int> activityLog)
    {
        //Console.Clear(); // Clear console before starting the activity
        activity.StartActivity();

        // Log the activity
        if (activityLog.ContainsKey(activityName))
            activityLog[activityName]++;
        else
            activityLog.Add(activityName, 1);

        Console.WriteLine($"You have performed {activityName} activity {activityLog[activityName]} times.");

    }

    static int GetDuration()
    {
        Console.Write("Enter the duration of the activity in seconds: ");
        if (!int.TryParse(Console.ReadLine(), out int duration) || duration <= 0)
        {
            Console.WriteLine("Invalid input. Please enter a positive integer for duration.");
            Console.Write("Enter the duration of the activity in seconds: ");
        }
        return duration;
    }
}



