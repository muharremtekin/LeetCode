/*
======================================================================
 NUMBER OF ISLANDS  —  Grid traversal (DFS flood fill)
======================================================================

PROBLEM
  Given an m x n grid of '1' (land) and '0' (water), count the islands.
  An island = land cells connected horizontally/vertically (4 directions,
  NOT diagonal). The grid edges are surrounded by water.

CORE IDEA  (connected components)
  Each island is one "connected component" of '1's. So:
    1. Scan every cell with two nested loops.
    2. When I hit a '1' I have NOT visited yet, that's a NEW island
       -> increment the counter.
    3. Then I "sink" the WHOLE island: from that cell I flood-fill
       (DFS) to every connected '1' and flip it to '0'. This marks them
       visited so I never count the same island twice.
  Because every land cell of an island gets flipped to '0' the first time
  its island is discovered, the outer loop only ever triggers the counter
  ONCE per island.

WHY DFS (and the trade-off)
  - DFS via recursion is the shortest code: from a cell, recurse into its
    4 neighbours; the call stack does the bookkeeping.
  - Trade-off: on a huge all-land grid the recursion can go m*n deep and
    risk a stack overflow. BFS (with an explicit Queue) avoids that by
    using heap memory instead of the call stack. Both are O(m*n) time.
    For a 300x300 grid DFS is fine; mention BFS if asked about very large
    inputs.

MARKING VISITED  (an interview clarify)
  I asked "can I mutate the input?" -> yes. So I flip visited land to '0'
  in place => O(1) extra space (no separate visited[,] array). If mutation
  were NOT allowed, I'd keep a bool[,] visited at O(m*n) extra space.

THE INDEX GOTCHA (where bugs hide in 2D arrays)
  - char[,] dimensions: GetLength(0) = rows, GetLength(1) = cols.
    grid.Length is rows*cols (total cells) — do NOT use it as a bound.
  - Pick ONE coordinate convention and use it EVERYWHERE. Here:
        x = column, y = row  ->  grid is always indexed grid[y, x].
    Every read, every write, every bounds check must use the same order,
    or you get silent wrong answers / IndexOutOfRange.
  - In DFS, the bounds check must look at the CURRENT cell grid[y, x],
    and it must run BEFORE indexing, so out-of-range cells short-circuit
    and never get indexed.

COMPLEXITY
  Time : O(m * n)  -> every cell is visited a constant number of times.
  Space: O(m * n)  worst case -> recursion stack depth on an all-land grid
                                  (BFS: queue size instead).

DRY RUN
        grid:                 trace:
        1 1 0                 (0,0)='1' -> island #1, DFS sinks the whole
        1 0 0                 top-left blob: (0,0)(0,1)(1,0) -> all '0'.
        0 0 1                 Scanning continues, all '0' until (2,2)='1'
                              -> island #2, DFS sinks it. Result = 2.

----------------------------------------------------------------------
 BFS VARIANT  (same algorithm, iterative — when to reach for it)
----------------------------------------------------------------------
  Same connected-components idea; only the flood-fill changes:
  instead of recursion, use an explicit Queue<(int x,int y)>.

  WHY: DFS recursion depth can hit m*n on a pathological all-land grid
  (e.g. a 10^6-cell grid that is one giant island) and blow the call
  stack. BFS moves that frontier onto the HEAP (the queue), so it
  cannot stack-overflow. This is the answer to "what if the grid is
  huge?". Same O(m*n) time; space is O(min(m,n)) for the frontier vs
  O(m*n) worst case for the DFS stack.

  THE ONE BFS BUG TO AVOID: mark a cell visited (flip to '0') the
  MOMENT you ENQUEUE it, NOT when you dequeue it. If you only mark on
  dequeue, the same cell can be enqueued by several neighbours before
  it is processed -> duplicate work and, on big grids, a queue that
  balloons. Marking on enqueue keeps each cell in the queue once.
======================================================================
*/
public class GridTreversal
{
    public int NumberOfIslands(char[,] grid)
    {
        if (grid == null || grid.Length == 0)
            return 0;

        int numberOfIslands = 0;

        int n = grid.GetLength(0);
        int m = grid.GetLength(1);

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                if (grid[i, j] == '1')
                {
                    // dfs start point
                    DFS(grid, j, i, n, m);
                    numberOfIslands++;
                }
            }
        }

        return numberOfIslands;
    }

    void DFS(char[,] grid, int x, int y, int n, int m)
    {
        if (x < 0 || x >= m || y < 0 || y >= n || grid[y, x] != '1')
            return;

        grid[y, x] = '0';

        DFS(grid, x - 1, y, n, m);
        DFS(grid, x + 1, y, n, m);
        DFS(grid, x, y - 1, n, m);
        DFS(grid, x, y + 1, n, m);
    }

    // Identical result to NumberOfIslands, but flood-fills with BFS so a
    // giant single island cannot overflow the stack. Same x=col, y=row
    // convention -> grid is always indexed grid[y, x].
    public int NumberOfIslandsBFS(char[,] grid)
    {
        if (grid == null || grid.Length == 0)
            return 0;

        int numberOfIslands = 0;

        int n = grid.GetLength(0);
        int m = grid.GetLength(1);

        // 4-directional neighbour offsets, paired (dx, dy).
        int[] dx = { -1, 1, 0, 0 };
        int[] dy = { 0, 0, -1, 1 };

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                if (grid[i, j] != '1')
                    continue;

                numberOfIslands++;
                BFS(grid, j, i, n, m, dx, dy);
            }
        }

        return numberOfIslands;
    }

    void BFS(char[,] grid, int startX, int startY, int n, int m, int[] dx, int[] dy)
    {
        var queue = new Queue<(int x, int y)>();

        // Mark visited ON ENQUEUE (see header note), so each cell is queued once.
        grid[startY, startX] = '0';
        queue.Enqueue((startX, startY));

        while (queue.Count > 0)
        {
            var (x, y) = queue.Dequeue();

            for (int d = 0; d < 4; d++)
            {
                int nx = x + dx[d];
                int ny = y + dy[d];

                if (nx < 0 || nx >= m || ny < 0 || ny >= n || grid[ny, nx] != '1')
                    continue;

                grid[ny, nx] = '0';      // mark before enqueue
                queue.Enqueue((nx, ny));
            }
        }
    }
}