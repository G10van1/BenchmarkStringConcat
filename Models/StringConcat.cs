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
            string result = "";
            string str = "";
            result = String.Concat(this.GetType().ToString().Split('.')[2], "\n ");
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
            result = String.Concat(result
                            , stopwatch.ElapsedMilliseconds.ToString().PadLeft(11, ' ')
                            , " ms\n");
            stopwatch.Stop();
            return (stopwatch.ElapsedMilliseconds, result);
        }
    }
}
