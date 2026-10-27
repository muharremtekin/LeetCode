/*
======================================================================
 SEARCH IN ROTATED SORTED ARRAY  —  Binary search (modified)
======================================================================

PROBLEM
  An ascending sorted array of DISTINCT integers was rotated at some
  unknown pivot. E.g. [0,1,2,4,5,6,7] rotated -> [4,5,6,7,0,1,2].
  Given the rotated array `nums` and a `target`, return the INDEX of
  target, or -1 if it's not present.

  Must run in O(log n)  (so: binary search, not a linear scan).

  Example: nums = [4,5,6,7,0,1,2], target = 0  ->  4
           nums = [4,5,6,7,0,1,2], target = 3  -> -1

----------------------------------------------------------------------
 YOUR TURN  (mock interview — interviewer is "Marco")
   1. Clarifying questions first (out loud).
   2. State the approach + complexity BEFORE coding.
   3. Implement below.
   4. Hand-trace iteration 1 with REAL values before you say "done".
      (This is the step you keep skipping — don't. 🙂)
----------------------------------------------------------------------
*/
public class BinarySearch
{
    public int Search(int[] nums, int target)
    {
        int left = 0;
        int right = nums.Length - 1;


        while (left <= right)
        {
            int mid = (left + right) / 2;

            if (nums[mid] == target) return mid;

            if (nums[left] <= nums[mid])
            {
                if (target > nums[mid] || target < nums[left])
                    left = mid + 1;
                else
                    right = mid - 1;
            }
            else
            {
                if (target < nums[mid] || target > nums[right])
                    right = mid - 1;
                else
                    left = mid + 1;
            }
        }
        return -1;
    }
}
