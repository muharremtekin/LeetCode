
/// <summary>
/// Represents a node in a linked list.
/// </summary>
public class ListNode
{
    public int val;
    public ListNode next;

    /// <summary>
    /// Initializes a new instance of the <see cref="ListNode"/> class with the specified value and next node.
    /// </summary>
    /// <param name="val">The value of the node.</param>
    /// <param name="next">The next node in the linked list.</param>
    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }


    public static ListNode CreateLinkedList(IEnumerable<int> nums)
    {
        if (nums == null || !nums.Any()) return new ListNode();

        ListNode dummy = new();
        ListNode current = dummy;
        foreach (int num in nums)
        {
            current.next = new ListNode(num);
            current = current.next;
        }
        return dummy.next;
    }
}
public class ReverseLinkedList
{
    public static ListNode ReverseList(ListNode head)
    {
        ListNode prev = null;
        ListNode current = head;
        ListNode next = null;
        while (current != null)
        {
            next = current.next; // Store the next node
            current.next = prev; // Reverse the link
            prev = current;      // Move prev to current
            current = next;      // Move to the next node
        }
        return prev;
    }
}