
public static class MaximumNumberOfVowelsInASubstringOfGivenLength
{

    /// <summary>
    /// Given a string s and an integer k, return the maximum number of vowel letters in any substring of s with length k.
    /// Vowel letters in English are 'a', 'e', 'i', 'o', and 'u'.
    /// </summary>
    /// <param name="s"></param>
    /// <param name="k"></param>
    /// <returns></returns>
    public static int Solution(string s, int k)
    {
        if (s.Length < k) return -1;

        char[] vowels = ['a', 'e', 'i', 'o', 'u'];

        // bool IsVowel(char c) => vowels.Contains(c);

        int maxVowels = 0;
        int windowVowels = 0;

        for (int i = 0; i < k; i++)
            if (IsVowel(s[i])) windowVowels++;

        maxVowels = windowVowels;
        for (int i = k; i < s.Length; i++)
        {
            if (IsVowel(s[i])) windowVowels++;
            if (IsVowel(s[i - k])) windowVowels--;

            maxVowels = Math.Max(maxVowels, windowVowels);
        }

        return maxVowels;
    }

    private static bool IsVowel(char c) => c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u';

}