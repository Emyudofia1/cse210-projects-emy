public class SimpleGoal : Goal
{
    private bool _isCompleted;

    public SimpleGoal(string name, string description, int points) 
        : base(name, description, points)
    {
        _isCompleted = false;
    }

    public override void RecordProgress()
    {
        _isCompleted = true;
    }

    public override string DisplayStatus()
    {
        return $"{_name} - {_description} - {( _isCompleted ? "[X]" : "[ ]")} - {_points} points";
    }

    public override string GetStringRepresentation()
    {
        return $"SimpleGoal:{_name},{_description},{_points},{_isCompleted}";
    }
}