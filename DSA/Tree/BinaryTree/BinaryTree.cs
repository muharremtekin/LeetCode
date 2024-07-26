public class BinaryTree<T> where T : IComparable
{
    public List<Node<T>> list { get; private set; }
    public BinaryTree()
    {
        list = new List<Node<T>>();
    }
    /// <summary>
    /// Performs an in-order traversal of the binary tree rooted at the specified node.
    /// </summary>
    /// <param name="root">The root node of the binary tree.</param>
    /// <returns>A list of nodes visited in in-order traversal.</returns>
    public List<Node<T>> InOrder(Node<T> root)
    {
        if (!(root is null))
        {
            InOrder(root.Left);
            list.Add(root);
            InOrder(root.Right);
        }
        return list;
    }

    /// <summary>
    /// Performs a pre-order traversal of the binary tree starting from the specified root node.
    /// </summary>
    /// <param name="root">The root node of the binary tree.</param>
    /// <returns>A list of nodes visited during the pre-order traversal.</returns>
    public List<Node<T>> PreOrder(Node<T> root)
    {
        if (!(root is null))
        {
            list.Add(root);
            PreOrder(root.Left);
            PreOrder(root.Right);
        }
        return list;
    }
    public List<Node<T>> PostOrder(Node<T> root)
    {
        if (!(root is null))
        {
            PostOrder(root.Left);
            PostOrder(root.Right);
            list.Add(root);
        }
        return list;
    }
    public void ClearList() => list.Clear();
}