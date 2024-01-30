using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace BenchmarkStringConcat.Models
{
    internal class StringBuilder : IConcat
    {
        public (long, string) Concat(int size, string[] names)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            System.Text.StringBuilder result = new System.Text.StringBuilder();
            System.Text.StringBuilder str = new System.Text.StringBuilder();
            result.Append(this.GetType().ToString().Split('.')[2]).Append("\n ");
            for (int i = 0; i < size; i++)
            {
                str.Append(i.ToString())
                   .Append(' ')
                   .Append(names[0])
                   .Append(' ')
                   .Append(names[1])
                   .Append(' ')
                   .AppendLine(names[2]);
            }
            result.Append(stopwatch.ElapsedMilliseconds.ToString().PadLeft(11, ' '))
                  .AppendLine(" ms");
            stopwatch.Stop();
            return (stopwatch.ElapsedMilliseconds, result.ToString());
        }
    }
}
