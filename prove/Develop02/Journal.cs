public class Journal
{
    public List<Entry> entries;

    public Journal()
    {
        entries = new List<Entry>();
    }
    

    public void AddEntry(string prompt, string response, string date, int rating)
    {
        Entry entry = new Entry
        {
            PromptText = prompt,
            EntryText = response,
            Date = date,
            Rating = rating
        };

        entries.Add(entry);
    }

    public void DisplayAll()
    {
        foreach (var entry in entries)
        {
            Console.WriteLine($"Date: {entry.Date}");
            Console.WriteLine($"Prompt: {entry.PromptText}");
            Console.WriteLine($"Response: {entry.EntryText}");
            Console.WriteLine($"Rating: {entry.Rating}\n");
        }
    }

    public void SaveToFile(string file)
    {
         using (StreamWriter writer = new StreamWriter(file))
        {
            foreach (var entry in entries)
            {
                writer.WriteLine($"{entry.Date},{entry.PromptText},{entry.EntryText},{entry.Rating}");
            }
        }

        Console.WriteLine("Journal saved successfully!");
    }

    public void LoadFromFile(string file)
    {
        entries.Clear();

        if (File.Exists(file))
        {
            string[] lines = File.ReadAllLines(file);

            foreach (var line in lines)
            {
                string[] parts = line.Split(",");
                if (parts.Length == 3)
                {
                    entries.Add(new Entry
                    {
                        Date = parts[0],
                        PromptText = parts[1],
                        EntryText = parts[2]
                        
                    });
                }
            }

            Console.WriteLine("Journal loaded successfully!");
        }
        else
        {
            Console.WriteLine("File not found. No entries loaded.");
        }
    }
}
