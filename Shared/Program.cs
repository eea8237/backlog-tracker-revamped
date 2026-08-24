using Shared.Models;

namespace Shared
{
    class Program
    {
        static void Main(string[] args)
        {
            var items = new List<BacklogItem>
            {
                new BacklogItem
                {
                    ItemId = 1,
                    Name = "testItem1",
                    Medium = "testMedium",
                    Series =  "testSeries",
                    IsComplete = false,
                    IsOwned = true,
                    InProgress = false
                },
                new BacklogItem
                {
                    ItemId = 2,
                    Name = "testItem2",
                    Medium = "testMedium",
                    Series =  "anotherTestSeries",
                    IsComplete = false,
                    IsOwned = true,
                    InProgress = false
                },
                new BacklogItem
                {
                    ItemId = 3,
                    Name = "testItem3",
                    Medium = "anotherTestMedium",
                    Series =  "anotherTestSeries",
                    IsComplete = false,
                    IsOwned = true,
                    InProgress = false
                },
                new BacklogItem
                {
                    ItemId = 4,
                    Name = "testItem4",
                    Medium = "testMedium",
                    Series =  "testSeries",
                    IsComplete = false,
                    IsOwned = false,
                    InProgress = false
                },
                new BacklogItem
                {
                    ItemId = 5,
                    Name = "testItem5",
                    Medium = "anotherTestMedium",
                    Series =  "testSeries",
                    IsComplete = false,
                    IsOwned = true,
                    InProgress = true
                },
                new BacklogItem
                {
                    ItemId = 6,
                    Name = "testItem6",
                    Medium = "testMedium",
                    Series =  "testSeries",
                    IsComplete = true,
                    IsOwned = true,
                    InProgress = false
                },
                new BacklogItem
                {
                    ItemId = 7,
                    Name = "testItem7",
                    Medium = "anotherTestMedium",
                    Series =  "anotherTestSeries",
                    IsComplete = true,
                    IsOwned = true,
                    InProgress = false
                },
                new BacklogItem
                {
                    ItemId = 8,
                    Name = "testItem8",
                    Medium = "testMedium",
                    Series =  "testSeries",
                    IsComplete = true,
                    IsOwned = true,
                    InProgress = false
                },
                new BacklogItem
                {
                    ItemId = 9,
                    Name = "testItem9",
                    Medium = "testMedium",
                    Series =  "testSeries",
                    IsComplete = false,
                    IsOwned = false,
                    InProgress = true
                },
                new BacklogItem
                {
                    ItemId = 10,
                    Name = "testItem10",
                    Medium = "testMedium",
                    Series =  "testSeries",
                    IsComplete = false,
                    IsOwned = false,
                    InProgress = true,
                    Notes = "testing testing 123"
                }
            };
            var backlog = new Backlog 
            {
                UserId=1,
                BacklogId=1,
                Name="test",
            };
            foreach (var item in items)
            {
                backlog.Items.Add(item);
                Console.WriteLine(item);
                Console.WriteLine($"Added {item.Name}");
            } 
            
            Console.WriteLine();
            Console.WriteLine(backlog);

            // testing retrieving items
            Console.WriteLine("good retrieval:");
            Console.WriteLine(backlog.GetByName("testItem1"));
            Console.WriteLine(backlog.GetById(2));

            Console.WriteLine();
            Console.WriteLine("bad retrieval:");
            Console.WriteLine(backlog.GetByName("testItem"));
            Console.WriteLine(backlog.GetById(-1));
            
            // testing sorting
            Console.WriteLine("sort by medium:");
            Console.WriteLine(string.Join(", ", Backlog.GetItemNames(backlog.GetByMedium("testMedium"))));
            Console.WriteLine();

            Console.WriteLine("sort by series:");
            Console.WriteLine(string.Join(", ", Backlog.GetItemNames(backlog.GetBySeries("testSeries"))));
            Console.WriteLine();

            Console.WriteLine("sort by completion:");
            Console.WriteLine(string.Join(", ", Backlog.GetItemNames(backlog.GetByCompletion(true))));
            Console.WriteLine();

            Console.WriteLine("sort by ownership:");
            Console.WriteLine(string.Join(", ", Backlog.GetItemNames(backlog.GetByOwnership(false))));
            Console.WriteLine();

            Console.WriteLine("sort by progression:");
            Console.WriteLine(string.Join(", ", Backlog.GetItemNames(backlog.GetByProgression(true))));
            Console.WriteLine();

            // get series and mediums
            var series = backlog.GetSeries();
            Console.WriteLine("series in backlog:");
            Console.WriteLine(string.Join(", ", series));
            Console.WriteLine($"{series.Count()} series total");
            Console.WriteLine();

            var mediums = backlog.GetMediums();
            Console.WriteLine("mediums in backlog:");
            Console.WriteLine(string.Join(", ", mediums));
            Console.WriteLine($"{mediums.Count()} mediums total");
            Console.WriteLine();
            


        }
    }
}