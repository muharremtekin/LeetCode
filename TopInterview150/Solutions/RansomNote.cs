public sealed class RansomNote
{
    // https://leetcode.com/problems/ransom-note/description
    // Time: O(n + m) - n: magazine, m: ransomNote
    // Space: O(k) - k: magazine'deki unique karakter sayısı (en fazla 26)
    public bool CanConstruct(string ransomNote, string magazine)
    {
        Dictionary<char, int> dictionary = new();

        foreach (char letter in magazine)
        {
            bool result = dictionary.TryAdd(letter, 1);
            if (!result) dictionary[letter]++;
        }

        foreach (char letter in ransomNote)
        {

            if (dictionary.TryGetValue(letter, out int val) && val != 0)
            {
                dictionary[letter]--;
            }
            else return false;

        }

        return true;
    }

    // Time: O(n + m) - n: magazine, m: ransomNote
    // Space: O(1) - sabit 26 boyutlu array
    public bool CanConstructV2(string ransomNote, string magazine)
    {
        if (ransomNote.Length > magazine.Length) return false;

        int[] count = new int[26];

        foreach (char c in magazine)
            count[c - 'a']++;

        foreach (char c in ransomNote)
        {
            if (--count[c - 'a'] < 0)
                return false;
        }

        return true;
    }
}