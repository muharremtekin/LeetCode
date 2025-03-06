public class LongestSubarrayOf1sAfterDeletingOneElement
{
    public int LongestSubarray(int[] nums)
    {
        int left = 0;
        int zeros = 0;
        int maxLength = 0;

        for (int right = 0; right < nums.Length; right++)
        {
            if (nums[right] == 0)
                zeros++;

            while (zeros > 1)
            {
                if (nums[left] == 0)
                    zeros--;
                left++;
            }

            maxLength = Math.Max(maxLength, right - left);
        }

        return maxLength;
    }
}