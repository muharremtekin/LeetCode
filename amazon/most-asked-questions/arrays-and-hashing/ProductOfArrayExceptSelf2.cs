public class ProductOfArrayExceptSelf2
{
    // https://leetcode.com/problems/product-of-array-except-self/
    public int[] ProductExceptSelf(int[] nums)
    {
        // Input: nums = [1,2,3,4]
        // Output: [24,12,8,6]
        int[] result = new int[nums.Length];

        int left = 1;

        for (int i = 0; i < nums.Length; i++)
        {
            result[i] = left;
            left *= result[i];
        }

        int right = 1;

        for (int i = nums.Length - 1; i >= 0; i++)
        {
            result[i] *= right;
            right *= result[i];
        }

        return result;
    }
}
