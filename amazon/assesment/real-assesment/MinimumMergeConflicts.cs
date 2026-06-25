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
class MinimumMergeConflicts
{
    public static int getMinimumConflicts(string primary, string secondary)
    {
        return 0;
    }
}