// ─────────────────────────────────────────────────────────────
// MERGE INTERVALS  (mock drill — 2026-07-05)
//
// You're given an array of intervals where intervals[i] = [start_i, end_i].
// Merge all overlapping intervals and return an array of the non-overlapping
// intervals that cover all the intervals in the input.
//
// Example:
//   Input:  [[1,3],[2,6],[8,10],[15,18]]
//   Output: [[1,6],[8,10],[15,18]]
//   ([1,3] and [2,6] overlap -> merge into [1,6])
//
// Notes from interviewer:
//   - Input is NOT guaranteed to be sorted (any order).
// ─────────────────────────────────────────────────────────────

using System;
using System.Collections.Generic;

public class MergeIntervalsDrill
{
    public int[][] Merge(int[][] intervals)
    {
        Array.Sort(intervals, (a, b) => a[0] - b[0]);
        // your solution here
        var result = new List<int[]>();

        // [[1,3],[2,6],[8,10],[15,18]]
        // take start element 
        // then compare end val to next start val
        //  if current end is bigger or equal to it
        // we merge them so
        int start = intervals[0][0]; // 8
        int end = intervals[0][1]; // 10

        for (int i = 1; i < intervals.Length; i++)
        {
            int currentStart = intervals[i][0];
            int currentEnd = intervals[i][1];


            if (end >= currentStart)
            {
                end = Math.Max(end, currentEnd);
            }
            else
            {
                result.Add([start, end]);
                start = currentStart;
                end = currentEnd;
            }

        }
        result.Add([start, end]);
        return result.ToArray();

        // i | currentStart | currentEnd | end>=currentStart? | action           | start | end |    result
        // --|--------------|------------|--------------------|---------------   |-------|-----|    --------
        // init                                                                    1       3            []
        // 1       2              6        yes (3>=2)    end = max(end,currentEnd) 1       6            []
        // 2       8            10          no (6>=8)    add to result [1,6]       set 8     set 10   [[1,6]]
        // 3       15           18          no (8>=15)   add to result [8,10]      set 15    set 18   [[1,6],[8,10]]

        // final before we return, add to result [15,18], reuslt is [[1,6],[8,10],[15,18]]
        // 
    
    }   
}
