
public sealed class LongestCommonPrefixProblem
{
    // url: https://leetcode.com/problems/longest-common-prefix
    public static string LongestCommonPrefix(string[] strs)
    {
        string commonPrefix = strs[0];
        for (int strIndex = 1; strIndex < strs.Length; strIndex++)
        {
            string prefix = FindPrefix(commonPrefix, strs[strIndex]);

            if (string.IsNullOrWhiteSpace(prefix))
            {
                commonPrefix = prefix;
                break;
            }
            else
                commonPrefix = prefix;
        }

        return commonPrefix;
    }

    private static string FindPrefix(string commonPrefix, string str)
    {
        int n = Math.Min(commonPrefix.Length, str.Length); int index = 0;
        for (; index < n; index++)
        {
            if (commonPrefix[index] != str[index]) break;
        }
        char[] strArray = new char[index];
        Array.Copy(commonPrefix.ToCharArray(), strArray, index);
        return commonPrefix[..index];
    }
}