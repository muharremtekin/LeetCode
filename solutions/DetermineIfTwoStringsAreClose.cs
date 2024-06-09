using System.Collections.Generic;
using System.Linq;

public class DetermineIfTwoStringsAreClose
{
    public static bool Solution(string word1, string word2)
    {
        // iki kelimenin uzunlukları eşit olmalı
        // ikisini de hashset'e çevirince kalan karakterler aynıysa true
        // karakterlerin sayısı da eşit olmalı
        // örneğin birinde 2 tane a diğerinde 1 tane a varsa false dönmeli

        if (word1.Length == word2.Length)
        {

            HashSet<char> hashset1 = [.. word1];

            HashSet<char> hashset2 = [.. word2];

            if (hashset1.SetEquals(hashset2))
            {
                Dictionary<char, int> word1Dict = word1.OrderBy(b => b).GroupBy(c => c).ToDictionary(g => g.Key, g => g.Count());

                Dictionary<char, int> word2Dict = word2.OrderBy(b => b).GroupBy(c => c).ToDictionary(g => g.Key, g => g.Count());

                var values1 = word1Dict.Values.OrderBy(a => a);
                var values2 = word2Dict.Values.OrderBy(a => a);
                if (values1.SequenceEqual(values2))
                    return true;
            }

        }
        return false;
    }

    public static bool Solution2(string word1, string word2)
    {
                if (word1.Length != word2.Length)
        {
            return false;
        }

        var freq1 = new Dictionary<char, int>();
        var freq2 = new Dictionary<char, int>();

        var set1 = new HashSet<char>();
        var set2 = new HashSet<char>();

        for (int i = 0; i < word1.Length; i++)
        {
            char c1 = word1[i];
            char c2 = word2[i];

            if (freq1.ContainsKey(c1))
                freq1[c1]++;
            else
                freq1[c1] = 1;

            if (freq2.ContainsKey(c2))
                freq2[c2]++;
            else
                freq2[c2] = 1;

            set1.Add(c1);
            set2.Add(c2);
        }

        if (!set1.SetEquals(set2))
        {
            return false;
        }

        var values1 = freq1.Values.OrderBy(v => v).ToArray();
        var values2 = freq2.Values.OrderBy(v => v).ToArray();
        
        return values1.SequenceEqual(values2);
    }
}