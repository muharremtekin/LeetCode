sealed class GreatestCommonDivisorOfStrings
{
    public static string Solution(string str1, string str2)
    {
        if (!(str1 + str2).Equals(str2 + str1))
            return "";

        int gdcLen = Gdc(str1.Length, str2.Length);
        return str1.Substring(0, gdcLen);
    }

    private static int Gdc(int x, int y) => y == 0 ? x : Gdc(y, x % y);
}