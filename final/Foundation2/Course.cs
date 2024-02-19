class Course
{
    public string CourseName { get; private set; }
    public Dictionary<string, double> AssignmentWeightage { get; private set; }

    public Course(string courseName)
    {
        CourseName = courseName;
        AssignmentWeightage = new Dictionary<string, double>();
    }

    public void AddAssignment(string assignmentName, double weightage)
    {
        if (AssignmentWeightage.ContainsKey(assignmentName))
        {
            Console.WriteLine($"Assignment '{assignmentName}' already exists.");
        }
        else
        {
            AssignmentWeightage.Add(assignmentName, weightage);
            Console.WriteLine($"Assignment '{assignmentName}' added with weightage {weightage}%.");
        }
    }

    public void RemoveAssignment(string assignmentName)
    {
        if (AssignmentWeightage.ContainsKey(assignmentName))
        {
            AssignmentWeightage.Remove(assignmentName);
            Console.WriteLine($"Assignment '{assignmentName}' removed.");
        }
        else
        {
            Console.WriteLine($"Assignment '{assignmentName}' does not exist.");
        }
    }

    public void DisplayAssignmentWeightage()
    {
        Console.WriteLine($"Assignment Weightage for Course: {CourseName}");
        foreach (var assignment in AssignmentWeightage)
        {
            Console.WriteLine($"{assignment.Key}: {assignment.Value}%");
        }
    }
}