public class MinimumSizeSubarraySum
{
    // https://leetcode.com/problems/minimum-size-subarray-sum/
    public static int MinSubArrayLen(int target, int[] nums)
    {
        // store current lenght
        // store minimum lenght (it's result)

        // traverse nums arr with a loop
        // - check is it equal to target if it is return just one (1)
        // decide is it lower than min lenght
        var minLength = int.MaxValue;
        var currentSum = 0;
        var left = 0;

        for (var right = 0; right < nums.Length; right++)
        {
            currentSum += nums[right];

            while (currentSum >= target)
            {
                minLength = Math.Min(minLength, right - left + 1);
                currentSum -= nums[left];
                left++;
            }
        }

        return minLength == int.MaxValue ? 0 : minLength;

    }
}