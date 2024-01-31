using System.Diagnostics;

namespace BenchmarkStringConcat.Models
{
    internal class StringJoin : IConcat
    {
        public (long, string) Concat(int size, string[] name)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            string result = this.GetType().ToString().Split('.')[2] + '\n';
            string str = "";
            for (int i = 0; i < size; i++)
                str = String.Join(' '
                            , str
                            , i.ToString()
                            , name[0]
                            , name[1]
                            , name[2]
                            , '\n');

            stopwatch.Stop();
            long nanoseconds = (long)Math.Round(((double)stopwatch.ElapsedTicks / Stopwatch.Frequency) * 1e9);
            result = String.Join(' '
                            , result
                            , nanoseconds.ToString().PadLeft(32, ' ')
                            , "ns\n");
            return (nanoseconds, result);
        }
    }
}
