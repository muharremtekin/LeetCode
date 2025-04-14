public class EvaluateDivision
{
    // ağırlıklı graflara daha çok çalış
    public double[] CalcEquation(IList<IList<string>> equations, double[] values, IList<IList<string>> queries)
    {
        var graph = new Dictionary<string, List<(string, double)>>();

        for (int i = 0; i < equations.Count; i++)
        {
            string a = equations[i][0];
            string b = equations[i][1];
            double val = values[i];

            if (!graph.ContainsKey(a)) graph[a] = new List<(string, double)>();
            if (!graph.ContainsKey(b)) graph[b] = new List<(string, double)>();

            graph[a].Add((b, val));
            graph[b].Add((a, 1.0 / val));
        }

        double[] results = new double[queries.Count];
        for (int i = 0; i < queries.Count; i++)
        {
            string start = queries[i][0];
            string end = queries[i][1];
            results[i] = DFS(start, end, graph, new HashSet<string>());
        }

        return results;
    }

    private double DFS(string start, string end, Dictionary<string, List<(string, double)>> graph, HashSet<string> visited)
    {
        if (!graph.ContainsKey(start) || !graph.ContainsKey(end)) return -1.0;

        if (start == end) return 1.0;

        visited.Add(start);

        foreach (var (next, weight) in graph[start])
        {
            if (!visited.Contains(next))
            {
                double result = DFS(next, end, graph, visited);
                if (result != -1.0)
                {
                    return weight * result;
                }
            }
        }

        return -1.0;
    }
}