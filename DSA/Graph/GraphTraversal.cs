public sealed record ShortestPathResult(long Distance, List<int> Path)
{
    public bool IsReachable => Distance != long.MaxValue;
}

public static class GraphTraversal
{
    // Adjacency list: graph[node] contains the neighbors of node.
    public static List<int> DepthFirstSearchAdjacencyList(IReadOnlyList<int>[] graph, int start)
    {
        ValidateVertex(start, graph.Length);

        var visited = new bool[graph.Length];
        var traversalOrder = new List<int>();

        void Visit(int node)
        {
            visited[node] = true;
            traversalOrder.Add(node);

            foreach (var neighbor in graph[node])
            {
                if (!visited[neighbor])
                {
                    Visit(neighbor);
                }
            }
        }

        Visit(start);
        return traversalOrder;
    }

    public static List<int> BreadthFirstSearchAdjacencyList(IReadOnlyList<int>[] graph, int start)
    {
        ValidateVertex(start, graph.Length);

        var visited = new bool[graph.Length];
        var traversalOrder = new List<int>();
        var queue = new Queue<int>();

        visited[start] = true;
        queue.Enqueue(start);

        while (queue.Count > 0)
        {
            var node = queue.Dequeue();
            traversalOrder.Add(node);

            foreach (var neighbor in graph[node])
            {
                if (!visited[neighbor])
                {
                    visited[neighbor] = true;
                    queue.Enqueue(neighbor);
                }
            }
        }

        return traversalOrder;
    }

    // Adjacency matrix: a non-zero value at matrix[from, to] means there is an edge.
    public static List<int> DepthFirstSearchAdjacencyMatrix(int[,] matrix, int start)
    {
        var vertexCount = ValidateSquareMatrix(matrix);
        ValidateVertex(start, vertexCount);

        var visited = new bool[vertexCount];
        var traversalOrder = new List<int>();

        void Visit(int node)
        {
            visited[node] = true;
            traversalOrder.Add(node);

            for (var neighbor = 0; neighbor < vertexCount; neighbor++)
            {
                if (matrix[node, neighbor] != 0 && !visited[neighbor])
                {
                    Visit(neighbor);
                }
            }
        }

        Visit(start);
        return traversalOrder;
    }

    public static List<int> BreadthFirstSearchAdjacencyMatrix(int[,] matrix, int start)
    {
        var vertexCount = ValidateSquareMatrix(matrix);
        ValidateVertex(start, vertexCount);

        var visited = new bool[vertexCount];
        var traversalOrder = new List<int>();
        var queue = new Queue<int>();

        visited[start] = true;
        queue.Enqueue(start);

        while (queue.Count > 0)
        {
            var node = queue.Dequeue();
            traversalOrder.Add(node);

            for (var neighbor = 0; neighbor < vertexCount; neighbor++)
            {
                if (matrix[node, neighbor] != 0 && !visited[neighbor])
                {
                    visited[neighbor] = true;
                    queue.Enqueue(neighbor);
                }
            }
        }

        return traversalOrder;
    }

    // Edge list: each tuple represents an edge from From to To.
    public static List<int> DepthFirstSearchEdgeList(
        int vertexCount,
        IReadOnlyList<(int From, int To)> edges,
        int start,
        bool isDirected = true)
    {
        var graph = BuildAdjacencyList(vertexCount, edges, isDirected);
        return DepthFirstSearchAdjacencyList(graph, start);
    }

    public static List<int> BreadthFirstSearchEdgeList(
        int vertexCount,
        IReadOnlyList<(int From, int To)> edges,
        int start,
        bool isDirected = true)
    {
        var graph = BuildAdjacencyList(vertexCount, edges, isDirected);
        return BreadthFirstSearchAdjacencyList(graph, start);
    }

