// ============================================================
// COLD REPEAT — Valid Parentheses (LeetCode 20)  |  2026-10-23
// ⚠️ DO NOT open ValidParentheses.cs. Write from scratch.
// Timer: 20 min. Out loud, in English. Run the 5-step protocol first
// (clarify → tiny example → brute force idea → pattern/trigger → code → trace).
//
// s contains only the characters '(', ')', '{', '}', '[' and ']'.
// s is valid if:
//   - open brackets are closed by the same type of bracket,
//   - open brackets are closed in the correct order,
//   - every close bracket has a matching open bracket.
// 1 <= s.length <= 10^4
//
//   "()"      -> true
//   "()[]{}"  -> true
//   "(]"      -> false
//   "([])"    -> true
//   "([)]"    -> false
//
// Run: Console.WriteLine(new ValidParenthesesColdRepeat().IsValid("()[]{}"));
// ============================================================

using System;
using System.Collections.Generic;

public class ValidParenthesesColdRepeat
{

    // "([])"  -> son açılan parantezin ilk kapanan olması lazım
    private readonly Dictionary<char, char> pairs = new Dictionary<char, char> { { '(', ')' }, { '[', ']' }, { '{', '}' } };
    public bool IsValid(string s)
    {
        Stack<char> _stack = new();

        foreach (char item in s)
        {
            if (item == '(' || item == '{' || item == '[')
            {
                _stack.Push(item);
            }
            else
            {
                if (_stack.Count == 0) return false;

                char lastOpeningChar = _stack.Pop();

                if (pairs[lastOpeningChar] != item) return false;
            }
        }

        return _stack.Count == 0;
    }

    // trace for "([)]"
    // item | stack (önce) | aksiyon            | stack (sonra)
    // (        {}             add to stack         {'('}
    // [       {'('}           add to stack         {'(','['}
    // )       {'(','['}       return false because it's not pair of last closed paranthese


    // time complexity o(n), space complexity(n) m = worst case is n because it can be "((((("



}
