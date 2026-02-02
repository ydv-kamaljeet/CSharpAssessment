public class CreatorStats
{
    public string? CreatorName { get; set; }
    public double[] WeeklyLikes { get; set; }
    public CreatorStats()
    {

    }
    public CreatorStats(string? creatorName, double[] weeklyLikes)
    {
        CreatorName = creatorName;
        WeeklyLikes = weeklyLikes;
    }
    public static List<CreatorStats> EngagementBoard = new List<CreatorStats>();
    public void RegisterCreator(CreatorStats record)
    {
        EngagementBoard.Add(record);
        Console.WriteLine("User Registered SuccessFully");
    }
    public Dictionary<string, int> GetTopPostCounts(List<CreatorStats> records, double likeThreshold)
    {
        Dictionary<string, int> result = new Dictionary<string, int>();

        foreach (var creator in records)
        {
            int count = 0;

            foreach (var val in creator.WeeklyLikes)
            {
                if (val >= likeThreshold)
                {
                    count++;
                }
            }

            if (count > 0)
            {
                result.Add(creator.CreatorName!, count);
            }
        }

        return result;
    }

    public double CalculateAverageLikes()
    {
        int count = 0;
        double total = 0;

        foreach (var creator in EngagementBoard)
        {
            foreach (var val in creator.WeeklyLikes)
            {
                count++;
                total += val;
            }
        }
        return total / count;
    }
}
public class Program
{
    public static void Main()
    {

        CreatorStats service = new CreatorStats();
        bool running = true;

        while (running)
        {
            Console.WriteLine();
            Console.WriteLine("1. Register Creator");
            Console.WriteLine("2. Show Top Posts");
            Console.WriteLine("3. Calculate Average Likes");
            Console.WriteLine("4. Exit");
            Console.WriteLine("Enter your choice:");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Enter Creator Name:");
                    string creatorName = Console.ReadLine();

                    Console.WriteLine("Enter weekly likes (Week 1 to 4):");
                    double[] weeklyLikes = new double[4];
                    for (int i = 0; i < 4; i++)
                    {
                        weeklyLikes[i] = double.Parse(Console.ReadLine());
                    }

                    CreatorStats record = new CreatorStats(creatorName, weeklyLikes);
                    service.RegisterCreator(record);

                    // Required output message
                    Console.WriteLine("Creator registered successfully");
                    break;

                case 2:
                    Console.WriteLine("Enter like threshold:");
                    double threshold = double.Parse(Console.ReadLine());

                    Dictionary<string, int> result =
                        service.GetTopPostCounts(CreatorStats.EngagementBoard, threshold);

                    if (result.Count == 0)
                    {
                        Console.WriteLine("No top-performing posts this week");
                    }
                    else
                    {
                        foreach (var item in result)
                        {
                            Console.WriteLine($"{item.Key} - {item.Value}");
                        }
                    }
                    break;

                case 3:
                    double average = service.CalculateAverageLikes();
                    Console.WriteLine($"Overall average weekly likes: {average}");
                    break;

                case 4:
                    Console.WriteLine("Logging off - Keep Creating with StreamBuzz!");
                    running = false;
                    break;

                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
    }
}