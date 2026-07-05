// ============================================================
// DRILL — Course Schedule (LeetCode 207)  |  blank-file, solo
// Date: 2026-07-04
//
// There are numCourses courses labeled 0..numCourses-1.
// prerequisites[i] = [a, b]  means: take course b BEFORE course a.
// Return true if you can finish all courses, otherwise false.
//
// numCourses = 2, prerequisites = [[1,0]]        -> true
// numCourses = 2, prerequisites = [[1,0],[0,1]]  -> false
//
// Reminders to yourself (don't peek at GraphBFS.cs):
//   - adjacency list must be DIRECTED (no reverse edges)
//   - Kahn's: indegree[] -> queue of 0-indegree -> BFS -> count taken
//   - cycle exists if taken < numCourses
//   - after coding: hand-trace as a TABLE on paper with real values
// ============================================================

using System;
using System.Collections.Generic;

public class CourseScheduleDrill
{
    public bool CanFinish(int numCourses, int[][] prerequisites)
    {
        // your code here
        var indegrees = new int[numCourses];
        // create a directed adjency list
        Dictionary<int, List<int>> adjencies = new();
        foreach (var arr in prerequisites)
        {
            if (adjencies.ContainsKey(arr[1]))
                adjencies[arr[1]].Add(arr[0]);
            else
                adjencies[arr[1]] = [arr[0]];

            indegrees[arr[0]]++;
        }


        // [[1,0],[2,1],[3,1]]
        // 0 -> 1
        // 1 -> 2
        // 1 -> 3
        // circle version 
        // 4 -> 5
        // 5 -> 4

        // kahns
        int takenCourses = 0;

        var queue = new Queue<int>();

        for (int i = 0; i < numCourses; i++)
            if (indegrees[i] == 0)
                queue.Enqueue(i);

        while (queue.Count > 0)
        {
            int course = queue.Dequeue();
            takenCourses++;
            if (adjencies.ContainsKey(course))
            {
                foreach (int neighbor in adjencies[course])
                {
                    indegrees[neighbor]--;
                    if (indegrees[neighbor] == 0)
                        queue.Enqueue(neighbor);
                }
            }
        }


        return takenCourses == numCourses;
    }

    public bool CanFinish2(int numCourses, int[][] prerequisites)
    {
        var indegrees = new int[numCourses];
        Dictionary<int, List<int>> adjencies = new();
        foreach (var arr in prerequisites)
        {
            if (!adjencies.ContainsKey(arr[1]))
                adjencies[arr[1]] = new List<int>();
            adjencies[arr[1]].Add(arr[0]);
            indegrees[arr[0]]++;
        }

        int takenCourses = 0;
        var queue = new Queue<int>();

        for (int i = 0; i < numCourses; i++)          // tüm dersler üzerinde
            if (indegrees[i] == 0) queue.Enqueue(i);

        while (queue.Count > 0)
        {
            int course = queue.Dequeue();
            takenCourses++;

            if (adjencies.TryGetValue(course, out var neighbors))   // key yoksa atla
                foreach (int neighbor in neighbors)
                {
                    indegrees[neighbor]--;
                    if (indegrees[neighbor] == 0)
                        queue.Enqueue(neighbor);
                }
        }

        return takenCourses == numCourses;
    }
}
