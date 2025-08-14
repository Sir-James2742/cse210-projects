public class GoalManager
{
    private List<Goal> _goals;
    private int _score;
    private int _level;
    private int _experience;
    private int _experienceToNextLevel;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
        _level = 1;
        _experience = 0;
        _experienceToNextLevel = 1000;
    }

    public void AddGoal(Goal goal) => _goals.Add(goal);

    public void RecordGoalCompletion(int goalIndex)
    {
        if (goalIndex >= 0 && goalIndex < _goals.Count)
        {
            Goal goal = _goals[goalIndex];

            if (goal is NegativeGoal)
            {
                _score -= goal.GetPoints();
                Console.WriteLine($"Oops! You lost {goal.GetPoints()} points for {goal.GetName()}!");
            }
            else
            {
                int pointsEarned = goal.GetPoints();

                if (goal is ChecklistGoal checklistGoal && checklistGoal.IsComplete())
                {
                    pointsEarned += checklistGoal.GetBonusPoints();
                    Console.WriteLine($"BONUS! You earned {checklistGoal.GetBonusPoints()} bonus points!");
                }

                _score += pointsEarned;
                _experience += pointsEarned;
                Console.WriteLine($"Congratulations! You earned {pointsEarned} points!");

                CheckLevelUp();
            }

            goal.RecordEvent();
        }
    }

    private void CheckLevelUp()
    {
        while (_experience >= _experienceToNextLevel)
        {
            _experience -= _experienceToNextLevel;
            _level++;
            _experienceToNextLevel = (int)(_experienceToNextLevel * 1.5);
            Console.WriteLine($"LEVEL UP! You are now level {_level}!");
            Console.WriteLine($"Next level in {_experienceToNextLevel} XP");
        }
    }

    public void DisplayGoals()
    {
        Console.WriteLine("\nYour Goals:");
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals yet. Create some!");
            return;
        }

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetails()}");
        }
    }

    public void DisplayScore() =>
        Console.WriteLine($"\nYou have {_score} points. Level: {_level} (XP: {_experience}/{_experienceToNextLevel})");

    public void SaveGoals(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(_score);
            writer.WriteLine(_level);
            writer.WriteLine(_experience);
            writer.WriteLine(_experienceToNextLevel);

            foreach (Goal goal in _goals)
            {
                writer.WriteLine(goal.GetSaveString());
            }
        }
    }

    public void LoadGoals(string filename)
    {
        if (File.Exists(filename))
        {
            string[] lines = File.ReadAllLines(filename);
            _score = int.Parse(lines[0]);
            _level = int.Parse(lines[1]);
            _experience = int.Parse(lines[2]);
            _experienceToNextLevel = int.Parse(lines[3]);

            _goals.Clear();

            for (int i = 4; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split('|');
                string goalType = parts[0];
                string name = parts[1];
                string description = parts[2];
                int points = int.Parse(parts[3]);
                bool isComplete = bool.Parse(parts[4]);

                Goal goal = null;

                switch (goalType)
                {
                    case "SimpleGoal":
                        goal = new SimpleGoal(name, description, points);
                        break;
                    case "EternalGoal":
                        goal = new EternalGoal(name, description, points);
                        break;
                    case "ChecklistGoal":
                        int currentCount = int.Parse(parts[5]);
                        int targetCount = int.Parse(parts[6]);
                        int bonusPoints = int.Parse(parts[7]);
                        goal = new ChecklistGoal(name, description, points, targetCount, bonusPoints);
                        ((ChecklistGoal)goal).RecordEvent(); // Hack to set current count
                        for (int j = 1; j < currentCount; j++)
                            ((ChecklistGoal)goal).RecordEvent();
                        break;
                    case "NegativeGoal":
                        goal = new NegativeGoal(name, description, points);
                        break;
                    case "ProgressGoal":
                        int currentProgress = int.Parse(parts[5]);
                        int targetProgress = int.Parse(parts[6]);
                        goal = new ProgressGoal(name, description, points, targetProgress);
                        for (int j = 0; j < currentProgress; j++)
                            ((ProgressGoal)goal).RecordEvent();
                        break;
                }

                if (goal != null)
                {
                    _goals.Add(goal);
                }
            }
        }
    }
}
