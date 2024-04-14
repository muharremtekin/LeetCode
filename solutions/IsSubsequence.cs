
public sealed class IsSubsequence
{
    // Example 1:
    // Input: s = "abc", t = "ahbgdc"
    // Output: true

    // Example 2:
    // Input: s = "axc", t = "ahbgdc"
    // Output: false

    // Example 3:
    // Input: s = "aaaxc", t = "ahbgdc"
    // Output: false

    // Constraints:
    // 0 <= s.length <= 100
    // 0 <= t.length <= 104
    // s and t consist only of lowercase English letters.

    // "s" dizesindeki karakterler "t" dizesinde aynı sırayla varsa true yoksa false
    // not: aralarda başka sayılar olabilir.

    public static bool Solution(string s, string t)
    {
        // Kısa yol: s, t'nin içinde ise doğrudan true döndür
        if (t.Contains(s))
            return true;

        int sIndex = 0;
        int tIndex = 0;

        // sIndex, s'in uzunluğundan küçük ve tIndex, t'nin uzunluğundan küçük olduğu sürece devam et
        while (sIndex < s.Length && tIndex < t.Length)
        {
            // Karakterler eşleşiyorsa sIndex'i arttır
            if (s[sIndex] == t[tIndex])
            {
                sIndex++;
            }
            // tIndex her zaman arttırılır
            tIndex++;
        }

        // sIndex, s'in uzunluğuna eşitse alt dizedir
        return sIndex == s.Length;
    }
}

