public class IncreasingTripletSubsequence
{
    // wrong case 1
    // [6,7,1,2]
    // Output
    // true
    // Expected
    // false

    /// <summary>
    /// time complexity: O(n)
    /// space complexity O(1)
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public static bool Solution(int[] nums)
    {

        if (nums.Length < 3)
            return false;

        int small = int.MaxValue;
        int big = int.MaxValue;

        foreach (int num in nums)
        {
            if (num <= small)
                small = num;
            else if (num <= big)
                big = num;
            else
                return true;
        }

        return false;
    }
}