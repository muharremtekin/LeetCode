# Two Pointers (İki Gösterge) Algoritması

**Two Pointers (İki Gösterge)** tekniği, özellikle diziler (arrays), string'ler veya bağlı listeler (linked lists) üzerinde arama, eşleştirme, sıralama ve gezinme işlemlerini optimize etmek için kullanılan oldukça popüler ve güçlü bir algoritmik yaklaşımdır.

Genellikle iç içe döngüler kullanılarak **O(N²)** zaman karmaşıklığında çözülecek kaba kuvvet (brute-force) problemleri, dizinin üzerinde aynı anda hareket eden iki farklı işaretçi (pointer/index) kullanarak **O(N)** zaman karmaşıklığına düşürmemizi sağlar. Ayrıca harici bir ek veri yapısı (örneğin HashSet, yeni bir liste vb.) kullanmadığı için hafıza (uzay) karmaşıklığı genelde **O(1)** olur.

---

## Ne Zaman Kullanılır?
Bir problemle karşılaştığınızda (örneğin LeetCode'da), sorunun çözümünde Two Pointers tekniğinin kullanılabileceğini size fısıldayan bazı ipuçları şunlardır:
1. Veri dizisi veya string **sıralı ise (sorted)**.
2. Bir problemde "çiftleri eşleştirme", "iki elemanın toplamı/farkı" isteniyorsa.
3. Bir string'in **Palindrom** olup olmadığı kontrol ediliyorsa.
4. Bir dizideki elemanların **yerinde değiştirilmesi (in-place)** isteniyorsa (örneğin 0'ları son atmak veya kopyaları silmek).
5. Bağlı listelerde (Linked List) ortadaki elemanı bulmak veya döngü (cycle) tespit etmek gerekiyorsa.

---

## Yaygın Stratejiler ve Kullanım Şekilleri

Ana hatlarıyla bu algoritma iki veya üç farklı desen (pattern) etrafında şekillenir:

### 1. Zıt Yönlü İlerleyen Göstergeler (Opposite Directional / Collision)
Bu yöntemde göstergelerden biri dizinin **en başında (sol)**, diğeri ise **en sonunda (sağ)** başlatılır. Elemanlar bir koşulu sağlayana kadar adım adım birbirlerine doğru (merkeze) yaklaşırlar. Göstergeler karşılaşıp birbirlerini geçtiklerinde döngü biter.

**Örnek Problem:** Sıralı bir dizide toplamı `target` olan iki sayıyı bulma *(Two Sum II - Input array is sorted)*.
```csharp
public int[] TwoSum(int[] numbers, int target) 
{
    int left = 0;
    int right = numbers.Length - 1;

    // Göstergeler birbiri ile çakışana kadar devam et. (Bazen left <= right olabilir sorusuna göre)
    while (left < right) 
    {
        int sum = numbers[left] + numbers[right];
        
        if (sum == target) 
            return new int[] { left + 1, right + 1 }; // İstenen toplam bulundu (örnekte 1-indexed istenmiş diyelim)
            
        else if (sum < target)
            left++;  // Dizi sıralı olduğu için; toplam küçük kaldıysa sol göstergeyi sağa kaydırarak büyüt.
            
        else // (sum > target)
            right--; // Toplam büyük kaldıysa sağ göstergeyi sola kaydırarak küçült.
    }
    
    return new int[0];
}
```

### 2. Aynı Yönlü İlerleyen Göstergeler (Same Directional / Fast & Slow Pointers)
Bu yöntemde göstergelerin ikisi de dizinin veya string'in **aynı noktasından** başlar ancak **farklı hızlarda** veya **farklı koşullarda** ilerlerler. Biri okuyucu (hızlı tespit eden), diğeri yazıcı/takipçi (yavaş, asıl veriyi güncelleyen) görevi görebilir. 

**Örnek Problem:** Sıralı dizideki tekrar eden (duplicate) elemanları yerinde (in-place) silerek eşsiz eleman sayısını dönme *(Remove Duplicates from Sorted Array)*.
```csharp
public int RemoveDuplicates(int[] nums) 
{
    if (nums.Length == 0) return 0;
    
    int slow = 0; // Yazıcı pointer: En son yazdığımız benzersiz elemanın konumu
    
    // Hızlı gösterge dizinin tamamını gezen okuyucudur
    for (int fast = 1; fast < nums.Length; fast++) 
    {
        // Eğer hızlı göstergede yeni ve farklı bir eleman bulduysak
        if (nums[fast] != nums[slow]) 
        {
            slow++; // Yavaş göstergeyi yeni yeri için ayarla
            nums[slow] = nums[fast]; // Yeni değeri yavaş göstergenin olduğu yere kopyala
        }
    }
    
    return slow + 1; // Yeni dizinin benzersiz eleman boyutunu döndürür
}
```

### 3. Yavaş ve Hızlı Pointer (Floyd's Tortoise and Hare)
Genellikle bağlı listelerde (Linked List) kullanılır. Bir pointer her defasında 1 adım, diğeri 2 adım ilerler. Eğer bağlı listede bir döngü var ise hızlı olan tur bindirerek yavaş olanı yakalayacaktır.

**Örnek Problem:** Bağlı listede döngü olup olmadığını bulma *(Linked List Cycle)*.
```csharp
public bool HasCycle(ListNode head) 
{
    if (head == null) return false;
    
    ListNode slow = head;
    ListNode fast = head;
    
    // Hızlı gösterge dizinin sonuna gelene kadar devam et
    while (fast != null && fast.next != null) 
    {
        slow = slow.next;         // Yavaş gösterge 1 adım ilerler
        fast = fast.next.next;    // Hızlı gösterge 2 adım ilerler
        
        if (slow == fast) 
            return true; // Hızlı olan yavaşa tur bindirdi (Döngü var)
    }
    
    return false; // Liste sonlandı, döngü yok
}
```

### 4. Üç Gösterge (Three Pointers / Dutch National Flag)
"Two Pointers" mantığının ufak bir modifikasyonu olan tekniktir. Dizide sadece 3 farklı gruba ayrılacak elemanlar varsa kullanılır. (Örn: Sadece 0, 1 ve 2'leri sıralamak)

**Örnek Problem:** Sadece 0, 1 ve 2'leri içeren bir diziyi sıralama *(Sort Colors)*.
```csharp
public void SortColors(int[] nums) 
{
    int low = 0;                  // 0'ların yerleşeceği sınır (soldan)
    int mid = 0;                  // Okuyucu gösterge
    int high = nums.Length - 1;   // 2'lerin yerleşeceği sınır (sağdan)

    while (mid <= high) 
    {
        if (nums[mid] == 0) 
        {
            // 0 bulduk: low ile takas et ve her ikisini de ilerlet
            (nums[low], nums[mid]) = (nums[mid], nums[low]);
            low++;
            mid++;
        }
        else if (nums[mid] == 1) 
        {
            // 1 bulduk: Ortada kalmalı, sadece okuyucuyu ilerlet
            mid++;
        }
        else 
        {
            // 2 bulduk: high ile takas et, sağ sınırı daralt (mid sabit kalır!)
            (nums[mid], nums[high]) = (nums[high], nums[mid]);
            high--;
        }
    }
}
```

### 5. İki Farklı Dizi/String Üzerinde İlerleyen Göstergeler
Göstergeler çoğunlukla tek bir veri yapısı üzerinde ilerlese de; iki farklı dizinin/string'in aynı anda taranması gerektiğinde, her biri için ayrı bir göstergenin tutulduğu senaryolardır.

**Örnek Problem:** Bir string'in diğerinde harf sırası bozulmadan geçip geçmediğini kontrol etme *(Is Subsequence)* veya iki sıralı diziyi tek bir dizide birleştirme *(Merge Sorted Array)*.
```csharp
public bool IsSubsequence(string s, string t) 
{
    int sPointer = 0, tPointer = 0;
    
    // t string'ini tek tek gez, eşleşme oldukça s string'inde de ilerle
    while (sPointer < s.Length && tPointer < t.Length) 
    {
        if (s[sPointer] == t[tPointer]) 
        {
            sPointer++;
        }
        tPointer++;
    }
    
    // sPointer'ın s'in boyutuna ulaşması tüm karakterlerin eşleştiğini gösterir
    return sPointer == s.Length;
}
```

## Özet Olarak Avantajları
- **Hız (Zaman Karmaşıklığı):** Sizi genellikle `O(N²)` çözümlerden kurtararak lineer `O(N)` süreye ulaştırır.
- **Hafıza (Uzay Karmaşıklığı):** Yeni diziler oluşturmadığınız için RAM (bellek) dostudur. Tüm değişikliği dizinin mevcut yerini kullanarak (`O(1)` inplace) yapmanızı sağlar.
- **Okunabilirlik:** Mantığı bir kez anlaşıldıktan sonra kodun neresinde nelerin yönetildiği (sol taraf ne yapıyor, sağ taraf ne yapıyor) gayet açıktır.
