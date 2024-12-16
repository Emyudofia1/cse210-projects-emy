public class ChecklistGoal : Goal
{
    private int _targetCount;
    private int _currentCount;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int targetCount) 
        : base(name, description, points)
    {
        _targetCount = targetCount;
        _currentCount = 0;
        _bonus = 500; // Example bonus
    }

    public override void RecordProgress()
    {
        _currentCount++;
        if (_currentCount >= _targetCount)
        {
            _points += _bonus; // Add bonus
        }
    }

    public override string DisplayStatus()
    {
        string progress = $"{_currentCount}/{_targetCount}";
        return $"{_name} - {_description} - {progress} - {_points} points";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal:{_name},{_description},{_points},{_currentCount},{_targetCount}";
    }
}