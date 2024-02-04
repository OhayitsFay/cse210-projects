public class MeditationActivity : MindfulnessActivity
{
    private List<string> meditationPrompts = new List<string>
    {
        "Imagine a peaceful beach. What do you see?",
        "Visualize a calming forest. What sounds do you hear?",
        "Picture a serene mountain. How does it make you feel?",
        "Imagine yourself floating on a cloud. How does it feel?",
        "Visualize a field of blooming flowers. What colors do you see?",
        "Picture a gentle stream flowing through a peaceful meadow. Can you hear the water?",
        "Envision a warm, golden light surrounding you. How does it embrace you?",
        "Picture a starry night sky. How do the stars make you feel?",
        "Imagine a cozy cabin in the mountains. What do you hear inside?",
        "Visualize a garden filled with vibrant butterflies. How do they move around?",
    };

    public MeditationActivity(int duration) : base(duration)
    {
    }

    protected override void DisplayStartingMessage()
    {
        Console.WriteLine("Welcome to the Meditation Activity!");
        Console.WriteLine($"Duration: {duration} seconds");
        Console.WriteLine("This activity will guide you through a meditation session.");
        Console.WriteLine("Get ready to begin...");
        Thread.Sleep(3000);
        Console.WriteLine();
    }

    protected override void PerformActivity()
    {
        Console.WriteLine("Starting meditation exercise...");

        for (int i = 0; i < duration; i++)
        {
            string prompt = GetRandomMeditationPrompt();
            Console.WriteLine(prompt);
            DisplaySpinner(5);
            Thread.Sleep(1000);

            foreach (var question in meditationPrompts)
            {
                Console.WriteLine(question);
                Thread.Sleep(3000); // Pause for reflection
                DisplaySpinner(5); // Display spinner for 5seconds
                i += 5;
            }
        }
    }

    private string GetRandomMeditationPrompt()
    {
        Random random = new Random();
        return meditationPrompts[random.Next(meditationPrompts.Count)];
    }

    private void DisplaySpinner(int seconds)
    {
        Console.Write("Meditating");
        for (int i = 0; i < seconds; i++)
        {
            Console.Write(".");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }

    protected override void DisplayEndingMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Great job! You have completed the meditation exercise.");
        Console.WriteLine($"Activity duration: {duration} seconds");
        Thread.Sleep(3000);
    }
}