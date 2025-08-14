public class ProgressGoal : Goal
{
    private int _currentProgress;
    private int _targetProgress;

    public ProgressGoal(string name, string description, int points, int targetProgress)
        : base(name, description, points)
    {
        _targetProgress = targetProgress;
        _currentProgress = 0;
    }

    public override void RecordEvent()
    {
        _currentProgress++;
        if (_currentProgress >= _targetProgress)
        {
            _isComplete = true;
        }
    }

    public override string GetProgress() => $"[{_currentProgress}/{_targetProgress}]";

    public override string GetDetails() =>
        $"{base.GetDetails()} -- Progress: {_currentProgress}/{_targetProgress}";

    public override string GetSaveString() =>
        $"{base.GetSaveString()}|{_currentProgress}|{_targetProgress}";

    public override string GetGoalType() => "ProgressGoal";

    public int GetCurrentProgress() => _currentProgress;
    public int GetTargetProgress() => _targetProgress;
}