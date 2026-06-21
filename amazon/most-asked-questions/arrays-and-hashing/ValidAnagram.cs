using System.Text;

public class ValidAnagram
{
    public bool IsAnagram(string s, string t)
    {
        // Input: s = "anagram", t = "nagaram"
        if (s.Length != t.Length) return false;

        var dict = new Dictionary<char, int>();

        foreach (char c in s)
        {
            if (!dict.ContainsKey(c))
                dict.Add(c, 1);
            else
                dict[c]++;
        }

        foreach (char c in t)
        {
            if (!dict.ContainsKey(c) || dict[c] == 0)
                return false;

            dict[c]--;
        }

        return true;
    }

    public bool IsAnagramV2(string s, string t)
    {
        if (s.Length != t.Length) return false;

        var counts = new int[26];

        foreach (char c in s)
            counts[c - 'a']++;

        foreach (char c in t)
        {
            if (--counts[c - 'a'] < 0)
                return false;
        }

        return true;
    }

    public bool IsAnagramV3(string s, string t)
    {
        s = s.Normalize(NormalizationForm.FormC);
        t = t.Normalize(NormalizationForm.FormC);

        var counts = new Dictionary<Rune, int>();

        foreach (var rune in s.EnumerateRunes())
            counts[rune] = counts.GetValueOrDefault(rune) + 1;

        foreach (var rune in t.EnumerateRunes())
        {
            if (!counts.TryGetValue(rune, out int count))
                return false;

            if (count == 1)
                counts.Remove(rune);
            else
                counts[rune] = count - 1;
        }

        return counts.Count == 0;
    }
}
