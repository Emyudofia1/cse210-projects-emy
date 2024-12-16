public class MilestoneGoal : Goal
{
    private List<int> _milestones;
    private int _currentMilestoneIndex;

    public MilestoneGoal(string name, string description, int points, List<int> milestones) 
        : base(name, description, points)
    {
        _milestones = milestones;
        _currentMilestoneIndex = 0;
    }

    public override void RecordProgress()
    {
        if (_currentMilestoneIndex < _milestones.Count)
        {
            _points += _milestones[_currentMilestoneIndex];
            _currentMilestoneIndex++;
        }
    }

    public override string DisplayStatus()
    {
        if (_currentMilestoneIndex >= _milestones.Count)
            return $"{_name} - {_description} - Completed - {_points} points";

        return $"{_name} - {_description} - Milestone {_currentMilestoneIndex + 1}/{_milestones.Count} - {_points} points";
    }

    public override string GetStringRepresentation()
    {
        return $"MilestoneGoal:{_name},{_description},{_points},{string.Join(";", _milestones)}";
    }
}