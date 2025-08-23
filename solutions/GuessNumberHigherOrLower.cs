
public class GuessNumberHigherOrLower
{
    public int GuessNumber(int n)
    {
        int sol = 1;
        int sag = n;

        while (sol <= sag)
        {
            int mid = sol + (sag - sol) / 2;

            int sonuc = guess(mid);

            if (sonuc == 0) return mid;
            else if (sonuc == -1) sag = mid - 1;
            else sol = mid + 1;
        }
        return -1;

    }

    private int guess(int mid)
    {
        return -1;
    }
}