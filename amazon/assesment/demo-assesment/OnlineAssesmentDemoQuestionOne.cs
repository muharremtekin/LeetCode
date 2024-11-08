public class OnlineAssesmentDemoQuestionOne
{
    public static List<string> ProcessLogs(List<string> logs, int threshold)
    {
        Dictionary<string, int> userTransactionCounts = new Dictionary<string, int>();

        foreach (var log in logs)
        {
            var parts = log.Split(' ');
            string sender = parts[0];
            string recipient = parts[1];

            if (userTransactionCounts.ContainsKey(sender))
            {
                userTransactionCounts[sender]++;
            }
            else
            {
                userTransactionCounts[sender] = 1;
            }

            if (recipient != sender)
            {
                if (userTransactionCounts.ContainsKey(recipient))
                {
                    userTransactionCounts[recipient]++;
                }
                else
                {
                    userTransactionCounts[recipient] = 1;
                }
            }
        }

        var result = userTransactionCounts
            .Where(kvp => kvp.Value >= threshold)
            .Select(kvp => kvp.Key)
            .OrderBy(id => int.Parse(id))
            .ToList();

        return result;
    }
}