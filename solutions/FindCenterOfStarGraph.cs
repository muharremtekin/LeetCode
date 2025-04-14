public sealed class FindCenterOfStarGraph
{
    // 1791. Find Center of Star Graph
    // Easy
    // Topics
    // Companies
    // Hint
    // There is an undirected star graph consisting of n nodes labeled from 1 to n. 
    // A star graph is a graph where there is one center node and exactly n - 1 edges that 
    // connect the center node with every other node.

    // You are given a 2D integer array edges where each 
    // edges[i] = [ui, vi] indicates that there is an edge 
    // between the nodes ui and vi. Return the center of the given star graph.


    // its my first solution that comes my mind
    public static int FindCenter(int[][] edges)
    {
        int rowCount = edges.Length;
        int colCount = edges[0].Length;

        bool[,] visited = new bool[edges.Length, edges[0].Length];

        var set = new HashSet<int>();

        for (int i = 0; i < rowCount; i++)
        {
            for (int j = 0; j < colCount; j++)
            {
                var res = set.Add(edges[i][j]);
                if (!res) return edges[i][j];
            }
        }

        return 0;
    }

    // most efficient way to solve this problem i think
    // but this problem is at the beginner lvl
    public int FindCenter2(int[][] edges)
    {
        int node1 = edges[0][0];
        int node2 = edges[0][1];

        if (node1 == edges[1][0] || node1 == edges[1][1])
            return node1;
        return node2;
    }
}