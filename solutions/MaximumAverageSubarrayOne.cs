public static class MaximumAverageSubarrayOne
{
    public static double Solution(int[] nums, int k)
    {
        if (nums.Length < k) return -1;

        double maxSum = 0;
        for (int i = 0; i < k; i++)
            maxSum += nums[i];

        double windowSum = maxSum;
        for (int i = k; i < nums.Length; i++)
        {
            windowSum += nums[i] - nums[i - k];
            maxSum = Math.Max(maxSum, windowSum);
        }

        return maxSum / k;
    }
}