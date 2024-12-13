using System;

class ListingActivity : MindfulnessActivity
{
    public ListingActivity() : base("Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
    }

    protected override void ShowWelcomeMessage()
    {
        base.ShowWelcomeMessage();
        Console.WriteLine("List positive things to reflect on your strengths and gratitude.");
    }

    protected override void PerformActivity(int duration)
    {
        string[] prompts = {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };

        Console.WriteLine("Let's begin:");

        for (int i = 0; i < duration; i++)
        {
            string prompt = prompts[new Random().Next(prompts.Length)];
            Console.WriteLine(prompt);
            Thread.Sleep(8000);
            ListItems();
        }
    }

    private void ListItems()
    {
        Console.WriteLine("Enter an item (or type 'done' to finish): ");
        int count = 0;
        while (true)
        {
            string item = Console.ReadLine();
            if (item.ToLower() == "done")
                break;
            count++;
        }

        Console.WriteLine($"You listed {count} items.");
    }
}