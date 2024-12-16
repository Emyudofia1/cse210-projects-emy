
public abstract class Goal
{
    protected string _name;
    protected string _description;
    protected int _points;

    public Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
    }

    public virtual int Points => _points;

    public abstract void RecordProgress();

    public abstract string DisplayStatus();

    public abstract string GetStringRepresentation();
}
