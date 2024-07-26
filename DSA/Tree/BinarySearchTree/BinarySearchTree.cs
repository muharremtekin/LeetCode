using System.Collections;

public class BinarySearchTree<T> : IEnumerable<T> 
where T : IComparable
{
    public Node<T> Root { get; set; }
    public BinarySearchTree()
    {
        
    }
    public BinarySearchTree(IEnumerable<T> collection)
    {
        foreach (var item in collection)
            Add(item);
    }
    public IEnumerator<T> GetEnumerator()
    {
        throw new NotImplementedException();
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
    }

    public void Add(T value)
    {
        if(value is null)
            throw new ArgumentNullException(nameof(value));

        var node = new Node<T>(value);

        if (Root == null)
        {
            Root = node;
            return;
        }
        else
        {
            var current = Root;
            Node<T> parent;
            while (true)
            {
                parent = current;
                // left tree
                if (value.CompareTo(current.Value) < 0)
                {
                    current = current.Left;
                    if (current == null)
                    {
                        parent.Left = node;
                        break;
                    }
                }
                // right tree
                else
                {
                    current = current.Right;
                    if (current == null)
                    {
                        parent.Right = node;
                        break;
                    }
                }
            }
        }
    }
}