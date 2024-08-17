public class FindTheHighestAltitude
{
    /// <summary>
    /// Calculates the highest altitude reached during a series of altitude gains.
    /// </summary>
    /// <param name="gain">An array of altitude gains.</param>
    public static int Solution(int[] gain)
    {
        int maxAltitude = 0;
        int currentAltitude = 0;

        foreach (int g in gain)
        {
            currentAltitude += g;
            if (currentAltitude > maxAltitude)
                maxAltitude = currentAltitude;
        }

        return maxAltitude;
    }
    public int LargestAltitude(int[] gain)
    {
        int max = 0;
        int current = 0;
        foreach (int item in gain)
        {
            current += item;
            if(current > max)
                max = current;
        }
        return max;
    }
}