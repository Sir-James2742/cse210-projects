public class SimpleGoal : Goal
{
    public SimpleGoal(string name, string description, int points)
        : base(name, description, points) { }

    public override void RecordEvent()
    {
        _isComplete = true;
    }

    public override string GetProgress() => _isComplete ? "[X]" : "[ ]";

    public override string GetGoalType() => "SimpleGoal";
}