// namespace DeleteMiddleNodeOfALinkedListSolution;

public class DeleteMiddleNodeOfALinkedList
{
    public static ListNode DeleteMiddle(ListNode head)
    {
        if (head is null) return head;

        if(head.next is null) return null;

        if (head.next.next is null)
        {
            head.next = null;
            return head;
        }

        int count = 0;
        FindDepth(head, ref count);
        int middleIndex = count / 2;

        count = 0;

        FindAndDelete(head, ref count, middleIndex);

        return head;
    }
    static void FindAndDelete(ListNode node, ref int count, int index)
    {
        if (node is null) return;

        if (count == index - 1)
        {
            int deleted = node.next.val;
            node.next = node.next.next;
            Console.WriteLine(deleted + " deleted.");
            return;
        }

        count++;
        FindAndDelete(node.next, ref count, index);
    }
    static void FindDepth(ListNode node, ref int count)
    {
        if (node is null) return;
        count++;

        FindDepth(node.next, ref count);
    }
}