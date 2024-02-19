class GradeCalculator
{
    public static double CalculateOverallGrade(Dictionary<string, double> assignmentScores, Dictionary<string, double> assignmentWeightage)
    {
        double totalWeightedScore = 0;
        double totalWeightage = 0;

        foreach (var assignment in assignmentScores)
        {
            if (assignmentWeightage.ContainsKey(assignment.Key))
            {
                double weightage = assignmentWeightage[assignment.Key];
                totalWeightedScore += (assignment.Value * weightage);
                totalWeightage += weightage;
            }
            else
            {
                Console.WriteLine($"Assignment '{assignment.Key}' weightage not found. Skipping calculation.");
            }
        }

        if (totalWeightage == 0)
        {
            Console.WriteLine("Error: Total weightage is 0. Cannot calculate overall grade.");
            return 0;
        }

        return totalWeightedScore / totalWeightage;
    }
}