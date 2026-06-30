/*
======================================================================
 COURSE SCHEDULE  —  Graph + BFS (topological sort / cycle detection)
======================================================================

PROBLEM
  There are `numCourses` courses labeled 0 .. numCourses-1.
  prerequisites[i] = [a, b] means "to take course a, you must FIRST
  finish course b"   (so the directed edge is  b -> a, "b unlocks a").
  Return true if you can finish ALL courses, false otherwise.

  Finishing all courses is possible  <=>  the directed graph has NO cycle.

CORE IDEA  (Kahn's algorithm — topological sort via BFS)
  - Take any course that currently has NO remaining prerequisites
    (indegree == 0). Completing it "unlocks" its dependents: decrement
    their indegree; any that drop to 0 become takeable next.
  - Count how many courses you manage to take. If you can take ALL of
    them, there was no cycle -> true. If a cycle exists, those courses
    never reach indegree 0, so they're never taken -> count falls short
    -> false. You never hunt for the cycle explicitly; the count reveals it.

THE THREE STRUCTURES
  - adj : List<int>[]   adjacency list, adj[b] = courses b unlocks.
  - indegree : int[]    indegree[c] = # prerequisites course c still has.
  - queue : Queue<int>  courses ready to take right now (indegree 0).

MENTAL MODEL  (this IS how you plan a real semester)
  - indegree[c] = "how many prerequisites does course c still have left?"
        indegree 0  <=>  "takeable right now" (no prereqs remaining).
    You ask the same question every semester: which courses can I take?
    -> the ones whose prereqs are all done -> indegree 0.
  - queue = the "ready to take" shelf. Pop a course = "finish it". When a
    course is finished, every course it unlocks loses ONE prerequisite, so
    decrement their indegree; any that hit 0 just became takeable -> push.
    It's a domino: each finished course pays down its dependents' "debt",
    and whoever's debt reaches 0 is processed next (BFS, layer by layer):
        layer1 {courses with no prereqs} -> layer2 {what they unlock} -> ...

WHY THE COUNTER DETECTS THE CYCLE  (the elegant part)
  Courses inside a cycle WAIT ON EACH OTHER, so their indegree never
  drops to 0 -> they never enter the queue -> they are never "taken".
        0 -> 1 -> 2 -> 0   gives indegree = [1,1,1]
        nothing starts at 0  ->  queue empty immediately  ->  taken = 0.
  So `taken` falls short by exactly the courses stuck in the cycle. You
  never search for the cycle; if taken == numCourses everything got
  scheduled (no cycle), otherwise the leftover is the cycle -> false.

DIRECTION GOTCHA (the bug we hit)
  Edges are DIRECTED. For pair [a, b]: b must come first, so the arrow
  is b -> a. Build it ONE way only: adj[b].Add(a); indegree[a]++.
  Adding the reverse arrow too makes an undirected graph, where every
  edge looks like a 2-cycle and breaks the algorithm.

COMPLEXITY
  Time : O(V + E)  -> V = numCourses, E = prerequisites.Length.
                      Build is O(E), each node enqueued/dequeued once,
                      each edge relaxed once.
  Space: O(V + E)  -> adjacency list + indegree array + queue.
======================================================================
*/
public class GraphBFS
{
    public bool CanFinish(int numCourses, int[][] prerequisites)
    {
        // 1. Build adjacency list + indegree array.
        var adj = new List<int>[numCourses];
        for (int i = 0; i < numCourses; i++)
            adj[i] = new List<int>();

        int[] indegree = new int[numCourses];

        foreach (var pair in prerequisites)
        {
            int a = pair[0];   // course a
            int b = pair[1];   // needs b first  ->  edge b -> a
            adj[b].Add(a);
            indegree[a]++;
        }

        // 2. Enqueue every course with no remaining prerequisites.
        var queue = new Queue<int>();
        for (int c = 0; c < numCourses; c++)
            if (indegree[c] == 0)
                queue.Enqueue(c);

        // 3. Take courses one by one; unlock dependents.
        int taken = 0;
        while (queue.Count > 0)
        {
            int course = queue.Dequeue();
            taken++;

            foreach (int next in adj[course])
            {
                indegree[next]--;
                if (indegree[next] == 0)
                    queue.Enqueue(next);
            }
        }

        // 4. All courses taken  <=>  no cycle.
        return taken == numCourses;
    }
}

/*
TRACE  numCourses = 4, prerequisites = [[1,0],[2,1],[3,2]]   (chain 0->1->2->3)

  Build:  adj[0]=[1] adj[1]=[2] adj[2]=[3] adj[3]=[]
          indegree = [0,1,1,1]

  Init queue: only course 0 has indegree 0  ->  queue=[0]

  step | pop | taken | neighbor: indegree-- (enqueue if 0) | queue after
  -----+-----+-------+--------------------------------------+------------
   1   |  0  |   1   | 1: 1->0  enqueue 1                   | [1]
   2   |  1  |   2   | 2: 1->0  enqueue 2                   | [2]
   3   |  2  |   3   | 3: 1->0  enqueue 3                   | [3]
   4   |  3  |   4   | (none)                               | []

  taken = 4 == numCourses  ->  TRUE

CYCLE CASE  [[1,0],[2,1],[0,2]]   (0->1->2->0)
  indegree = [1,1,1]  -> NOTHING starts at 0 -> queue empty immediately
  taken = 0 != 3  ->  FALSE
*/
