public class RecentCounter
{
    private List<int> requestTimes;
    private const int TimeRange = 3000;
    public RecentCounter()
    {
        requestTimes = new List<int>();
    }

    public int Ping(int t)
    {
        // calculate range. range is equal to [t - 3000, t]. for example if t equal 10, range will be -2990 to 10.
        requestTimes.Add(t);

        // we have to return the number of requests that has happened in the past 3000 milliseconds (including the new request).
        while (requestTimes.Count > 0 && requestTimes[0] < t - TimeRange)
        {
            requestTimes.RemoveAt(0);
        }
        return requestTimes.Count;
    }
}