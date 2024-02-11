// Class for progressive goals
public class ProgressiveGoal : Goal
{
    public int Progress { get; set; }
    public int TargetProgress { get; }
    public int Reward { get;}

    // Constructor
    public ProgressiveGoal(string name, int targetProgress) : base(name)
    {
        TargetProgress = targetProgress;
        Progress = 0;
    }

    // Method to record progress
    public new void RecordProgress()
    {
        base.RecordProgress();
        Progress++;
        if (Progress >= TargetProgress)
        {
            MarkCompleted();
        }
        else
        {
            Console.WriteLine($"You made progress on the {Name} goal.");
        }
    }

    // Override method
    public override int GetReward()
    {
        return Completed ? 100 : 0; // Reward 100 points when completed
    }
}