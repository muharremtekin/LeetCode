// ============================================================
// DRILL — Coin Change (LeetCode 322)  |  blank-file, solo
// Date: 2026-07-04
//
// PROBLEM:
// You have `coins` of different denominations and an integer `amount`.
// Return the FEWEST number of coins needed to make up `amount`.
// If that amount cannot be made up, return -1.
// You have an UNLIMITED number of each coin (unbounded).
//
//   coins = [1,2,5], amount = 11  -> 3     (11 = 5 + 5 + 1)
//   coins = [2],     amount = 3   -> -1
//   coins = [1],     amount = 0   -> 0
//
// Constraints:
//   1 <= coins.length <= 12,  
//   1 <= coins[i] <= 2^31 - 1,  
//   0 <= amount <= 10^4
//
// DP MODEL (bottom-up) — think about this before coding:
//   - dp[x] = fewest coins to make amount x.
//   - Base: dp[0] = 0.
//   - Transition: dp[x] = min over each coin c (with c <= x) of dp[x - c] + 1.
//   - Init the rest of dp[] to "infinity" (use amount+1 as a sentinel — it can
//     never be a real answer, since the most coins you'd ever need is `amount`
//     coins of value 1).
//   - Answer: dp[amount] if it's < the sentinel, else -1.
//
// Slips to watch:
//   - only use coin c when c <= x (else dp[x-c] is a negative index)
//   - remember +1 (the coin you just used)
//   - final: if dp[amount] never improved (== sentinel) -> return -1
// ============================================================

using System;

public class CoinChangeDrill
{
    public int CoinChange(int[] coins, int amount)
    {
        if (amount == 0) return 0;

        var dp = new int[amount + 1];
        Array.Fill(dp, amount + 1);
        dp[0] = 0;

        for (int i = 1; i <= amount; i++)
        {
            foreach (int coin in coins)
            {
                if (coin <= i)
                    dp[i] = Math.Min(dp[i], dp[i - coin] + 1);
            }
        }

        return dp[amount] > amount ? -1 : dp[amount];

    }
}
