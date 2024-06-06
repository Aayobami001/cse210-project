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

public class Comment
{
    public string Name { get; set; }
    public string Text { get; set; }

    public Comment(string name, string text)
    {
        Name = name;
        Text = text;
    }
}

public class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Length { get; set; }
    private List<Comment> comments;

    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        Length = length;
        comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        comments.Add(comment);
    }

    public int GetNumberOfComments()
    {
        return comments.Count;
    }

    public List<Comment> GetComments()
    {
        return comments;
    }
}

public class Program
{
    public static void Main()
    {
        // Create videos
        Video video1 = new Video("Video 1", "Author 1", 300);
        Video video2 = new Video("Video 2", "Author 2", 600);
        Video video3 = new Video("Video 3", "Author 3", 150);

        // Add comments to video1
        video1.AddComment(new Comment("User1", "Great video!"));
        video1.AddComment(new Comment("User2", "Thanks for sharing!💯"));
        video1.AddComment(new Comment("User3", "Very informative."));

        // Add comments to video2
        video2.AddComment(new Comment("User4", "Nice work!"));
        video2.AddComment(new Comment("User5", "Loved it."));
        video2.AddComment(new Comment("User6", "Awesome!100"));

        // Add comments to video3
        video3.AddComment(new Comment("User7", "Good job."));
        video3.AddComment(new Comment("User8", "Interesting content."));
        video3.AddComment(new Comment("User9", "Keep it up On 100!"));

        // Store videos in a list
        List<Video> videos = new List<Video> { video1, video2, video3 };

        // Iterate through the list and display information
        foreach (var video in videos)
        {
            Console.WriteLine("Presenting Abstartion With YouTube Videos:\n");
            Console.WriteLine($"Title Of Video: {video.Title}");
            Console.WriteLine($"Author Of Video: {video.Author}");
            Console.WriteLine($"Video Length: {video.Length} seconds");
            Console.WriteLine($"Number of Current Comments : {video.GetNumberOfComments()}");

            foreach (var comment in video.GetComments())
            {
                Console.WriteLine($" - {comment.Name}: {comment.Text}");
            }

            Console.WriteLine();
        }
    }
}
