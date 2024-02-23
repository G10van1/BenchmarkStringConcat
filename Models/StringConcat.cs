using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenchmarkStringConcat.Models
{
    internal class StringConcat : IConcat
    {
        public (long, string) Concat(int size, string[] name)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            string result = String.Concat(this.GetType().ToString().Split('.')[2], "\n ");
            string str = "";
            for (int i = 0; i < size; i++)
                str = String.Concat(str
                   , i.ToString()
                   , ' '
                   , name[0]
                   , ' '
                   , name[1]
                   , ' '
                   , name[2]
                   , '\n');

            stopwatch.Stop();
            long nanoseconds = (long)Math.Round(((double)stopwatch.ElapsedTicks / Stopwatch.Frequency) * 1e9);
            result = String.Concat(result
                            , nanoseconds.ToString().PadLeft(32, ' ')
                            , " ns\n");
            return (nanoseconds, result);
        }
    }
}
