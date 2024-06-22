public class RemovingStarsFromaString
{
    public static string Solution(string s)
    {
        Stack<char> stack = new();

        for (int i = 0; i < s.Length; i++)
        {
            if(s[i] != '*')
                stack.Push(s[i]);
            else
                stack.Pop();
        }
        return new string(stack.Reverse().ToArray());
    }
}