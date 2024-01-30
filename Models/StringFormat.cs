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
            string result = "";
            string str = "";
            result = String.Format("{0}\n", this.GetType().ToString().Split('.')[2]);
            for (int i = 0; i < size; i++)
                str = String.Format("{0} {1} {2} {3} {4}\n", str, i, name[0], name[1], name[2]);
            result = String.Format("{0} {1} ms\n", result, stopwatch.ElapsedMilliseconds.ToString().PadLeft(11, ' '));
            stopwatch.Stop();
            return (stopwatch.ElapsedMilliseconds, result);
        }
    }
}
