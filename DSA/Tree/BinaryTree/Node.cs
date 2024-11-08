public class Node<T>
{
    public T Value { get; set; }
    public Node<T> Left { get; set; }
    public Node<T> Right { get; set; }
    public Node()
    {

    }
    public Node(T value)
    {
        Value = value;
        Left = null;
        Right = null;
    }
        public Node(T value, Node<T> left = null, Node<T> right = null)
    {
        Value = value;
        Left = left;
        Right = right;
    }

    public override string ToString() => $"{Value}";
}