public class MaxNumberOfKSumPairs
{
    /// <summary>
    /// Calculates the maximum number of operations that can be performed to obtain pairs of numbers in the given array that sum up to the specified target value.
    /// </summary>
    /// <param name="nums">The array of integers.</param>
    /// <param name="k">The target value.</param>
    /// <returns>The maximum number of operations.</returns>
    public static int MaxOperations(int[] nums, int k)
    {
        // algorithm of the solution:
        // 1. create a dictionary to store the count of each number
        // 2. iterate through the array
        // 3. if the number exists in the dictionary and its count is greater than 0
        // 4. decrement the count
        // 5. increment the count
        // 6. if the number doesn't exist in the dictionary, add it
        // 7. increment the count
        var dict = new Dictionary<int, int>();
        var count = 0;
        foreach (var num in nums)
        {
            // if the number exists in the dictionary and its count is greater than 0
            if (dict.ContainsKey(k - num) && dict[k - num] > 0)
            {
                // decrement the count
                dict[k - num]--;
                // increment the count
                count++;
            }
            else
            {
                // if the number doesn't exist in the dictionary, add it
                if (!dict.ContainsKey(num))
                    dict[num] = 0;
                // increment the count
                dict[num]++;
            }
        }
        return count;
    }
}