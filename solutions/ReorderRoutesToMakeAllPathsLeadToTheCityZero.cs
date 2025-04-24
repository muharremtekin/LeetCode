public class ReorderRoutesToMakeAllPathsLeadToTheCityZero
{
    // 1466. Reorder Routes to Make All Paths Lead to the City Zero
    // Medium
    // Topics
    // Companies
    // Hint
    // There are n cities numbered from 0 to n - 1 and n - 1 roads such that there is only one way to travel between 
    // two different cities (this network form a tree). Last year, The ministry of transport decided to orient 
    // the roads in one direction because they are too narrow.

    // Roads are represented by connections where connections[i] = [ai, bi] represents a road from city ai to city bi.

    // This year, there will be a big event in the capital (city 0), and many people want to travel to this city.

    // Your task consists of reorienting some roads such that each city can visit the city 0. Return the minimum number of edges changed.

    // It's guaranteed that each city can reach city 0 after reorder.

    // Constraints:
    // 2 <= n <= 5 * 104
    // connections.length == n - 1
    // connections[i].length == 2
    // 0 <= ai, bi <= n - 1
    // ai != bi

    // Input: n = 6, connections = [[0,1],[1,3],[2,3],[4,0],[4,5]]
    // Output: 3
    // Explanation: Change the direction of edges show in red such that each node can reach the node 0 (capital).

    // Input: n = 5, connections = [[1,0],[1,2],[3,2],[3,4]]
    // Output: 2
    // Explanation: Change the direction of edges show in red such that each node can reach the node 0 (capital).
    // Example 3:

    // Input: n = 3, connections = [[1,0],[2,0]]
    // Output: 0

    // Constraints:
    // 2 <= n <= 5 * 104
    // connections.length == n - 1
    // connections[i].length == 2
    // 0 <= ai, bi <= n - 1
    // ai != bi
    public static int MinReorder(int n, int[][] connections)
    {
        List<int>[] graph = new List<int>[n];
        for (int i = 0; i < n; i++)
        {
            graph[i] = new List<int>();
        }

        HashSet<(int, int)> roads = new HashSet<(int, int)>();

        foreach (var conn in connections)
        {
            int a = conn[0], b = conn[1];
            graph[a].Add(b);
            graph[b].Add(a);
            roads.Add((a, b));
        }

        int Dfs(int city, int parent)
        {
            int reversals = 0;
            foreach (int neighbor in graph[city])
            {
                if (neighbor != parent)
                {
                    if (roads.Contains((city, neighbor)))
                    {
                        reversals += 1;
                    }
                    reversals += Dfs(neighbor, city);
                }
            }
            return reversals;
        }
        return Dfs(0, -1);
    }

}