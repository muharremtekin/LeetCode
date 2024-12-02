
// 200. Number of Islands
// Medium
// Topics
// Companies
// Given an m x n 2D binary grid grid which represents a map of '1's (land) and '0's (water), return the number of islands.

// An island is surrounded by water and is formed by connecting adjacent lands horizontally or vertically. You may assume all four edges of the grid are all surrounded by water.



// Example 1:

// Input: grid = [
//   ["1","1","1","1","0"],
//   ["1","1","0","1","0"],
//   ["1","1","0","0","0"],
//   ["0","0","0","0","0"]
// ]
// Output: 1
// Example 2:

// Input: grid = [
//   ["1","1","0","0","0"],
//   ["1","1","0","0","0"],
//   ["0","0","1","0","0"],
//   ["0","0","0","1","1"]
// ]
// Output: 3


// Constraints:

// m == grid.length
// n == grid[i].length
// 1 <= m, n <= 300
// grid[i][j] is '0' or '1'.
public static class NumberOfIslands
{
    static int[] rowDir = { -1, 1, 0, 0 };
    static int[] colDir = { 0, 0, -1, 1 };
    public static int NumIslands(char[][] grid)
    {
        int n = grid.Length;
        int m = grid[0].Length;
        bool[,] visited = new bool[n, m];
        DFS(grid, visited, n, m, 0, 0);

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                Console.Write(visited[i, j] ? "True " : "False ");
            }
            Console.WriteLine();
        }

        return 0;
    }
    static void DFS(char[][] grid, bool[,] visited, int n, int m, int x, int y)
    {
        // Sınır kontrolü
        if (x < 0 || x >= n || y < 0 || y >= m)
            return;
        // Ziyaret edilmiş veya değeri 0 ise
        if (visited[x, y] || grid[x][y] == '1')
            return;

        // Ziyaret edildi olarak işaretle
        visited[x, y] = true;

        // 4 yönlü komşuları ziyaret et
        DFS(grid, visited, n, m, x - 1, y); // Yukarı
        DFS(grid, visited, n, m, x + 1, y); // Aşağı
        DFS(grid, visited, n, m, x, y - 1); // Sol
        DFS(grid, visited, n, m, x, y + 1); // Sağ
    }
}