/*
======================================================================
 HOUSE ROBBER  —  Dynamic programming (1D)
======================================================================

PROBLEM
  Houses in a row, each with some money: int[] nums.
  You're a robber, but you CANNOT rob two ADJACENT houses (alarms link
  neighbors). Return the maximum total money you can rob.

  Example: [2,7,9,3,1]  -> 12   (rob houses 0,2,4 = 2+9+1)
           [1,2,3,1]    -> 4    (rob houses 0,2   = 1+3)

----------------------------------------------------------------------
 YOUR TURN  (mock interview — interviewer is "Marco")
   1. Clarifying questions first (out loud).
   2. Find the recurrence: at house i, what are your 2 choices?
      State it BEFORE coding. What are the base cases?
   3. Implement below.
   4. Hand-trace with a per-iteration table (real values, not symbols).
----------------------------------------------------------------------
*/
public class DynamicProgramming
{
    public int Rob(int[] nums)
    {
        int twoBack = 0;
        int oneBack = 0;

        foreach (int money in nums)
        {
            int current = Math.Max(oneBack, twoBack + money);
            twoBack = oneBack;
            oneBack = current;
        }

        return oneBack;
        // money | twoBack oneBack (before) | current = max(oneBack, twoBack+money) | twoBack oneBack (after)
        // 
        //   2   |    0       0             | current = max(0, 0+2)  = 2             |    0       2
        //   7   |    0       2             | current = max(2, 0+7)  = 7             |    2       7
        //   9   |    2       7             | current = max(7, 2+9)  = 11            |    7       11
        //   3   |    7       11            | current = max(11, 7+3) = 11            |    11      11
        //   1   |    11      11            | current = max(11, 11+1)= 12            |    11      12
    }

    public int RobWithDpArray(int[] nums)
    {
        if (nums.Length == 0) return 0;
        if (nums.Length == 1) return nums[0];

        // dp[i] = house 0'dan house i'ye kadar kazanabilecegimiz max para.
        // Not: dp[i], i. evi kesin soyduk demek degil; sadece o noktaya kadar en iyi sonuc.
        int[] dp = new int[nums.Length];

        dp[0] = nums[0];
        dp[1] = Math.Max(nums[0], nums[1]);

        for (int i = 2; i < nums.Length; i++)
        {
            int skipCurrentHouse = dp[i - 1];
            int robCurrentHouse = dp[i - 2] + nums[i];

            dp[i] = Math.Max(skipCurrentHouse, robCurrentHouse);
        }

        return dp[nums.Length - 1];

        // nums = [2,7,9,3,1]
        //
        // i | money | skipCurrentHouse = dp[i-1] | robCurrentHouse = dp[i-2]+money | dp[i]
        // --------------------------------------------------------------------------------
        // 0 |   2   | base case                 | base case                       |   2
        // 1 |   7   | base case                 | base case                       |   7
        // 2 |   9   | dp[1] = 7                 | dp[0] + 9 = 2+9  = 11          |   11
        // 3 |   3   | dp[2] = 11                | dp[1] + 3 = 7+3  = 10          |   11
        // 4 |   1   | dp[3] = 11                | dp[2] + 1 = 11+1 = 12          |   12
        //
        // Final dp array: [2,7,11,11,12]
        // Answer: dp[4] = 12
    }
}
