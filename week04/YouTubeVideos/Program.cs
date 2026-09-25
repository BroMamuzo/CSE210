class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        // Video 1
        Video video1 = new Video(
            "Learning C# Basics",
            "Programming Academy",
            600);

        video1.AddComment(new Comment(
            "John",
            "Great introduction to C#!"));

        video1.AddComment(new Comment(
            "Mary",
            "The examples were easy to follow."));

        video1.AddComment(new Comment(
            "David",
            "I learned something new today."));

        videos.Add(video1);

        // Video 2
        Video video2 = new Video(
            "Object-Oriented Programming Explained",
            "Code Master",
            840);

        video2.AddComment(new Comment(
            "Sarah",
            "The explanation of classes was helpful."));

        video2.AddComment(new Comment(
            "James",
            "Abstraction makes more sense now."));

        video2.AddComment(new Comment(
            "Grace",
            "Thanks for the clear examples."));

        videos.Add(video2);

        // Video 3
        Video video3 = new Video(
            "Building Your First C# Project",
            "Tech Tutorials",
            720);

        video3.AddComment(new Comment(
            "Daniel",
            "This project was fun to follow."));

        video3.AddComment(new Comment(
            "Esther",
            "The coding steps were clear."));

        video3.AddComment(new Comment(
            "Michael",
            "I will try this on my own."));

        videos.Add(video3);

        // Display all videos and their comments
        foreach (Video video in videos)
        {
            Console.WriteLine();
            video.Display();
            Console.WriteLine("----------------------------------------");
        }
    }
}
