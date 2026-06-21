public class ContainsDuplicateSolution
{
    public bool ContainsDuplicate(int[] nums)
    {
        var set = new HashSet<int>();

        foreach (int num in nums)
        {
            if (!set.Add(num))
                return true;
        }

        return false;
    }
}