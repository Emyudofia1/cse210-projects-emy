using System;

class ReflectionActivity : MindfulnessActivity
{
    public ReflectionActivity() : base("Reflection", "This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
    }

    protected override void ShowWelcomeMessage()
    {
        base.ShowWelcomeMessage();
        Console.WriteLine("Reflect on your past experiences of strength and perseverence.");
    }

    protected override void PerformActivity(int duration)
    {
        string[] prompts = {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        Console.WriteLine("Let's begin:");

        for (int i = 0; i < duration; i++)
        {
            string prompt = prompts[new Random().Next(prompts.Length)];
            Console.WriteLine(prompt); // Display the prompt
            Thread.Sleep(3000); // Pause for 3 seconds
            AskQuestions();
        }
    }

    private void AskQuestions()
    {
        string[] questions = {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?",
        };

        foreach (string question in questions)
        {
            Console.WriteLine(question);
            Thread.Sleep(4000); // Pause for 4 seconds 
        }
    }
}