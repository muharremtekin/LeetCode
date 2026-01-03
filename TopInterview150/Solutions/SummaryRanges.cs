public sealed class SummaryRangesProblem
{
    // https://leetcode.com/problems/summary-ranges
    public static IList<string> SummaryRanges(int[] nums)
    {
        List<string> result = new();
        int n = nums.Length;
        if (n == 0) return result;

        int start = 0;

        for (int i = 0; i < n; i++)
        {
            if (i == n - 1 || nums[i] + 1 != nums[i + 1])
            {
                result.Add(start == i
                    ? nums[start].ToString()
                    : string.Concat(nums[start], "->", nums[i]));

                start = i + 1;
            }
        }

        return result;
    }
}