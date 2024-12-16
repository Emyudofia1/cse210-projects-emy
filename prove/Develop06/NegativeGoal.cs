public class NegativeGoal : Goal
{
    public NegativeGoal(string name, string description, int points)
        : base(name, description, points) { }

    public override void RecordProgress()
    {
        _points = -Math.Abs(_points); // Negative points
    }

    public override string DisplayStatus()
    {
        return $"{_name} - {_description} - Penalty: {_points} points";
    }

    public override string GetStringRepresentation()
    {
        return $"NegativeGoal:{_name},{_description},{_points}";
    }
}