using System.Text;

public class LetterCombinationsOfAPhoneNumber
{
    // https://leetcode.com/problems/letter-combinations-of-a-phone-number
    // 17. Letter Combinations of a Phone Number
    // Medium

    // Given a string containing digits from 2-9 inclusive, 
    // return all possible letter combinations that the number could represent. 
    // Return the answer in any order.

    // A mapping of digits to letters (just like on the telephone buttons) 
    // is given below. Note that 1 does not map to any letters.

    // Example 1:

    // Input: digits = "23"
    // Output: ["ad","ae","af","bd","be","bf","cd","ce","cf"]
    // Example 2:

    // Input: digits = "2"
    // Output: ["a","b","c"]
    static Dictionary<char, string> pairs = new Dictionary<char, string>()
    {
        {'2',"abc"},
        {'3',"def"},
        {'4',"ghi"},
        {'5',"jkl"},
        {'6',"mno"},
        {'7',"pqrs"},
        {'8',"tuv"},
        {'9',"wxyz"},
    };
    public IList<string> LetterCombinations(string digits)
    {
        // need a dict<char, char[]>
        var result = new List<string>();
        Backtrack(0, digits, new StringBuilder(), result);
        return result;
    }

    void Backtrack(int index, string digits, StringBuilder current, List<string> result)
    {
        if (index == digits.Length)
        {
            result.Add(current.ToString());
            return;
        }

        foreach (char item in pairs[digits[index]])
        {
            current.Append(item);
            Backtrack(index + 1, digits, current, result);
            current.Remove(current.Length - 1, 1);
        }


    }
}