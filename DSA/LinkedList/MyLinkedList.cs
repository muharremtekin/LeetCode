public class SLNode<T>(T value, SLNode<T>? next = null)
{
    public T Value { get; set; } = value;
    public SLNode<T>? Next { get; set; } = next;
}

/// <summary>
/// Represents a singly linked list.
/// </summary>
/// <typeparam name="T">The type of elements in the linked list. Must be a reference type.</typeparam>
public class MyLinkedList<T>
{
    /// <summary>
    /// Gets or sets the head node of the linked list.
    /// </summary>
    public SLNode<T>? Head { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="MyLinkedList{T}"/> class that is empty.
    /// </summary>
    public MyLinkedList() => Head = null;

    /// <summary>
    /// Initializes a new instance of the <see cref="MyLinkedList{T}"/> class that contains the specified head node.
    /// </summary>
    /// <param name="head">The head node of the linked list.</param>
    public MyLinkedList(SLNode<T> head) => Head = head;

    /// <summary>
    /// Appends a new node with the specified value to the end of the linked list.
    /// </summary>
    /// <param name="Value">The value to append to the linked list.</param>
    public void Append(T Value)
    {
        var newNode = new SLNode<T>(Value);

        if (Head == null)
        {
            Head = newNode;
            return;
        }

        var last = Head;
        while (last.Next != null)
        {
            last = last.Next;
        }

        last.Next = newNode;
    }

    public override string ToString()
    {
        if (Head == null) return "Empty list";

        var current = Head;
        var result = new System.Text.StringBuilder();
        while (current != null)
        {
            result.Append(current.Value.ToString() + " -> ");
            current = current.Next;
        }
        result.Append("null");
        return result.ToString();
    }
}