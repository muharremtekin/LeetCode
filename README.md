# LeetCode75

This repository contains C# solutions to the [LeetCode 75 Study Plan](https://leetcode.com/study-plan/leetcode-75/) and selected Top Interview 150 problems. Solutions are organized by topic and problem, with clear code, explanations, and some unit tests for data structures.

---

## 📁 Project Structure

```
LeetCode75/
├── solutions/
│   ├── MaxDepthOfBinaryTree.cs
│   ├── RemoveDuplicatesFromSortedArray.cs
│   └── ... (other solution files)
├── TopInterview150/
│   └── Solutions/
│       └── RemoveDuplicatesFromSortedArray.cs
├── DSA/
│   └── LinkedList/
│       └── LinkedListTest.cs
└── README.md
```

- **solutions/**: Core LeetCode 75 C# solutions, each in its own file.
- **TopInterview150/Solutions/**: Additional solutions for Top Interview 150 problems.
- **DSA/LinkedList/**: Data structure implementations and related unit tests.


## 📝 Example Solution

Here’s an example from `MaxDepthOfBinaryTree.cs`:

```csharp
public static int MaxDepth(TreeNode root)
{
    if (root == null) return 0;
    int leftDepth = MaxDepth(root.left);
    int rightDepth = MaxDepth(root.right);
    return Math.Max(leftDepth, rightDepth) + 1;
}
```

**Happy Coding!**