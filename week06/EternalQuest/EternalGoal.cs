public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points) { }

    public override void RecordEvent()
    {
        // Eternal goals are never complete
    }

    public override string GetProgress() => "[∞]";

    public override string GetGoalType() => "EternalGoal";
}
