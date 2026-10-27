public class ValidParentheses
{
    // https://leetcode.com/problems/valid-parentheses/description

    // 20. Valid Parentheses
    // Easy

    // Hint
    // Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.

    // An input string is valid if:

    // Open brackets must be closed by the same type of brackets.
    // Open brackets must be closed in the correct order.
    // Every close bracket has a corresponding open bracket of the same type.


    // Example 1:

    // Input: s = "()"

    // Output: true

    // Example 2:

    // Input: s = "()[]{}"

    // Output: true
    public bool IsValid(string s)
    {
        if(s.Length % 2 == 1) return false;



        return true;
    }
}