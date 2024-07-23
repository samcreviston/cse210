using System;
using System.Collections.Generic;

class Video
{
    // Private fields
    private string title;
    private string author;
    private float lengthInSeconds;
    private List<Comment> comments;

    // Public properties
    public string Title
    {
        get { return title; }
        set { title = value; }
    }

    public string Author
    {
        get { return author; }
        set { author = value; }
    }

    public float LengthInSeconds
    {
        get { return lengthInSeconds; }
        set { lengthInSeconds = value; }
    }

    public List<Comment> Comments
    {
        get { return comments; }
        set { comments = value; }
    }

    public Video()
    {
        comments = new List<Comment>(); // Initialize the comments list
    }

    public int GetNumberOfComments()
    {
        return comments.Count;
    }
}

class Comment
{
    private string commenterName;
    private string text;

    public string CommenterName
    {
        get { return commenterName; }
        set { commenterName = value; }
    }

    public string Text
    {
        get { return text; }
        set { text = value; }
    }

    public Comment(string commenterName, string text)
    {
        this.commenterName = commenterName;
        this.text = text;
    }
}

class Program
{
    static void Main()
    {
        // Create four videos
        Video video1 = new Video();
        video1.Title = "Hamilton's Hip-Hop History: Rapping the Revolution";
        video1.Author = "Alexander Hamilton";
        video1.LengthInSeconds = 630;
        video1.Comments.Add(new Comment("George Washington", "Fantastic content!"));
        video1.Comments.Add(new Comment("Thomas Jefferson", "Very enlightening."));
        video1.Comments.Add(new Comment("John Adams", "Interesting perspective."));
        video1.Comments.Add(new Comment("John Jay", "Well done and engaging."));

        Video video2 = new Video();
        video2.Title = "Video 2";
        video2.Author = "Jefferson’s Jokes: The Declaration of Laughs";
        video2.LengthInSeconds = 1200;
        video2.Comments.Add(new Comment("Alexander Hamilton", "Very educational!"));
        video2.Comments.Add(new Comment("James Madison", "Appreciated the insights."));
        video2.Comments.Add(new Comment("Samuel Adams", "Decent video, though a bit lengthy."));
        video2.Comments.Add(new Comment("Benjamin Franklin", "Informative, but could use more detail."));

        Video video3 = new Video();
        video3.Title = "What Not to Do When Flying a Kite";
        video3.Author = "Benjamin Franklin";
        video3.LengthInSeconds = 1410;
        video3.Comments.Add(new Comment("George Washington", "This video was okay."));
        video3.Comments.Add(new Comment("Thomas Jefferson", "Had some interesting points, but missed depth."));
        video3.Comments.Add(new Comment("John Adams", "A bit confusing and not very engaging."));
        video3.Comments.Add(new Comment("Alexander Hamilton", "Not my favorite; it dragged on a bit."));

        Video video4 = new Video();
        video4.Title = "The Founding Fathers’ Super Squad";
        video4.Author = "John Jay";
        video4.LengthInSeconds = 528;
        video4.Comments.Add(new Comment("James Madison", "Great watch, very informative."));
        video4.Comments.Add(new Comment("Samuel Adams", "Well-structured and insightful."));
        video4.Comments.Add(new Comment("John Jay", "Enjoyable and thought-provoking."));
        video4.Comments.Add(new Comment("Benjamin Franklin", "Excellent video, highly recommend."));

        // Add videos to a list
        List<Video> videos = new List<Video> { video1, video2, video3, video4 };

        // Display information for each video
        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.LengthInSeconds} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");

            Console.WriteLine("Comments:");
            foreach (Comment comment in video.Comments)
            {
                Console.WriteLine($"- {comment.CommenterName}: {comment.Text}");
            }

            Console.WriteLine();
        }
    }
}
