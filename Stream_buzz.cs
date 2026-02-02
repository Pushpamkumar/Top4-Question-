using System;
using System.Collections.Generic;
using System.Linq;

// Class to store statistics related to a content creator
public class CreatorStats
{
    // Name of the creator
    public string CreatorName { get; set; }

    // Array to store weekly likes for 4 weeks
    public double[] WeeklyLikes { get; set; }
}

public class Program
{
    // Static list to maintain all registered creators
    public static List<CreatorStats> EngagementBoard = new List<CreatorStats>();

    // Registers a creator record into the EngagementBoard
    public void RegisterCreator(CreatorStats record)
    {
        EngagementBoard.Add(record);
    }

    // Returns a dictionary containing creators and
    // the count of weeks where likes are >= given threshold
    public Dictionary<string, int> GetTopPostCounts(List<CreatorStats> records, double likeThreshold)
    {
        Dictionary<string, int> result = new Dictionary<string, int>();

        // Iterate through each creator
        foreach (var creator in records)
        {
            int count = 0;

            // Count weeks where likes meet or exceed threshold
            foreach (double likes in creator.WeeklyLikes)
            {
                if (likes >= likeThreshold)
                {
                    count++;
                }
            }

            // Add to result only if threshold met at least once
            if (count > 0)
            {
                result.Add(creator.CreatorName, count);
            }
        }

        return result;
    }

    // Calculates the overall average weekly likes
    // across all registered creators
    public double CalculateAverageLikes()
    {
        double totalLikes = 0;
        int totalWeeks = 0;

        // Sum all weekly likes and count total weeks
        foreach (var creator in EngagementBoard)
        {
            foreach (double likes in creator.WeeklyLikes)
            {
                totalLikes += likes;
                totalWeeks++;
            }
        }

        // Return average, avoid division by zero
        return totalWeeks > 0 ? totalLikes / totalWeeks : 0;
    }

    // Entry point of the application
    public static void Main(string[] args)
    {
        Program program = new Program();
        bool running = true;

        // Menu-driven loop
        while (running)
        {
            Console.WriteLine("\n1. Register Creator");
            Console.WriteLine("2. Show Top Posts");
            Console.WriteLine("3. Calculate Average Likes");
            Console.WriteLine("4. Exit");
            Console.WriteLine("Enter your choice:");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    // Register a new creator
                    CreatorStats creator = new CreatorStats();

                    Console.WriteLine("Enter Creator Name:");
                    creator.CreatorName = Console.ReadLine();

                    creator.WeeklyLikes = new double[4];
                    Console.WriteLine("Enter weekly likes (Week 1 to 4):");

                    // Read likes for 4 weeks
                    for (int i = 0; i < 4; i++)
                    {
                        creator.WeeklyLikes[i] = Convert.ToDouble(Console.ReadLine());
                    }

                    program.RegisterCreator(creator);
                    Console.WriteLine("Creator registered successfully");
                    break;

                case 2:
                    // Display top-performing creators
                    Console.WriteLine("Enter like threshold:");
                    double threshold = Convert.ToDouble(Console.ReadLine());

                    Dictionary<string, int> topPosts =
                        program.GetTopPostCounts(EngagementBoard, threshold);

                    if (topPosts.Count == 0)
                    {
                        Console.WriteLine("No top-performing posts this week");
                    }
                    else
                    {
                        foreach (var item in topPosts)
                        {
                            Console.WriteLine(item.Key + " - " + item.Value);
                        }
                    }
                    break;

                case 3:
                    // Calculate and display average likes
                    double average = program.CalculateAverageLikes();
                    Console.WriteLine("Overall average weekly likes: " + average);
                    break;

                case 4:
                    // Exit the application gracefully
                    Console.WriteLine("Logging off - Keep Creating with StreamBuzz!");
                    running = false;
                    break;

                default:
                    // Handle invalid menu option
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
    }
}
