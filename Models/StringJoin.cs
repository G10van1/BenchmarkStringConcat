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

            result = String.Join(' '
                            , result
                            , stopwatch.ElapsedMilliseconds.ToString().PadLeft(11, ' ')
                            , "ms\n");

            stopwatch.Stop();
            return (stopwatch.ElapsedMilliseconds, result);
        }
    }
}
