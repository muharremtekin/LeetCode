# Graph Temsilleri, DFS, BFS ve Hedefe Giden Yol

Bu örneklerde düğümler `0` ile `V - 1` arasındaki tamsayılardır. Kenarların yönlü olduğu varsayılır. Yönsüz graf için bir kenarı iki yönde eklemeli veya edge-list metotlarındaki `isDirected` parametresini `false` vermelisin.

Örnek graf:

```text
0 -> 1, 2
1 -> 3
2 -> 3, 4
3 -> 5
4 -> 5
```

Başlangıç düğümü `0` ise komşuların yukarıdaki sırayla saklandığını düşünelim. DFS ziyaret sırası `0, 1, 3, 5, 2, 4`; BFS ziyaret sırası `0, 1, 2, 3, 4, 5` olur. Bu bir **kenar/yol dizisi değildir**: DFS, `5`te devam edecek komşu bulamayınca recursion ile geri döner, sonra `0`ın henüz ziyaret edilmemiş diğer komşusu olan `2`yi gezer.

```text
DFS'nin hareketi: 0 -> 1 -> 3 -> 5
                         geri <- geri <- geri
                 0 -> 2 -> 3 (zaten ziyaretli, geç)
                      -> 4 -> 5 (zaten ziyaretli, geç)
```

Dolayısıyla graf içinde `5 -> 2` kenarı yoktur. Sadece `5` ziyaret edildikten sonraki **ziyaret sırası**nda `2` gelir. Komşu sırasını değiştirirsen ziyaret sırası değişebilir; algoritmaların doğruluğu değişmez.

## 1. Adjacency List (Komşuluk Listesi)

Her düğüm, doğrudan gidebildiği komşuların listesini tutar. Seyrek graflar için genelde en iyi varsayılan temsildir: yalnızca var olan kenarları saklar.

```csharp
IReadOnlyList<int>[] graph =
[
    new[] { 1, 2 }, // 0 -> 1, 2
    new[] { 3 },    // 1 -> 3
    new[] { 3, 4 }, // 2 -> 3, 4
    new[] { 5 },    // 3 -> 5
    new[] { 5 },    // 4 -> 5
    Array.Empty<int>()
];

var dfs = GraphTraversal.DepthFirstSearchAdjacencyList(graph, 0);
var bfs = GraphTraversal.BreadthFirstSearchAdjacencyList(graph, 0);
```

- **DFS (Depth-First Search):** Bir komşuya gider, mümkün olduğunca derine iner, sonra geri döner. Kodda bunu recursive `Visit` fonksiyonu yapar.
- **BFS (Breadth-First Search):** Önce başlangıçtan bir kenar uzaklıktaki tüm düğümleri, sonra iki kenar uzaklıktakileri gezer. Bunun için FIFO `Queue<int>` kullanılır.
- Her iki traversal da `visited` dizisini kullanır. Bu, döngülü graflarda aynı düğümü tekrar ziyaret edip sonsuz döngüye girmeyi engeller.

Komşuluk listesiyle DFS ve BFS, başlangıç düğümünden erişilebilen bileşen için **O(Vr + Er)** zaman kullanır. `Vr`, erişilebilen düğüm; `Er`, incelenen kenar sayısıdır. Bu implementasyonda `visited` dizisi grafın tüm düğümleri için ayrıldığı için ek alan **O(V)**'dir; burada `V`, grafın toplam düğüm sayısıdır.

## 2. Adjacency Matrix (Komşuluk Matrisi)

`matrix[from, to] != 0` ise `from -> to` kenarı vardır. Değer `1` olabilir; ağırlıklı bir grafı temsil ediyorsan sıfır olmayan ağırlığı da kullanabilirsin. Bu traversal metotları ağırlığı kullanmaz, yalnızca kenarın varlığına bakar.

```csharp
var matrix = new int[,]
{
    // 0  1  2  3  4  5
    { 0, 1, 1, 0, 0, 0 }, // 0
    { 0, 0, 0, 1, 0, 0 }, // 1
    { 0, 0, 0, 1, 1, 0 }, // 2
    { 0, 0, 0, 0, 0, 1 }, // 3
    { 0, 0, 0, 0, 0, 1 }, // 4
    { 0, 0, 0, 0, 0, 0 }  // 5
};

var dfs = GraphTraversal.DepthFirstSearchAdjacencyMatrix(matrix, 0);
var bfs = GraphTraversal.BreadthFirstSearchAdjacencyMatrix(matrix, 0);
```

