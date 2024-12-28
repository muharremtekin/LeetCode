public class ValidPalindrome
{
    private static string ReplaceAllNonAlphanumerics(string s)
    {
        char[] chars = new char[s.Length];
        int length = 0;
        
        for (int i = 0; i < s.Length; i++)
        {
            char c = char.ToLower(s[i]);
            if (char.IsLetterOrDigit(c))
            {
                chars[length++] = c;
            }
        }
        
        return new string(chars, 0, length);
    }
    public static bool IsPalindrome(string s)
    {
        if (s.Length < 2) return true;

        s = ReplaceAllNonAlphanumerics(s);

        int right = s.Length - 1;

        for (int left = 0; left < s.Length / 2; left++)
        {
            if (s[left] != s[right])
                return false;
            else
                right--;
        }

        return true;
    }

    public static bool IsPalindromeOptimizedVersion(string s)
    {
        if (s.Length < 2) return true;

        int left = 0;
        int right = s.Length - 1;

        while (left < right)
        {
            while (left < right && !char.IsLetterOrDigit(s[left]))
                left++;
            while (left < right && !char.IsLetterOrDigit(s[right]))
                right--;

            if (char.ToLower(s[left]) != char.ToLower(s[right]))
                return false;

            left++;
            right--;
        }

        return true;
    }
}