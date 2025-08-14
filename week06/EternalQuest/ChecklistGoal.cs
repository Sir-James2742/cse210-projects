public class ChecklistGoal : Goal
{
    private int _targetCount;
    private int _currentCount;
    private int _bonusPoints;

    public ChecklistGoal(string name, string description, int points, int targetCount, int bonusPoints)
        : base(name, description, points)
    {
        _targetCount = targetCount;
        _currentCount = 0;
        _bonusPoints = bonusPoints;
    }

    public override void RecordEvent()
    {
        _currentCount++;
        if (_currentCount >= _targetCount)
        {
            _isComplete = true;
        }
    }

    public override string GetProgress() => $"Completed {_currentCount}/{_targetCount}";

    public override string GetDetails() =>
        $"{base.GetDetails()} -- Currently completed: {_currentCount}/{_targetCount}";

    public override string GetSaveString() =>
        $"{base.GetSaveString()}|{_currentCount}|{_targetCount}|{_bonusPoints}";

    public int GetBonusPoints() => _bonusPoints;
    public int GetCurrentCount() => _currentCount;
    public int GetTargetCount() => _targetCount;

    public override string GetGoalType() => "ChecklistGoal";
}