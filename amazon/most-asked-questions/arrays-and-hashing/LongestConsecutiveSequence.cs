public class LongestConsecutiveSequence
{
    // https://leetcode.com/problems/longest-consecutive-sequence/
    public int LongestConsecutive(int[] nums)
    {
        HashSet<int> set = new(nums);
        int longest = 0;

        foreach (int num in set)
        {
            if (set.Contains(num - 1)) continue;

            // Input: nums = [0,3,7,2,5,8,4,6,1]
            // Output: 9

            int current = num;
            int length = 1;
            while (set.Contains(current + 1))
            {
                current++;
                length++;
            }

            longest = Math.Max(longest, length);
        }

        return longest;
    }
}