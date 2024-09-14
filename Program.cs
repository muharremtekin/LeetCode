
var results = new List<int>();

int[] inputs = new int[] { 1, 100, 3001, 3002 };

var recentCounter = new RecentCounter();

foreach (int item in inputs)
{
    var response = recentCounter.Ping(item);
    results.Add(response);
}