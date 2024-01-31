using BenchmarkStringConcat.Models;

namespace BenchmarkStringConcat
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Comparing time spent concating strings in different ways.\n");

            const int SIZE = 10000;
            string[] names = { "First", "Middle", "Last" };

            Console.WriteLine($"Concating {SIZE} names\n");

            List <IConcat> concats = new List<IConcat>
            {
                new StringPlus(),
                new StringInterpolation(),
                new StringJoin(),
                new StringConcat(),
                new StringFormat(),
                new StringBuilder(),
                new StringList()
            };

            // Create array tasks
            Task<(long, string)>[] tasks = new Task<(long, string)>[concats.Count];

            // Launch tasks in parallel execution
            int i = 0;
            foreach (var c in concats)
                tasks[i++] = Task.Run(() => c.Concat(SIZE, names));

            // Wait for all tasks to complete
            Task.WaitAll(tasks);

            SortedDictionary<long, string> times = new SortedDictionary<long, string>();

            for (i = 0; i < concats.Count; i++)
            {
                int count = 0;
                while (true)
                {
                    try
                    {
                        times.Add(tasks[i].Result.Item1 + count++, tasks[i].Result.Item2);
                        break;
                    }
                    catch (ArgumentException) { continue; }
                    catch (Exception ex) { Console.WriteLine(ex.Message); }
                }
            }

            foreach (var time in times)
                Console.WriteLine(time.Value);
        }
    }    
}