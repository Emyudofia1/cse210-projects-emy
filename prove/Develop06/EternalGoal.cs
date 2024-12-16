public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points) { }

    public override void RecordProgress()
    {
        // Points are added each time but no state change
    }

    public override string DisplayStatus()
    {
        return $"{_name} - {_description} - Ongoing - {_points} points";
    }

    public override string GetStringRepresentation()
    {
        return $"EternalGoal:{_name},{_description},{_points}";
    }
}