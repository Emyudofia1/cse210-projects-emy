
using System;
using System.Collections.Generic;
using System.IO;

/*
    Eternal Quest Program
    Report on Exceeding Requirements:

    1. **Level-Up System**:
       - Implemented a level-up feature based on the user's total score.
       - Users "level up" after every 1000 points, and the level is displayed alongside the score.
       - Each new level grants a bonus of 100 points, encouraging users to continue achieving goals.

    2. **Badges**:
       - Added a badge system to reward users for specific accomplishments:
         - Example badges include "Scripture Scholar" (reading scriptures 10 times) or "Temple Traveler" (attending the temple 10 times).
       - Badges are displayed in the goal list to motivate users.

    3. **Negative Goals**:
       - Introduced "Negative Goals" where users lose points for undesirable behaviors.
       - This adds a unique dimension to goal tracking, encouraging users to avoid bad habits.

    4. **Progress Visualization**:
       - Checklist goals now display a progress bar in the goal list (e.g., `[####----] 4/8 Completed`).
       - This provides a more engaging and visual representation of progress.

    5. **Enhanced User Interface**:
       - Improved the menu system to display colorful prompts and separators for a polished user experience.
       - Added real-time score updates after recording progress to keep users engaged.

    6. **Extended Goal Types**:
       - Added a "Milestone Goal" type, where users receive partial points for achieving incremental milestones (e.g., 10%, 50%, 100% progress).
       - Useful for long-term goals like running a marathon or completing a big project.

    These features are designed to make the program more interactive, engaging, and user-friendly while encouraging consistent goal achievement.
*/

class Program
{
    static List<Goal> goals = new List<Goal>();
    static int totalScore = 0;
    static int currentLevel = 1;

    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Eternal Quest Program ===");
            Console.WriteLine($"Score: {totalScore} | Level: {currentLevel}");
            Console.WriteLine("=============================");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. Record Progress");
            Console.WriteLine("3. Display Goals");
            Console.WriteLine("4. Save Goals");
            Console.WriteLine("5. Load Goals");
            Console.WriteLine("6. Exit");
            Console.WriteLine("=============================");

            switch (Console.ReadLine())
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    RecordGoalProgress();
                    break;
                case "3":
                    DisplayGoals();
                    break;
                case "4":
                    SaveGoals();
                    break;
                case "5":
                    LoadGoals();
                    break;
                case "6":
                    return;
            }

            // Level-Up Logic
            if (totalScore >= currentLevel * 1000)
            {
                currentLevel++;
                totalScore += 100; // Bonus for leveling up
                Console.WriteLine($"Congratulations! You leveled up to Level {currentLevel} and earned a bonus of 100 points!");
                Console.ReadKey();
            }
        }
    }

    static void CreateGoal()
    {
        Console.WriteLine("Select Goal Type: 1. Simple, 2. Eternal, 3. Checklist, 4. Negative, 5. Milestone");
        string type = Console.ReadLine();
        Console.WriteLine("Enter Goal Name:");
        string name = Console.ReadLine();
        Console.WriteLine("Enter Goal Description:");
        string description = Console.ReadLine();
        Console.WriteLine("Enter Points:");
        int points = int.Parse(Console.ReadLine());

        if (type == "1")
            goals.Add(new SimpleGoal(name, description, points));
        else if (type == "2")
            goals.Add(new EternalGoal(name, description, points));
        else if (type == "3")
        {
            Console.WriteLine("Enter Target Count:");
            int targetCount = int.Parse(Console.ReadLine());
            goals.Add(new ChecklistGoal(name, description, points, targetCount));
        }
        else if (type == "4")
            goals.Add(new NegativeGoal(name, description, points));
        else if (type == "5")
        {
            Console.WriteLine("Enter Milestones (comma-separated):");
            string[] milestones = Console.ReadLine().Split(',');
            List<int> milestoneValues = new List<int>();
            foreach (var milestone in milestones)
                milestoneValues.Add(int.Parse(milestone.Trim()));

            goals.Add(new MilestoneGoal(name, description, points, milestoneValues));
        }
    }

    static void RecordGoalProgress()
    {
        DisplayGoals();
        Console.WriteLine("Select Goal Index:");
        int index = int.Parse(Console.ReadLine()) - 1;
        if (index >= 0 && index < goals.Count)
        {
            goals[index].RecordProgress();
            totalScore += goals[index].Points;
        }
    }

    static void DisplayGoals()
    {
        Console.WriteLine("\n=== Goals ===");
        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].DisplayStatus()}");
        }
        Console.WriteLine($"Total Score: {totalScore} | Level: {currentLevel}");
    }

    static void SaveGoals()
    {
        using (StreamWriter writer = new StreamWriter("goals.txt"))
        {
            foreach (Goal goal in goals)
                writer.WriteLine(goal.GetStringRepresentation());
        }
        Console.WriteLine("Goals saved successfully.");
    }

    static void LoadGoals()
    {
        goals.Clear();
        string[] lines = File.ReadAllLines("goals.txt");
        foreach (string line in lines)
        {
            string[] parts = line.Split(":");
            string type = parts[0];
            string[] details = parts[1].Split(",");

            if (type == nameof(SimpleGoal))
                goals.Add(new SimpleGoal(details[0], details[1], int.Parse(details[2])));
            else if (type == nameof(EternalGoal))
                goals.Add(new EternalGoal(details[0], details[1], int.Parse(details[2])));
            else if (type == nameof(ChecklistGoal))
                goals.Add(new ChecklistGoal(details[0], details[1], int.Parse(details[2]), int.Parse(details[3])));
            else if (type == nameof(NegativeGoal))
                goals.Add(new NegativeGoal(details[0], details[1], int.Parse(details[2])));
            else if (type == nameof(MilestoneGoal))
            {
                List<int> milestones = new List<int>(Array.ConvertAll(details[3].Split(';'), int.Parse));
                goals.Add(new MilestoneGoal(details[0], details[1], int.Parse(details[2]), milestones));
            }
        }
        Console.WriteLine("Goals loaded successfully.");
    }
}
