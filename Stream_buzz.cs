using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Stores engagement statistics related to a content creator,
/// including creator name and weekly like counts.
/// </summary>
public class CreatorStats
{
    /// <summary>
    /// Gets or sets the name of the content creator.
    /// </summary>
    public string CreatorName { get; set; }

    /// <summary>
    /// Gets or sets the weekly likes for the creator (4 weeks).
    /// </summary>
    public double[] WeeklyLikes { get; set; }
}

/// <summary>
/// Manages creator engagement records and provides
/// analytical operations on creator statistics.
/// </summary>
public class Program
{
    /// <summary>
    /// Stores all registered creators and their engagement data.
    /// </summary>
    public static List<CreatorStats> EngagementBoard = new List<CreatorStats>();

    /// <summary>
    /// Registers a new creator record into the engagement board.
    /// </summary>
    /// <param name="record">Creator statistics to be registered</param>
    public void RegisterCreator(CreatorStats record)
    {
        EngagementBoard.Add(record);
    }

    /// <summary>
    /// Returns a dictionary containing creators and the number of weeks
    /// where their likes meet or exceed the specified threshold.
    /// </summary>
    /// <param name="records">List of creator records to evaluate</param>
    /// <param name="likeThreshold">Minimum number of likes required</param>
    /// <returns>
    /// A dictionary where the key is the creator name and the value
    /// is the count of weeks meeting the threshold.
    /// </returns>
    public Dictionary<string, int> GetTopPostCounts(List<CreatorStats> records, double likeThreshold)
    {
        Dictionary<string, int> result = new Dictionary<string, int>();

        foreach (var creator in records)
        {
            int count = 0;

            foreach (double likes in creator.WeeklyLikes)
            {
                if (likes >= likeThreshold)
                {
                    count++;
                }
            }

            if (count > 0)
            {
                result.Add(creator.CreatorName, count);
            }
        }

        return result;
    }

    /// <summary>
    /// Calculates the overall average weekly likes
    /// across all registered creators.
    /// </summary>
    /// <returns>
    /// A double value representing the average weekly likes.
    /// Returns 0 if no records are available.
    /// </returns>
    public double CalculateAverageLikes()
    {
        double totalLikes = 0;
        int totalWeeks = 0;

        foreach (var creator in EngagementBoard)
        {
            foreach (double likes in creator.WeeklyLikes)
            {
                totalLikes += likes;
                totalWeeks++;
            }
        }

        return totalWeeks > 0 ? totalLikes / totalWeeks : 0;
    }

    /// <summary>
    /// Entry point of the application.
    /// Provides a menu-driven interface for managing
    /// and analyzing creator engagement data.
    /// </summary>
    /// <param name="args">Command-line arguments</param>
    public static void Main(string[] args)
    {
        Program program = new Program();
        bool running = true;

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
                    CreatorStats creator = new CreatorStats();

                    Console.WriteLine("Enter Creator Name:");
                    creator.CreatorName = Console.ReadLine();

                    creator.WeeklyLikes = new double[4];
                    Console.WriteLine("Enter weekly likes (Week 1 to 4):");

                    for (int i = 0; i
