using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BenchmarkStringConcat.Models
{
    internal class StringFormat : IConcat
    {
        public (long, string) Concat(int size, string[] name)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            string result = String.Format("{0}\n", this.GetType().ToString().Split('.')[2]);
            string str = "";
            for (int i = 0; i < size; i++)
                str = String.Format("{0}{1} {2} {3} {4}\n", str, i, name[0], name[1], name[2]);
            stopwatch.Stop();
            long nanoseconds = (long)Math.Round(((double)stopwatch.ElapsedTicks / Stopwatch.Frequency) * 1e9);
            result = String.Format("{0} {1} ns\n", result, nanoseconds.ToString().PadLeft(32, ' '));
            return (nanoseconds, result);
        }
    }
}
