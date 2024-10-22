using System;
using System.Collections.Generic;

public class Comment
{
    public string CommenterName { get; }
    public string Text { get; }

    public Comment(string commenterName, string text)
    {
        CommenterName = commenterName;
        Text = text;
    }
}

public class Video
{
    public string Title { get; }
    public string Author { get; }
    public int Length { get; } // Length in seconds
    private List<Comment> comments;

    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        Length = length;
        comments = new List<Comment>();
    }

    public void AddComment(string commenterName, string text)
    {
        comments.Add(new Comment(commenterName, text));
    }

    public int NumberOfComments()
    {
        return comments.Count;
    }

    public List<Comment> GetComments()
    {
        return comments;
    }
}

class Program
{
    static void Main()
    {
        // Create videos
        var videos = new List<Video>
        {
            new Video("Learning C#", "Alice", 300),
            new Video("Understanding OOP", "Bob", 450),
            new Video("Data Science Basics", "Charlie", 600)
        };

        // Add comments to videos
        videos[0].AddComment("Dave", "Great video!");
        videos[0].AddComment("Eve", "Very helpful, thanks!");
        videos[0].AddComment("Frank", "Looking forward to more!");
        
        videos[1].AddComment("Grace", "Excellent explanation!");
        videos[1].AddComment("Heidi", "I learned a lot!");
        videos[1].AddComment("Ivan", "Thanks for the insights!");

        videos[2].AddComment("Judy", "Awesome content!");
        videos[2].AddComment("Mallory", "Very informative.");
        videos[2].AddComment("Oscar", "Can't wait to apply this!");

        // Display video information and comments
        foreach (var video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.Length} seconds");
            Console.WriteLine($"Number of Comments: {video.NumberOfComments()}");
            foreach (var comment in video.GetComments())
            {
                Console.WriteLine($"  - {comment.CommenterName}: {comment.Text}");
            }
            Console.WriteLine(); // Empty line for readability
        }
    }
}
