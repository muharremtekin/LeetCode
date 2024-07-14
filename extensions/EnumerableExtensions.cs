public static class EnumerableExtensions
{
    public static string ToArrayString<T>(this IEnumerable<T> source) => $"[{string.Join(",", source)}]";
}