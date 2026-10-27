/*
======================================================================
 BACKTRACKING  —  mock interview (interviewer is "Marco")
======================================================================

 Three problems, one pattern. Do them in order. For EACH:
   1. Clarify out loud (dupes? empty case? output order?).
   2. State the approach + Big-O BEFORE coding.
   3. Implement below — no IntelliSense, write std-lib spellings cold.
   4. Hand-trace the decision tree for a tiny input ON PAPER
      before you trust it.

 Reminder of the shape (say it, don't peek):
   choose -> explore(recurse) -> un-choose(undo).
   Snapshot into result with a COPY, not the live list.

----------------------------------------------------------------------
 PROBLEM 1 — SUBSETS
   Given an int[] nums of DISTINCT integers, return all possible
   subsets (the power set). Any order. Include [] and nums itself.
   Example: nums = [1,2,3]
     -> [], [1], [2], [3], [1,2], [1,3], [2,3], [1,2,3]

 PROBLEM 2 — PERMUTATIONS
   Given an int[] nums of DISTINCT integers, return all possible
   orderings. Example: [1,2,3] -> 6 permutations.

 PROBLEM 3 — COMBINATION SUM
   Given int[] candidates (distinct) and a target, return all unique
   combinations that sum to target. The SAME candidate may be reused
   unlimited times. Example: candidates = [2,3,6,7], target = 7
     -> [[2,2,3],[7]]
----------------------------------------------------------------------
*/
using System.Collections.Generic;

public class Backtracking
{
    // -------- PROBLEM 1 --------
    public IList<IList<int>> Subsets(int[] nums)
    {
        // your turn
        return null;
    }

    // -------- PROBLEM 2 --------
    public IList<IList<int>> Permute(int[] nums)
    {
        // your turn
        return null;
    }

    // -------- PROBLEM 3 --------
    public IList<IList<int>> CombinationSum(int[] candidates, int target)
    {
        // your turn
        return null;
    }
}
