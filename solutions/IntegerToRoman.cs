public sealed class IntegerToRoman
{
    public static string IntToRoman(int num)
    {

        // 1 <= num <= 3999

        // i need a hashtable for roman numbers
        // I	1
        // V	5
        // X	10
        // L	50
        // C	100
        // D	500
        // M	1000

        Dictionary<int, string> romans = new Dictionary<int, string>
        {
            { 1, "I" },
            {5,"V"},
            {10,"X"},
            {50,"L"},
            {100,"C"},
            {500,"D"},
            {1000,"M"}
        };
        
        var s = num.ToString()
                    .ToArray();

        return "";
    }


}