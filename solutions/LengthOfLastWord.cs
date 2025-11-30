namespace LengthOfLastWord;

public class LengthOfLastWordPromblem
{
    public static int LengthOfLastWord(string s)
    {
        // start to iterating at the end of the string
        // start to counting when you find the dirst non-space char
        // continue until you see a sapce char
        int n = s.Length;
        int count = 0;

        for (int i = n - 1; i >= 0; i--)
        {
            if (count is 0 && s[i] is ' ') continue;

            else if (s[i] is not ' ') count++;

            else break;
        }

        return count;
    }
}