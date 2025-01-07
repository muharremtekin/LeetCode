// Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
// You may assume that each input would have exactly one solution, and you may not use the same element twice.
// You can return the answer in any order.

// Example 1:
// Input: nums = [2,7,11,15], target = 9
// Output: [0,1]
// Explanation: Because nums[0] + nums[1] == 9, we return [0, 1].

// Example 2:
// Input: nums = [3,2,4], target = 6
// Output: [1,2]

// Example 3:
// Input: nums = [3,3], target = 6
// Output: [0,1]

// Constraints:
// 2 <= nums.length <= 104
// -109 <= nums[i] <= 109
// -109 <= target <= 109
// Only one valid answer exists.


// Follow-up: Can you come up with an algorithm that is less than O(n2) time complexity?

public class TwoSum
{
    // O(n^2)
    public static int[] FindTwoSum(int[] nums, int target)
    {
        if (nums.Length < 3)
            return [0, 1];

        int right = 1;

        for (int left = 0; left < nums.Length; left++)
        {
            for (int rigth = right; rigth < nums.Length; rigth++)
            {
                if (nums[left] + nums[rigth] == target)
                    return [left, rigth];
            }
            right++;
        }

        return [];
    }

    public static int[] FindTwoSumOn(int[] nums, int target)
    {
        if (nums.Length < 3)
            return [0, 1];

        

        return [];
    }
}