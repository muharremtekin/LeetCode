public sealed class SummaryRangesProblem
{
    // https://leetcode.com/problems/summary-ranges
    public static IList<string> SummaryRanges(int[] nums)
    {
        List<string> result = new();
        if (nums.Length == 0) return result;

        int start = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            if (i == nums.Length - 1 || nums[i] + 1 != nums[i + 1])
            {
                if (start == i)
                    result.Add(nums[start].ToString());
                else
                    result.Add($"{nums[start]}->{nums[i]}");

                start = i + 1;
            }
        }

        return result;
    }
}