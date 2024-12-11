// using System;

// class Program
// {
//     static void Main(string[] args)
//     {
//         Console.WriteLine("Hello Foundation1 World!");
        
//     }
 
// }


using System;
using System.Collections.Generic;

class Comment
{
    public string CommenterName { get; set; }
    public string Text { get; set; }

    public Comment(string commenterName, string text)
    {
        CommenterName = commenterName;
        Text = text;
    }

    public override string ToString()
    {
        return $"{CommenterName}: {Text}";
    }
}

class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Length { get; set; } // in seconds
    private List<Comment> Comments { get; set; }

    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        Length = length;
        Comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        Comments.Add(comment);
    }

    public int GetCommentCount()
    {
        return Comments.Count;
    }

    public override string ToString()
    {
        int minutes = Length / 60;
        int seconds = Length % 60;
        string lengthStr = minutes > 0 ? $"{minutes}:{seconds:D2}" : $"{seconds} seconds";
        return $"Title: {Title}\nAuthor: {Author}\nLength: {lengthStr}\nComments: {GetCommentCount()}";
    }

    public void DisplayComments()
    {
        foreach (var comment in Comments)
        {
            Console.WriteLine($"- {comment}");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Creating videos
        Video video1 = new Video("How to Code in C#", "Tech Guru", 600);
        Video video2 = new Video("Top 10 Programming Languages", "CodeWorld", 480);
        Video video3 = new Video("Understanding Algorithms", "MathWhiz", 720);

        // Adding comments to video1
        video1.AddComment(new Comment("Alice", "Great tutorial!"));
        video1.AddComment(new Comment("Bob", "Very helpful, thanks!"));
        video1.AddComment(new Comment("Charlie", "Clear and concise."));

        // Adding comments to video2
        video2.AddComment(new Comment("Diana", "Loved the explanations."));
        video2.AddComment(new Comment("Eve", "Cool content!"));
        video2.AddComment(new Comment("Frank", "What about Rust?"));

        // Adding comments to video3
        video3.AddComment(new Comment("Grace", "The examples were spot on."));
        video3.AddComment(new Comment("Heidi", "This was so insightful!"));
        video3.AddComment(new Comment("Ivan", "Can you make a video on data structures?"));

        // Storing videos in a list
        List<Video> videos = new List<Video> { video1, video2, video3 };

        // Displaying information for each video
        foreach (var video in videos)
        {
            Console.WriteLine(video);
            Console.WriteLine("Comments:");
            video.DisplayComments();
            Console.WriteLine("\n---\n");
        }
    }
}

