using System.Drawing;

public class SuccessfulPairsOfSpellsAndPotions
{
    /// <summary>
    /// https://leetcode.com/problems/successful-pairs-of-spells-and-potions
    /// n == spells.length
    /// m == potions.length
    /// 1 <= n, m <= 105
    /// 1 <= spells[i], potions[i] <= 105
    /// 1 <= success <= 1010
    /// </summary>
    /// <param name="spells"></param>
    /// <param name="potions"></param>
    /// <param name="success"></param>
    /// <returns></returns>
    public static int[] SuccessfulPairs(int[] spells, int[] potions, long success)
    {
        Array.Sort(potions);
        int[] result = new int[spells.Length];

        for (int i = 0; i < spells.Length; i++)
        {
            long minPotionStrength = (success + spells[i] - 1) / spells[i];

            if (minPotionStrength > int.MaxValue)
            {
                result[i] = 0;
                continue;
            }

            int searchResult = Array.BinarySearch(potions, (int)minPotionStrength);

            int firstValidIndex;
            if (searchResult >= 0)
                firstValidIndex = searchResult;
            else
                firstValidIndex = ~searchResult;


            result[i] = potions.Length - firstValidIndex;
        }

        return result;
    }
}