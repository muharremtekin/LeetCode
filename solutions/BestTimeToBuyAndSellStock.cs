
// 121. Best Time to Buy and Sell Stock

// You are given an array prices where prices[i] is the price of a given stock on the ith day.
// You want to maximize your profit by choosing a single day to buy one stock and choosing a different day in the future to sell that stock.
// Return the maximum profit you can achieve from this transaction. If you cannot achieve any profit, return 0.


// Example 1:
// Input: prices = [7,1,5,3,6,4]
// Output: 5
// Explanation: Buy on day 2 (price = 1) and sell on day 5 (price = 6), profit = 6-1 = 5.
// Note that buying on day 2 and selling on day 1 is not allowed because you must buy before you sell.

// Example 2:
// Input: prices = [7,6,4,3,1]
// Output: 0
// Explanation: In this case, no transactions are done and the max profit = 0.

// Constraints:
// 1 <= prices.length <= 105
// 0 <= prices[i] <= 104
public class BestTimeToBuyAndSellStock
{
    
    /// <summary>
    /// Calculates the maximum profit that can be achieved from buying and selling stock on different days.
    /// </summary>
    /// <param name="prices">An array where each element represents the stock price on a given day.</param>
    /// <returns>The maximum profit that can be achieved. If no profit is possible, returns 0.</returns>
    public static int MaxProfit(int[] prices)
    {
        int maxProfit = 0;

        for (int i = 0; i < prices.Length; i++)
            for (int j = i + 1; j < prices.Length; j++)
                if (prices[j] - prices[i] > maxProfit) maxProfit = prices[j] - prices[i];

        return maxProfit;
    }
}