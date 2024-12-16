using System;

public abstract class Activity
{
    private DateTime _date;
    private int _minutes;

    public Activity(DateTime date, int minutes)
    {
        _date = date;
        _minutes = minutes;
    }

    public DateTime Date => _date;
    public int Minutes => _minutes;

    public abstract double GetDistance(); // in kilometers or miles
    public abstract double GetSpeed(); // in kph or mph
    public abstract double GetPace(); // in min per km or min per mile

    public virtual string GetSummary()
    {
        return $"{Date.ToString("dd MMM yyyy")} ({Minutes} min): " +
               $"Distance: {GetDistance():0.0}, Speed: {GetSpeed():0.0}, Pace: {GetPace():0.0}";
    }
}