    // Returns the shortest path by edge count in an unweighted graph.
    // Returns an empty list when target cannot be reached from start.
    public static List<int> FindShortestPathBfs(IReadOnlyList<int>[] graph, int start, int target)
    {
        ValidateVertex(start, graph.Length);
        ValidateVertex(target, graph.Length);

        var visited = new bool[graph.Length];
        var parent = Enumerable.Repeat(-1, graph.Length).ToArray();
        var queue = new Queue<int>();

        visited[start] = true;
        queue.Enqueue(start);

        while (queue.Count > 0)
        {
            var node = queue.Dequeue();

            if (node == target)
            {
                return ReconstructPath(parent, start, target);
            }

            foreach (var neighbor in graph[node])
            {
                if (!visited[neighbor])
                {
                    visited[neighbor] = true;
                    parent[neighbor] = node;
                    queue.Enqueue(neighbor);
                }
            }
        }

        return new List<int>();
    }

    // Dijkstra finds the minimum-total-weight path when every edge weight is non-negative.
    // An unreachable target has Distance = long.MaxValue and an empty Path.
    public static ShortestPathResult FindShortestPathDijkstra(
        IReadOnlyList<(int To, int Weight)>[] graph,
        int start,
        int target)
    {
        ValidateWeightedGraph(graph);
        ValidateVertex(start, graph.Length);
        ValidateVertex(target, graph.Length);

        var distances = Enumerable.Repeat(long.MaxValue, graph.Length).ToArray();
        var parent = Enumerable.Repeat(-1, graph.Length).ToArray();
        var priorityQueue = new PriorityQueue<int, long>();

        distances[start] = 0;
        priorityQueue.Enqueue(start, priority: 0);

        while (priorityQueue.TryDequeue(out var node, out var distance))
        {
            // The queue can contain an older, more expensive entry for this node.
            if (distance != distances[node])
            {
                continue;
            }

            if (node == target)
            {
                return new ShortestPathResult(distance, ReconstructPath(parent, start, target));
            }

            foreach (var (neighbor, weight) in graph[node])
            {
                var candidateDistance = distance + weight;

                // Relax the edge if this route improves the best known distance.
                if (candidateDistance < distances[neighbor])
                {
                    distances[neighbor] = candidateDistance;
                    parent[neighbor] = node;
                    priorityQueue.Enqueue(neighbor, candidateDistance);
                }
            }
        }

        return new ShortestPathResult(long.MaxValue, new List<int>());
    }

    private static IReadOnlyList<int>[] BuildAdjacencyList(
        int vertexCount,
        IReadOnlyList<(int From, int To)> edges,
        bool isDirected)
    {
        if (vertexCount < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(vertexCount));
        }

        var graph = new List<int>[vertexCount];

        for (var vertex = 0; vertex < vertexCount; vertex++)
        {
            graph[vertex] = new List<int>();
        }

        foreach (var (from, to) in edges)
        {
            ValidateVertex(from, vertexCount);
            ValidateVertex(to, vertexCount);

            graph[from].Add(to);

            if (!isDirected)
            {
                graph[to].Add(from);
            }
        }

        return graph;
    }

    private static List<int> ReconstructPath(int[] parent, int start, int target)
    {
        var path = new List<int>();

        for (var node = target; node != -1; node = parent[node])
        {
            path.Add(node);

            if (node == start)
            {
                path.Reverse();
                return path;
            }
        }

        return new List<int>();
    }

    private static int ValidateSquareMatrix(int[,] matrix)
    {
        if (matrix.GetLength(0) != matrix.GetLength(1))
        {
            throw new ArgumentException("Adjacency matrix must be square.", nameof(matrix));
        }

        return matrix.GetLength(0);
    }

    private static void ValidateWeightedGraph(IReadOnlyList<(int To, int Weight)>[] graph)
    {
        for (var from = 0; from < graph.Length; from++)
        {
            foreach (var (to, weight) in graph[from])
            {
                ValidateVertex(to, graph.Length);

                if (weight < 0)
                {
                    throw new ArgumentException(
                        "Dijkstra requires all edge weights to be non-negative.",
                        nameof(graph));
                }
            }
        }
    }

    private static void ValidateVertex(int vertex, int vertexCount)
    {
        if (vertex < 0 || vertex >= vertexCount)
        {
            throw new ArgumentOutOfRangeException(nameof(vertex));
        }
    }
}
