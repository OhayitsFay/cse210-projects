public class Word
{
    public string Text { get; }
    public bool IsHidden { get; private set; }
    public Reference Reference { get; }

    public Word(string text)
    {
        Text = text;
        IsHidden = false;
        Reference = new Reference(""); // Dummy reference for now
    }

    public void Hide()
    {
        IsHidden = true;
    }

    public void Highlight()
    {
        // Implement highlighting logic, e.g., change color or style using ANSI escape codes
        Console.Write("\u001b[1m\u001b[33m"); // Bold yellow text
        Console.Write($"{Text} ");
        Console.ResetColor(); // Reset to default color
    }

    public override string ToString()
    {
        return IsHidden ? "_____" : Text;
    }
}