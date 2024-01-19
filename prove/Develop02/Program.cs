using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();

        while (true)
        {
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Exit");

            Console.Write("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    // Generate a random prompt
                    string[] prompts = { "Who was the most interesting person I interacted with today?", 
                                         "What was the best part of my day?", 
                                         "How did I see the hand of the Lord in my life today?", 
                                         "What was the strongest emotion I felt today?", 
                                         "If I had one thing I could do over today, what would it be?", 
                                         // New prompts
                                         "What is one thing I learned today that I didn't know yesterday?", 
                                         "Describe a small act of kindness you witnessed or participated in today.",
                                         "What is a goal or intention you have for tomorrow?", 
                                         "Reflect on a moment that made you laugh out loud today.",
                                         "How did you overcome a challenge or obstacle today?" };

                    Random random = new Random();
                    string randomPrompt = prompts[random.Next(prompts.Length)];

                    Console.WriteLine($"Prompt: {randomPrompt}");
                    Console.Write("Response: ");
                    string response = Console.ReadLine();
                    string currentDate = DateTime.Now.ToShortDateString();
                    
                    Console.Write("Rate your day: ");
                    int rating;
                    if (int.TryParse(Console.ReadLine(), out rating) && rating >= 1 && rating <= 5)

                    journal.AddEntry(randomPrompt, response, currentDate, rating);
                    break;

                case 2:
                    journal.DisplayAll();
                    break;

                case 3:
                    Console.Write("Enter the filename to save: ");
                    string saveFilename = Console.ReadLine();
                    journal.SaveToFile(saveFilename);
                    break;

                case 4:
                    Console.Write("Enter the filename to load: ");
                    string loadFilename = Console.ReadLine();
                    journal.LoadFromFile(loadFilename);
                    break;

                case 5:
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
 }
