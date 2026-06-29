using System.Text;

public class OneAnagramQuestion
{
    public IList<IList<string>> GroupAnagrams(string[] strs)
    {
        if (strs == null) return [[]];
        // burada direkt hashmap yerine dictionary kullanacağım çünkü tüm keylerim string olacak
        Dictionary<string, List<string>> map = new();

        // foreach ile elemanları dönüyoruz
        foreach (string str in strs)
        {
            var charKeyArr = str.ToCharArray();
            Array.Sort(charKeyArr);
            string key = new string(charKeyArr);

            if (!map.ContainsKey(key))
                map[key] = new List<string>() { str };
            else
                map[key].Add(str);
        }

        return new List<IList<string>>(map.Values);
    }

    public IList<IList<string>> GroupAnagrams2(string[] strs)
    {
        var map = new Dictionary<string, List<string>>();

        foreach (string str in strs)
        {
            // 1) 26 harfi say
            var count = new int[26];
            foreach (char c in str)
                count[c - 'a']++;          // 'a'->0, 'b'->1, ... harfi index'e çevir

            // 2) sayım dizisini string key'e çevir
            var sb = new StringBuilder();
            for (int i = 0; i < 26; i++)
            {
                sb.Append('#');            // ayraç: "1,12" ile "11,2" karışmasın diye
                sb.Append(count[i]);
            }
            string key = sb.ToString();    // ör. "#1#0#0...#1...#1"

            // 3) gruplama (TryGetValue ile tek lookup)
            if (!map.TryGetValue(key, out var list))
            {
                list = new List<string>();
                map[key] = list;
            }
            list.Add(str);
        }

        return new List<IList<string>>(map.Values);
    }
}