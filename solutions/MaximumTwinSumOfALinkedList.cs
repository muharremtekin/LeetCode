public class MaximumTwinSumOfALinkedList
{
    // In a linked list of size n, where n is even, the ith node (0-indexed) of the linked list is known as the twin of the (n-1-i)th node, if 0 <= i <= (n / 2) - 1.
    // For example, if n = 4, then node 0 is the twin of node 3, and node 1 is the twin of node 2. These are the only nodes with twins for n = 4.
    // The twin sum is defined as the sum of a node and its twin.
    // Given the head of a linked list with even length, return the maximum twin sum of the linked list.
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    /// <summary>
    /// Calculates the sum of the two largest elements in a linked list.
    /// </summary>
    /// <param name="head">The head node of the linked list.</param>
    /// <returns>The sum of the two largest elements in the linked list.</returns>
    public int PairSum(ListNode head)
    {
        // en büyük iki elemanın toplamı
        int first = int.MinValue;
        int second = int.MinValue;

        ListNode node = head;

        while (node != null)
        {
            if (node.val > first)
                first = node.val;
            else if (node.val >= second)
                second = node.val;

            node = node.next;
        }
        return first + second;
    }
}