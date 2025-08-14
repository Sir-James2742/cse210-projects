public class NegativeGoal : Goal
{
    public NegativeGoal(string name, string description, int points)
        : base(name, description, points) { }

    public override void RecordEvent()
    {
        // Negative goals are never "complete"
    }

    public override string GetProgress() => "[⚠]";

    public override string GetGoalType() => "NegativeGoal";

    public override string GetDetails() => $"{GetProgress()} {_name} ({_description}) - LOSE {_points} points";
}