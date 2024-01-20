using System.Reflection.PortableExecutable;
using System.Text;

class ReverseWordsInAString
{
    public static string Solution(string s)
    {
        StringBuilder removedSpacesBuilder = new();
        StringBuilder reversedBuilder = new();

        bool lastCharIsSpace = false;
        foreach (char c in s.Trim())
        {
            if (char.IsWhiteSpace(c))
            {
                if (!lastCharIsSpace)
                {
                    removedSpacesBuilder.Append(" ");
                    lastCharIsSpace = true;
                }
            }
            else
            {
                removedSpacesBuilder.Append(c);
                lastCharIsSpace = false;
            }
        }

        string[] reversedArr = removedSpacesBuilder.ToString().Split(" ");

        for (int i = reversedArr.Length - 1; i >= 0; i--)
        {
            reversedBuilder.Append(reversedArr[i]);
            if (i > 0)
                reversedBuilder.Append(" ");
        }

        return reversedBuilder.ToString();
    }
}