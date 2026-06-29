public class LongestSubarrayWithoutRepeatingCharracter
{
    public int FindLongestSubarrayWithoutRepeatingCharracter(string s)
    {
        if (string.IsNullOrEmpty(s)) return 0;

        Dictionary<char, int> dict = new();
        int maxLenght = 0;
        int slow = 0;

        for (int fast = 0; fast < s.Length; fast++)
        {
            char current = s[fast];
            if (dict.TryGetValue(current, out int lastSeen) && lastSeen >= slow)
                slow = lastSeen + 1;

            maxLenght = Math.Max(maxLenght, fast + 1 - slow);
            dict[current] = fast;
        }

        return maxLenght;
    }
}