public class MaximumSubarray
{
    // https://leetcode.com/problems/maximum-subarray/description/
    // Kadane's algorithm - O(n) time, O(1) space
    public int MaxSubArray(int[] nums)
    {
        var currentSum = nums[0];
        var maxSum = nums[0];

        for (var i = 1; i < nums.Length; i++)
        {
            currentSum = Math.Max(nums[i], currentSum + nums[i]);
            maxSum = Math.Max(maxSum, currentSum);
        }

        return maxSum;
    }

    // Divide and Conquer - O(n log n) time, O(log n) recursion stack space
    public int MaxSubArrayDivideAndConquer(int[] nums)
    {
        return FindMaxSubArray(nums, 0, nums.Length - 1);
    }

    private static int FindMaxSubArray(int[] nums, int left, int right)
    {
        if (left == right)
        {
            return nums[left];
        }

        var middle = left + (right - left) / 2;

        var leftMax = FindMaxSubArray(nums, left, middle);
        var rightMax = FindMaxSubArray(nums, middle + 1, right);
        var crossingMax = FindMaxCrossingSubArray(nums, left, middle, right);

        return Math.Max(Math.Max(leftMax, rightMax), crossingMax);
    }

    private static int FindMaxCrossingSubArray(int[] nums, int left, int middle, int right)
    {
        var sum = 0;
        var leftSum = int.MinValue;

        for (var i = middle; i >= left; i--)
        {
            sum += nums[i];
            leftSum = Math.Max(leftSum, sum);
        }

        sum = 0;
        var rightSum = int.MinValue;

        for (var i = middle + 1; i <= right; i++)
        {
            sum += nums[i];
            rightSum = Math.Max(rightSum, sum);
        }

        return leftSum + rightSum;
    }
}
