namespace LeetCode75.solutions;

public sealed class KokoEatingBananas
{
    public int MinEatingSpeed(int[] piles, int h)
    {
        int left = 1;
        int right = 0;
        foreach (int p in piles) right = Math.Max(right, p);

        while (left < right)
        {
            int mid = left + (right - left) / 2;
            if (CanFinish(piles, h, mid))
                right = mid;
            else
                left = mid + 1;
        }
        return left;
    }
    private bool CanFinish(int[] piles, int h, int k)
    {
        long hours = 0;
        foreach (int p in piles)
        {
            hours += (p + (long)k - 1) / k;
            if (hours > h) return false;
        }
        return hours <= h;
    }
}