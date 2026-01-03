
public sealed class LongestCommonPrefixProblem
{
    // url: https://leetcode.com/problems/longest-common-prefix
    public static string LongestCommonPrefix(string[] strs)
    {
        string commonPrefix = string.Empty;

        for (int strIndex = 0; strIndex < strs.Length; strIndex++)
        {
            if (strIndex is 0)
            {
                commonPrefix = strs[0];
                continue;
            }

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
        int n = commonPrefix.Length >= str.Length ? str.Length : commonPrefix.Length;
        int index = 0;
        for (; index < n; index++)
        {
            if (commonPrefix[index] != str[index]) break;
        }
        char[] strArray = new char[index];
        Array.Copy(commonPrefix.ToCharArray(), strArray, index);
        return new string(strArray);
    }
}