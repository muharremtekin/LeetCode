// ============================================================
// MOCK INTERVIEW — 2026-07-07 (day before the real one)
// Interviewer scenario, Amazon style:
//
// "At Amazon, one of our services fetches product metadata from a
// downstream database. These lookups are expensive, so we want to
// put a small in-memory cache in front of it. The cache has a
// FIXED CAPACITY — it can hold at most `capacity` items.
//
// When the cache is full and we need to insert a new item, we
// should EVICT THE ITEM THAT WAS USED LEAST RECENTLY."
//
// Operations to implement:
//   Get(int key)            -> value if key exists, otherwise -1.
//                              Counts as "using" the item.
//   Put(int key, int value) -> insert or update the key.
//                              Also counts as "using" it.
//                              If inserting exceeds capacity,
//                              evict the least recently used item first.
//
// REQUIREMENT: both operations O(1) average time.
//
// (LeetCode 146. LRU Cache — Medium)
// https://leetcode.com/problems/lru-cache/
//
// ============================================================
// THE KEY INSIGHT (memorize this reflex):
//   "O(1) removal from the middle" => doubly linked list
//   "O(1) lookup by key"           => hash map
//   LRU = Dictionary<key, Node> + doubly linked list of Nodes.
//
//   - List order = usage order. Head side = most recent,
//     tail side = least recent.
//   - Dictionary maps key -> its Node, so we can jump straight
//     to any node without walking the list.
//   - Node stores BOTH key and value. The key must be in the
//     node because when we evict the tail node, we need its key
//     to delete the dictionary entry.
//   - Sentinel head & tail nodes (dummy nodes that never hold
//     data) mean the list is never "empty" from the pointers'
//     point of view -> zero null checks when linking/unlinking.
//
//   Get(key):  not in dict -> -1.
//              else unlink node, re-link at head, return value.
//   Put(k,v):  in dict -> update value, move to head.
//              else if full -> evict node before tail (real LRU),
//                              remove its key from dict.
//              create node, add to head, add to dict.
// ============================================================

public class LRUCacheMock
{
    // Each cache entry lives in exactly one Node, linked into
    // the usage-order list and pointed at by the dictionary.
    private class Node
    {
        public int Key;
        public int Value;
        public Node Prev = null!;   // always wired before use (sentinels)
        public Node Next = null!;
    }

    private readonly Dictionary<int, Node> map;
    private readonly int capacity;

    // Sentinels: head.Next is the MOST recently used real node,
    // tail.Prev is the LEAST recently used real node.
    private readonly Node head;
    private readonly Node tail;

    public LRUCacheMock(int capacity)
    {
        this.capacity = capacity;
        map = new Dictionary<int, Node>(capacity);

        head = new Node();
        tail = new Node();
        head.Next = tail;
        tail.Prev = head;
    }

    public int Get(int key)
    {
        if (!map.TryGetValue(key, out Node? node))
            return -1;

        MoveToHead(node);   // "using" it => becomes most recent
        return node.Value;
    }

    public void Put(int key, int value)
    {
        if (map.TryGetValue(key, out Node? existing))
        {
            existing.Value = value;   // update, don't insert twice!
            MoveToHead(existing);
            return;
        }

        if (map.Count == capacity)
        {
            Node lru = tail.Prev;     // least recently used
            Unlink(lru);
            map.Remove(lru.Key);      // <- this is why Node stores Key
        }

        var node = new Node { Key = key, Value = value };
        AddToHead(node);
        map[key] = node;
    }

    // ---- linked-list helpers (each O(1), just pointer rewiring) ----

    private void Unlink(Node node)
    {
        node.Prev.Next = node.Next;
        node.Next.Prev = node.Prev;
    }

    private void AddToHead(Node node)
    {
        node.Prev = head;
        node.Next = head.Next;
        head.Next.Prev = node;   // old first node points back at us
        head.Next = node;
    }

    private void MoveToHead(Node node)
    {
        Unlink(node);
        AddToHead(node);
    }
}

// ============================================================
// HAND-TRACE (capacity = 2). List shown head -> tail (MRU -> LRU):
//
//   Put(1,1)   list: [1]        map: {1}
//   Put(2,2)   list: [2, 1]     map: {1,2}
//   Get(1)=1   list: [1, 2]     (1 moved to head)
//   Put(3,3)   full -> evict tail.Prev = node 2
//              list: [3, 1]     map: {1,3}
//   Get(2)=-1  (evicted)  ✓ matches the expected example
//
// FOLLOW-UPS TO EXPECT:
//   - "Make it thread-safe?"  -> lock around Get/Put (coarse), or
//     discuss that fine-grained locking on a linked list is hard;
//     real systems often shard the cache (N independent LRUs).
//   - "What if values are large / expire?" -> add TTL per node,
//     lazily evict expired on Get.
//   - ".NET shortcut?" -> LinkedList<T> + LinkedListNode<T> works
//     (List.Remove(node) is O(1)), but writing your own Node
//     shows more depth in an interview.
//
// ORDER-OF-OPERATIONS PITFALLS (your known weak spot — details):
//   1. In Put, handle the "key already exists" case FIRST,
//      otherwise you might evict to make room for an update.
//   2. Evict BEFORE inserting, and compare with map.Count,
//      not after adding (off-by-one).
//   3. In AddToHead, set node's pointers BEFORE touching
//      head.Next, or you lose the old first node.
// ============================================================
