class Student
{
    public string Name { get; private set; }
    public int ID { get; private set; }
    public Dictionary<string, double> AssignmentScores { get; private set; }

    public Student(string name, int id)
    {
        Name = name;
        ID = id;
        AssignmentScores = new Dictionary<string, double>();
    }

    public void AddAssignmentScore(string assignmentName, double score)
    {
        if (AssignmentScores.ContainsKey(assignmentName))
        {
            Console.WriteLine($"Assignment '{assignmentName}' score already exists for student '{Name}'.");
        }
        else
        {
            AssignmentScores.Add(assignmentName, score);
            Console.WriteLine($"Assignment '{assignmentName}' score added for student '{Name}': {score}");
        }
    }

    public void DisplayStudentInfo()
    {
        Console.WriteLine($"Student Name: {Name}");
        Console.WriteLine($"Student ID: {ID}");
        Console.WriteLine("Assignment Scores:");
        foreach (var assignment in AssignmentScores)
        {
            Console.WriteLine($"{assignment.Key}: {assignment.Value}");
        }
    }
}
