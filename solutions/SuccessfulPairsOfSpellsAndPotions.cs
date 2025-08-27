public class SuccessfulPairsOfSpellsAndPotions
{
    // https://leetcode.com/problems/successful-pairs-of-spells-and-potions/
    public int[] SuccessfulPairs(int[] spells, int[] potions, long success)
    {
        Array.Sort(potions);
        int n = spells.Length, m = potions.Length;
        int[] result = new int[n];

        for (int i = 0; i < n; i++)
        {
            long need = (success + spells[i] - 1L) / spells[i];

            if (need <= potions[0]) { result[i] = m; continue; }
            if (need > potions[m - 1]) { result[i] = 0; continue; }

            int idx = LowerBound(potions, need);
            result[i] = m - idx;
        }
        return result;
    }

    private int LowerBound(int[] arr, long target)
    {
        int l = 0, r = arr.Length;
        while (l < r)
        {
            int mid = l + ((r - l) >> 1);
            if ((long)arr[mid] < target) l = mid + 1;
            else r = mid;
        }
        return l;
    }
}