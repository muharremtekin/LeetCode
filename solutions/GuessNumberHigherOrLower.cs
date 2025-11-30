public class GuessNumberHigherOrLower
{
    private int _pickedNum = 0;
    private int guess(int num)
    {
        if (_pickedNum < 1)
        {
            Random random = new();
            _pickedNum = random.Next();
        }

        if (_pickedNum == num) return 0;
        else if (_pickedNum > num) return 1;
        else return -1;
    }


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
}