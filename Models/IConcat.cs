namespace BenchmarkStringConcat.Models
{
    internal interface IConcat
    {
        (long, string) Concat(int size, string[] name);
    }
}
