// ============================================================
// DRILL — Subsets (LeetCode 78)  |  blank-file, solo
// Date: 2026-07-04
//
// PROBLEM:
// Given an integer array `nums` of UNIQUE elements, return all possible
// subsets (the power set).
//
// The solution set MUST NOT contain duplicate subsets. Return the solution
// in any order.
//
// Example 1:
//   Input:  nums = [1,2,3]
//   Output: [[],[1],[2],[3],[1,2],[1,3],[2,3],[1,2,3]]     (2^3 = 8 subsets)
//
// Example 2:
//   Input:  nums = [0]
//   Output: [[],[0]]
//
// Constraints:
//   - 1 <= nums.length <= 10
//   - -10 <= nums[i] <= 10
//   - All the numbers of nums are UNIQUE.
//
// Reminders to yourself (don't peek at Backtracking.cs):
//   - model: choose -> explore -> un-choose (DFS over a decision tree)
//   - combinations use a `start` index; recurse with i+1 (not i)
//   - watch the 3 classic slips:
//       (1) add a COPY: new List<int>(path)  (else you store a ref that gets mutated -> empty)
//       (2) don't forget the UN-CHOOSE (path.RemoveAt) or state leaks to siblings
//       (3) i vs i+1 in the recursive call
//   - after coding: hand-trace the decision tree for [1,2] on paper
// ============================================================

public class SubsetsDrill
{
    public IList<IList<int>> Subsets(int[] nums)
    {
        // your code here
        var result = new List<IList<int>>();

        Backtrack(0, [], result);

        return result;


        void Backtrack(int start, List<int> path, IList<IList<int>> result)
        {
            result.Add([.. path]);
            for (int i = start; i < nums.Length; i++)
            {
                path.Add(nums[i]);
                Backtrack(i + 1, path, result);
                path.RemoveAt(path.Count - 1);
            }

        }

    }
}
