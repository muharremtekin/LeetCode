public class LongestSubstringWithoutRepeatingCharacters
{
    // https://leetcode.com/problems/longest-substring-without-repeating-characters/description/
    public static int LengthOfLongestSubstring(string s)
    {
        // Input: s = "abcabcbb"
        // Output: 3
        var set = new HashSet<char>();

        int fast = 0;
        int longest = 0;
        while (s.Length > fast)
        {

            if (set.Add(s[fast]))
            {
                fast++;
            }
            else
            {
                longest = Math.Max(longest, set.Count());
                set.Clear();
            }

        }
        return longest;
    }

    public static int LengthOfLongestSubstringV2(string s)
    {
        var chars = new HashSet<char>();
        int left = 0;
        int longest = 0;

        for (int right = 0; right < s.Length; right++)
        {
            while (chars.Contains(s[right]))
            {
                chars.Remove(s[left]);
                left++;
            }

            chars.Add(s[right]);
            longest = Math.Max(longest, right - left + 1);
        }

        return longest;
    }
}