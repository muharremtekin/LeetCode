public class MaximumTwinSumOfALinkedList
{
    // In a linked list of size n, where n is even, the ith node (0-indexed) of the linked list is known as the twin of the (n-1-i)th node, if 0 <= i <= (n / 2) - 1.
    // For example, if n = 4, then node 0 is the twin of node 3, and node 1 is the twin of node 2. These are the only nodes with twins for n = 4.
    // The twin sum is defined as the sum of a node and its twin.
    // Given the head of a linked list with even length, return the maximum twin sum of the linked list.

    // public class ListNode
    // {
    //     public int val;
    //     public ListNode next;
    //     public ListNode(int val = 0, ListNode next = null)
    //     {
    //         this.val = val;
    //         this.next = next;
    //     }
    // }


    public int PairSum(ListNode head)
    {
        List<int> list = new();
        DFS(head, list);

        // alttaki kod daha hızlı
        
        // var nextCell = head;
        // var list = new List<int>();
        // while(nextCell != null){
        //     list.Add(nextCell.val);
        //     nextCell= nextCell.next;
        // }

        if (list.Count is 2)
            return list[0] + list[1];

        int maxSum = 0;
        int right = list.Count - 1;
        int n = list.Count / 2;

        for (int i = 0; i < n; i++)
        {
            if (list[i] + list[right] > maxSum)
                maxSum = list[i] + list[right];

            right--;
        }

        return maxSum;
    }

    void DFS(ListNode node, List<int> list)
    {
        if (node == null) return;
        list.Add(node.val);
        DFS(node.next, list);
    }
}