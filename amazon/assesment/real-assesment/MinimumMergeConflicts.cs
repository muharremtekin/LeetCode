using System;

// Minimum Merge Conflicts
//
// Problem
// Two source-control branches must be merged into one final branch.
// You are given two strings:
//
//   primary
//   secondary
//
// Each character represents one commit's priority.
//
// Priority Rule
// Lower alphabetical characters have higher priority:
//
//   'a' has the highest priority
//   'b' has lower priority than 'a'
//   ...
//   'z' has the lowest priority
//
// Valid Merge
// A merge is valid if it preserves the original order of commits inside each
// branch.
//
// Example:
// If primary = "abc", then every valid merged string must keep:
//
//   a before b
//   b before c
//
// The same rule applies to secondary.
//
// Conflict Definition
// In the final merged string, a conflict occurs when a lower-priority commit
// appears before a higher-priority commit.
//
// In character terms, for any pair of positions i < j:
//
//   if merged[i] > merged[j], this pair creates 1 conflict.
//
// So conflicts are exactly inversions in the merged string.
//
// Task
// Find the minimum possible number of conflicts across all valid merges of
// primary and secondary.
//
// Function Description
// Complete the function:
//
//   public static int getMinimumConflicts(string primary, string secondary)
//
// Parameters
//   string primary:
//     The commit sequence of the primary branch.
//
//   string secondary:
//     The commit sequence of the secondary branch.
//
// Returns
//   int:
//     The minimum number of conflicts after a valid merge.
//
// Constraints
//   1 <= primary.Length, secondary.Length <= 1000
//   primary and secondary contain only lowercase English letters.
//
// Example
//   primary = "zc"
//   secondary = "d"
//
// Possible valid merges:
//
//   "zcd"
//   "zdc"
//   "dzc"
//
// Conflict counts:
//
//   "zcd":
//     z > c
//     z > d
//     total = 2
//
//   "zdc":
//     z > d
//     z > c
//     d > c
//     total = 3
//
//   "dzc":
//     d > c
//     z > c
//     total = 2
//
// Minimum possible conflicts = 2
//
// Key Idea
// This is a minimum-inversion, order-preserving merge problem.
// A typical solution uses dynamic programming over the two string indices.
// ─────────────────────────────────────────────────────────────────────────────
// SOLUTION WALKTHROUGH (the way you'd narrate it live)
//
// 1) CLARIFY
//    - A "valid merge" = an interleaving of the two strings that keeps each
//      branch's internal order. (Classic "interleaving / shuffle" structure.)
//    - "Conflicts" = inversions: pairs (i < j) with merged[i] > merged[j].
//
// 2) KEY INSIGHT — split inversions into two independent buckets:
//      (a) INTRA inversions: both chars come from the SAME branch.
//          These are FIXED — a valid merge never reorders within a branch,
//          so we can never change them. Just count them once and add at the end.
//      (b) CROSS inversions: one char from primary, one from secondary.
//          These are the ONLY thing our merge decisions affect. Minimize these.
//
// 3) DP over the two indices (i, j) = how many chars of each branch are LEFT.
//      dp[i][j] = min CROSS inversions to merge primary[i..] and secondary[j..].
//    At each step we decide which branch contributes the NEXT (front) character:
//      - Place primary[i] first: it sits before every remaining secondary char,
//        so it makes a cross-inversion with each secondary[j..] that is SMALLER
//        than it  →  cost = (#secondary[j..] < primary[i]) + dp[i+1][j]
//      - Place secondary[j] first: symmetric
//        cost = (#primary[i..] < secondary[j]) + dp[i][j+1]
//      dp[i][j] = min(the two).
//    Base case: one branch empty ⇒ no cross inversions left ⇒ 0.
//
// 4) ANSWER = dp[0][0] + intraInversions(primary) + intraInversions(secondary)
//
// 5) COMPLEXITY
//    - The "# remaining chars smaller than c" lookups are precomputed as suffix
//      counts per letter ⇒ O(1) each.
//    - Time:  O(n*m)  (+ O(26*(n+m)) precompute).  n,m ≤ 1000 ⇒ ~1e6, fast.
//    - Space: O(n*m) for the dp table.
// ─────────────────────────────────────────────────────────────────────────────
class MinimumMergeConflicts
{
    public static int getMinimumConflicts(string primary, string secondary)
    {
        int n = primary.Length;
        int m = secondary.Length;

        // Suffix counts per letter:
        //   secLess[c][j] = how many chars in secondary[j..) are strictly < letter c
        //   priLess[c][i] = how many chars in primary[i..)  are strictly < letter c
        // Built once so each DP transition is O(1).
        int[][] secLess = BuildSuffixLessCounts(secondary);
        int[][] priLess = BuildSuffixLessCounts(primary);

        // dp[i][j] = min cross inversions merging primary[i..] and secondary[j..].
        // Extra row/col (n, m) act as the empty-branch base cases (all zero).
        int[,] dp = new int[n + 1, m + 1];

        // Fill bottom-up: i and j both go from the end toward 0 because dp[i][j]
        // depends on dp[i+1][j] and dp[i][j+1].
        for (int i = n; i >= 0; i--)
        {
            for (int j = m; j >= 0; j--)
            {
                if (i == n || j == m)
                {
                    dp[i, j] = 0; // a branch is exhausted ⇒ no cross inversions remain
                    continue;
                }

                int pc = primary[i] - 'a';
                int sc = secondary[j] - 'a';

                // Put primary[i] in front: it precedes secondary[j..]; every smaller
                // remaining secondary char becomes an inversion with it.
                int placePrimary = secLess[pc][j] + dp[i + 1, j];

                // Symmetric: put secondary[j] in front.
                int placeSecondary = priLess[sc][i] + dp[i, j + 1];

                dp[i, j] = Math.Min(placePrimary, placeSecondary);
            }
        }

        return dp[0, 0] + CountIntraInversions(primary) + CountIntraInversions(secondary);
    }

    // less[c][k] = number of chars in s[k..) strictly less than the letter (c + 'a').
    private static int[][] BuildSuffixLessCounts(string s)
    {
        int len = s.Length;
        int[][] less = new int[26][];
        for (int c = 0; c < 26; c++)
        {
            less[c] = new int[len + 1];      // less[c][len] = 0 (empty suffix)
            for (int k = len - 1; k >= 0; k--)
            {
                int ch = s[k] - 'a';
                less[c][k] = less[c][k + 1] + (ch < c ? 1 : 0);
            }
        }
        return less;
    }

    // Inversions inside a single string (fixed; unaffected by the merge).
    // For each char, add how many already-seen chars are greater than it.
    private static int CountIntraInversions(string s)
    {
        int inv = 0;
        int[] freq = new int[26];
        foreach (char ch in s)
        {
            int c = ch - 'a';
            for (int greater = c + 1; greater < 26; greater++)
                inv += freq[greater];
            freq[c]++;
        }
        return inv;
    }

    // Quick sanity check against the prompt's example (expected: 2).
    static void Main()
    {
        Console.WriteLine(getMinimumConflicts("zc", "d"));    // 2
        Console.WriteLine(getMinimumConflicts("abc", "abc")); // 0 (already sorted-friendly)
        Console.WriteLine(getMinimumConflicts("ba", "a"));    // 1
    }
}