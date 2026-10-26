// ============================================================
// COLD REPEAT — Longest Substring Without Repeating Characters (LeetCode 3)  |  2026-10-26
// ⚠️ DO NOT open LongestSubarrayWithoutRepeatingCharracter.cs. Write from scratch.
// Timer: 25 min. Out loud, in English. Run the 5-step protocol first
// (clarify → tiny example → brute force idea → pattern/trigger → code → trace).
//
// Given a string s, return the length of the longest substring
// without repeating characters.
// 0 <= s.length <= 5 * 10^4
// s consists of English letters, digits, symbols and spaces.
//
//   "abcabcbb" -> 3   ("abc")
//   "bbbbb"    -> 1   ("b")
//   "pwwkew"   -> 3   ("wke"; "pwke" is a subsequence, not a substring)
//   ""         -> 0
//   "abba"     -> 2   (trace this one: the left pointer must never move backwards)
//
// Run: Console.WriteLine(new LongestSubstringColdRepeat().LengthOfLongestSubstring("abcabcbb"));
// ============================================================

using System;
using System.Collections.Generic;

public class LongestSubstringColdRepeat
{
    // hmm it sounds like a hashset problem. i need to return longest characters 
    // that added to hashset. if couldnt added to the hashset, 
    // compare current count to longest count i think
    //
    // TOMORROW (2026-10-27), start here before coding:
    //   1. Trace "dvdf" (expected 3, "vdf") with the idea above.
    //      When the 2nd 'd' fails to add, what exactly happens to the set?
    //   2. Say the brute force + its complexity out loud (skipped today).
    public int LengthOfLongestSubstring(string s)
    {
        // your code here (delete the throw)
        throw new NotImplementedException();
    }
}
