public class BinaryTreeInorderTraversal
{
    public IList<int> InorderTraversal(Node<int> root)
    {
        if (root is null) return [];
        if (root.Left is null && root.Right is null) return [root.Value];

        List<int> result = new();

        Stack<Node<int>> stack = new();
        stack.Push(root);

        while (stack.Count > 0)
        {
            var current = stack.Pop();

            result.Add(current.Value);

            if (current.Left != null) stack.Push(current.Left);

            if (current.Right != null) stack.Push(current.Right);
        }
        
        return result;
    }
}