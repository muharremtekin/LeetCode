/*
======================================================================
 CONTAINER WITH MOST WATER  —  Two pointers
======================================================================

PROBLEM
  Given non-negative int[] height, each i is a vertical line at x=i with
  height height[i]. Pick two lines that, with the x-axis, form a
  container. Return the max water it can hold.

  Water(i, j) = min(height[i], height[j]) * (j - i)
                 ^ shorter wall caps the height   ^ width between lines

  Example: [1,8,6,2,5,4,8,3,7] -> 49   (between index 1 and 8: min(8,7)*7)

----------------------------------------------------------------------
 YOUR TURN
   1. Clarifying questions first (out loud).
   2. State the approach + complexity BEFORE coding.
   3. Implement below.
   4. Trace [1,8,6,2,5,4,8,3,7] by hand after coding (your weak spot!).
----------------------------------------------------------------------
*/
public class TwoPointers
{
  // [1,8,6,2,5,4,8,3]
  public int MaxArea(int[] height)
  {
    // TODO: your implementation

    int left = 0;
    int right = height.Length - 1;
    int maxWater = 0;

    // we need a while loop here 
    while (left < right)
    {
      // caculate max water
      maxWater = Math.Max(maxWater, Math.Min(height[left], height[right]) * (right - left));

      if (height[left] < height[right])
        left++;
      else
        right--;
    }


    return maxWater;
  }
}
