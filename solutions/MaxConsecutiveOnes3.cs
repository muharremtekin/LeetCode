// Given a binary array nums and an integer k, return the maximum number of consecutive 1's in the array if you can flip at most k 0's.

// Example 1:

// Input: nums = [1,1,1,0,0,0,1,1,1,1,0], k = 2
// Output: 6
// Explanation: [1,1,1,0,0,1,1,1,1,1,1]
// Bolded numbers were flipped from 0 to 1. The longest subarray is underlined.
public class MaxConsecutiveOnes3
{
    public static int LongestOnes(int[] nums, int k)
    {
        int zeroCount = 0;
        int maxLenght = 0;
        int left = 0;

        for (int right = 0; right < nums.Length; right++)
        {
            if (nums[right] == 0)
                zeroCount++;

            while (zeroCount > k)
            {
                if (nums[left] == 0)
                    zeroCount--;

                left++;
            }
            maxLenght = Math.Max(maxLenght, right - left + 1);
        }
        return maxLenght;
    }
}
