public sealed class StringCompression
{
    public static int Solution(char[] chars)
    {
        if (chars.Length < 2)
            return chars.Length;

        List<char> compreesedList = new List<char>();
        int counter = 1;
        char previousChar = chars[0];

        for (int i = 1; i <= chars.Length; i++)
        {
            if (i == chars.Length || previousChar != chars[i])
            {
                compreesedList.Add(previousChar);
                if (counter > 1)
                {
                    foreach (char digit in counter.ToString())
                    {
                        compreesedList.Add(digit);
                    }
                }
                counter = 1;
                if (i < chars.Length)
                {
                    previousChar = chars[i];
                }
            }
            else
            {
                counter++;
            }
        }

        compreesedList.CopyTo(chars);
        return compreesedList.Count;
    }
}
