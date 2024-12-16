using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create instances of each activity
        var running = new Running(new DateTime(2024, 12, 11), 30, 5.0); // 5 km in 30 minutes
        var cycling = new Cycling(new DateTime(2024, 12, 11), 40, 20.0); // 20 kph for 40 minutes
        var swimming = new Swimming(new DateTime(2024, 12, 11), 25, 20); // 20 laps in 25 minutes

        // Add to list
        var activities = new List<Activity> { running, cycling, swimming };

        // Display summaries
        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}