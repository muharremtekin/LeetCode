using System.Text;

public sealed class MergeStringsAlternately
{
    public static string Solution(string word1, string word2)
    {
        StringBuilder merged = new StringBuilder();
        int w1 = word1.Length;
        int w2 = word2.Length;
        int l = Math.Min(w1, w2);

        for (int i = 0; i < l; i++)
            merged.Append(word1[i]).Append(word2[i]);

        if (w1 == w2)
            return merged.ToString();

        else if (w1 > w2)
            return merged.Append(word1.Substring(l)).ToString();
        else
            return merged.Append(word2.Substring(l)).ToString();
    }

    public static string Solution2(string word1, string word2)
    {
        int w1 = word1.Length;
        int w2 = word2.Length;
        int l = Math.Min(w1, w2);

        Span<char> merged = new char[w1 + w2]; 
        int index = 0;

        for (int i = 0; i < l; i++)
        {
            merged[index++] = word1[i];
            merged[index++] = word2[i];
        }

        if (w1 > w2)
        {
            word1.AsSpan(l).CopyTo(merged.Slice(index));
        }
        else if (w2 > w1)
        {
            word2.AsSpan(l).CopyTo(merged.Slice(index));
        }

        return new string(merged);
    }
}