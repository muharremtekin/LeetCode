public class GroupAnagramsSolution
{
    // https://leetcode.com/problems/group-anagrams/
    public IList<IList<string>> GroupAnagrams(string[] strs)
    {
        // Input: strs = ["eat","tea","tan","ate","nat","bat"]
        // Output: [["bat"],["nat","tan"],["ate","eat","tea"]]

        var groups = new Dictionary<string, List<string>>();

        foreach (string word in strs)
        {
            string key = new string(word.OrderBy(c => c).ToArray());

            if (!groups.TryGetValue(key, out var group))
            {
                group = new List<string>();
                groups[key] = group;
            }

            group.Add(word);
        }

        return groups.Values
            .Select(group => (IList<string>)group)
            .ToList();
    }
}