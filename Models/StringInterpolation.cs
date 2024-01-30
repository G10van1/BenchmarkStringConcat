using System.Diagnostics;

namespace BenchmarkStringConcat.Models
{
    internal class StringInterpolation : IConcat
    {
        public (long, string) Concat(int size, string[] name)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            string result = "";
            string str = "";
            result = $"{this.GetType().ToString().Split('.')[2]}\n ";
            for (int i = 0; i < size; i++)
                str = $"{str}{i} {name[0]} {name[1]} {name[2]}\n";
            result = $"{result}{stopwatch.ElapsedMilliseconds.ToString().PadLeft(11, ' ')} ms\n";
            stopwatch.Stop();
            return (stopwatch.ElapsedMilliseconds, result);
        }
    }
}
