public class PalindromicSubstrings
{
    // Given a string s, return the number of palindromic substrings in it.
    // A string is a palindrome when it reads the same backward as forward.
    // A substring is a contiguous sequence of characters within the string.

    // Example 1:
    // Input: s = "abc"
    // Output: 3
    // Explanation: Three palindromic strings: "a", "b", "c".

    // Example 2:
    // Input: s = "aaa"
    // Output: 6
    // Explanation: Six palindromic strings: "a", "a", "a", "aa", "aa", "aaa".

    // Constraints:
    // 1 <= s.length <= 1000
    // s consists of lowercase English letters.

    /// <summary>
    /// brute force
    /// O(n^3)
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static int CountSubstrings(string s)
    {

        int palindromicCount = s.Length;

        for (int k = 2; k <= s.Length; k++)
        {
            for (int i = 0; i + k <= s.Length; i++)
            {
                int start = i;
                int end = i + k - 1;  

                bool isPalindrome = true;

                while (start < end)
                {
                    if (s[start] != s[end])
                    {
                        isPalindrome = false;
                        break;  
                    }
                    start++;
                    end--;
                }

                if (isPalindrome)
                    palindromicCount++;
            }
        }

        return palindromicCount;
    }


}