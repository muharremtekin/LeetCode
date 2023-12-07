using System.Text;

sealed class MergeStringsAlternately
{
    public static string MergeAlternately(string word1, string word2)
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
}