Bir düğümün komşularını bulmak için matrisin ilgili satırındaki tüm `V` sütunu kontrol edilir. Bu yüzden matris **O(V²)** alan ve DFS/BFS için **O(V²)** zaman kullanır. Graf yoğunsa (kenar sayısı `V²`'ye yakınsa) bu kabul edilebilir; kenar var mı sorusuna da O(1) cevap verir.

## 3. Edge List (Kenar Listesi)

Graf, yalnızca kenar çiftleriyle saklanır. Dosyadaki metot bu listeyi bir kez komşuluk listesine dönüştürüp sonra traversal yapar.

```csharp
IReadOnlyList<(int From, int To)> edges =
[
    (0, 1), (0, 2), (1, 3), (2, 3), (2, 4), (3, 5), (4, 5)
];

var dfs = GraphTraversal.DepthFirstSearchEdgeList(6, edges, 0);
var bfs = GraphTraversal.BreadthFirstSearchEdgeList(6, edges, 0);

// Yönsüz graf örneği:
var undirectedBfs = GraphTraversal.BreadthFirstSearchEdgeList(6, edges, 0, isDirected: false);
```

Kenar listesi **O(E)** alan kullanır. Bir düğümün komşularını doğrudan buldurmadığı için, her ziyaret edilen düğümde tüm edge-list'i taramak kötü bir fikirdir: **O(V·E)** olur. Metottaki tek seferlik dönüştürme sayesinde maliyet **O(V + E)** kalır.

## 4. BFS ile En Kısa Yol Bulma

`FindShortestPathBfs`, **ağırlıksız** grafikte `start` ile `target` arasındaki **en az kenarlı** yolu döndürür.

```csharp
var path = GraphTraversal.FindShortestPathBfs(graph, start: 0, target: 5);
// [0, 1, 3, 5]
```

BFS bir düğümü ilk gördüğü anda ona en kısa sayıda kenarla ulaşmıştır. Yeni bir komşu bulunduğunda şu bilgi saklanır:

```text
parent[neighbor] = currentNode
```

Örneğin `5` için parent zinciri `5 <- 3 <- 1 <- 0` olabilir. Hedef bulununca zincir tersten takip edilir ve `Reverse()` ile `0 -> 1 -> 3 -> 5` biçimine çevrilir. Yol yoksa metot boş liste döndürür; `start == target` ise sonuç yalnızca `[start]` olur.

Bu yöntem **O(V + E)** zaman ve `visited`, `parent`, kuyruk için **O(V)** ek alan kullanır.

> Kenarların ağırlıkları farklıysa BFS en düşük toplam maliyeti garanti etmez. Negatif olmayan ağırlıklar için aşağıdaki Dijkstra metodu, negatif ağırlıklar da varsa Bellman-Ford düşünülmelidir.

## 5. Dijkstra ile En Düşük Maliyetli Yol

Kenar maliyetleri farklıysa, `FindShortestPathDijkstra` en az **toplam ağırlığa** sahip yolu bulur. Ağırlıkların tümü sıfır veya pozitif olmalıdır; negatif ağırlık varsa metot `ArgumentException` atar.

```csharp
IReadOnlyList<(int To, int Weight)>[] weightedGraph =
[
    new[] { (To: 1, Weight: 4), (To: 2, Weight: 1) }, // 0 -> 1 (4), 0 -> 2 (1)
    new[] { (To: 3, Weight: 1) },                       // 1 -> 3 (1)
    new[] { (To: 1, Weight: 2), (To: 3, Weight: 5) },  // 2 -> 1 (2), 2 -> 3 (5)
    Array.Empty<(int To, int Weight)>()
];

var result = GraphTraversal.FindShortestPathDijkstra(weightedGraph, start: 0, target: 3);

// result.Distance == 4
// result.Path is [0, 2, 1, 3]
// result.IsReachable == true
```

İlk bakışta `0 -> 1 -> 3` yolu mantıklı görünebilir, ama maliyeti `4 + 1 = 5`tir. Dijkstra daha iyi yolu bulur: `0 -> 2 -> 1 -> 3`, maliyet `1 + 2 + 1 = 4`.

Algoritma önce `distance[start] = 0`, diğer tüm düğümler için sonsuz (`long.MaxValue`) kabul eder. `PriorityQueue`, o ana kadar en küçük maliyetle ulaşılmış düğümü önce çıkarır. Bir kenar için daha iyi bir maliyet bulunduğunda bu işleme **relaxation** denir:

```text
candidate = distance[current] + edgeWeight
if candidate < distance[neighbor]:
    distance[neighbor] = candidate
    parent[neighbor] = current
```

`parent` dizisi BFS'teki gibi yolu geriye doğru kurar. Hedefe ulaşılmazsa `result.IsReachable` `false`, `result.Path` boş ve `result.Distance` `long.MaxValue` olur.

Bu implementasyon, .NET'in dört dallı (quaternary) min-heap tabanlı `PriorityQueue` sınıfını kullanır. Daha iyi bir yol bulunduğunda kuyruktaki eski kayıt silinmez; yeni kayıt eklenir. Bu nedenle genel durumda zaman karmaşıklığı **O((V + E) log E)**, ek alan karmaşıklığı **O(V + E)**'dir. Basit graf varsayımında `E <= V²` olduğundan zaman karmaşıklığı **O((V + E) log V)** olarak da yazılabilir. Grafı saklamak da dahil edildiğinde alan yine **O(V + E)** olur.

> Negatif kenar Dijkstra'nın "kuyruktan çıkan en küçük maliyet artık kesin en küçüktür" varsayımını bozar. Bu yüzden negatif ağırlıklar için Bellman-Ford gerekir.

## Hangi Temsili Seçmeliyim?

| İhtiyaç | Uygun temsil |
| --- | --- |
| Seyrek graf, traversal veya komşuları sık gezme | Adjacency list |
| İki düğüm arasındaki kenarı O(1) kontrol etmek | Adjacency matrix |
| Kenarlar veri kaynağından liste hâlinde geliyor | Edge list; traversal öncesinde adjacency list'e çevir |
| Negatif olmayan maliyetlerle en ucuz yol | Weighted adjacency list + Dijkstra |
