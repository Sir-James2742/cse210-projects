using System;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>
        {
            new Video("Wonders of Russia", "Romanov", 30000){
                Comments = new List<Comment>
                {
                    new Comment("Great video!", "Alice"),
                    new Comment("Very informative.", "Bob"),
                    new Comment("Thanks for sharing!", "Charlie")
                }
            },
            new Video("Entreprenuer mentaity", "Notiversity", 334500){
                Comments = new List<Comment>
                {
                    new Comment("Great video!", "Alice"),
                    new Comment("Very informative.", "Bob"),
                    new Comment("Thanks for sharing!", "Charlie")
                }

            },
            new Video("Lost City", "Lifeder Doe", 13253648){
                Comments = new List<Comment>
                {
                    new Comment("Great video!", "Alice"),
                    new Comment("Very informative.", "Bob"),
                    new Comment("Thanks for sharing!", "Charlie")
                }

            }
        };
        
        foreach (var video in videos)
        {   
            
            Console.WriteLine(video.displayVideo());
            Console.WriteLine($"Comments:{video.Comments.Count}");
            foreach (var comment in video.Comments)
            {
                Console.WriteLine(comment.displayComment());
            }
            Console.WriteLine();
        }
    }
}