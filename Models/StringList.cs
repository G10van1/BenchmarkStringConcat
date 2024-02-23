using System.Diagnostics;

namespace BenchmarkStringConcat.Models
{
    internal class StringList : IConcat
    {
        public (long, string) Concat(int size, string[] name)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();            
            string result = this.GetType().ToString().Split('.')[2] + "\n ";
            List<String> list = new List<String>();
            for (int i = 0; i < size; i++) {
                list.Add(i.ToString());
                list.Add(name[0]);
                list.Add(name[1]);
                list.Add(name[2]);
                list.Add("\n");
            }
            string str = string.Join(' ', list);
            stopwatch.Stop();
            long nanoseconds = (long)Math.Round(((double)stopwatch.ElapsedTicks / Stopwatch.Frequency) * 1e9);
            result += nanoseconds.ToString().PadLeft(32, ' ') +" ns\n";
            return (nanoseconds, result);
        }
    }
}
