# Amazon OA — Pattern ve Düşünme Notları

Bu dosyanın amacı çözümü ezberlemek değil; soruyu görünce doğru veri yapısına ve yaklaşıma hızlıca gitmek.

## OA'da ilk 3-5 dakika

1. Girdiyi, çıktıyı ve kısıtları bir cümleyle yeniden söyle. Özellikle dizi sıralı mı, elemanlar tekrar edebilir mi, girdi boş olabilir mi, sonucu değiştirmek serbest mi diye bak.
2. En basit doğru yaklaşımı kur ve karmaşıklığını hesapla. O(n²) sınırı aşıyorsa, tekrar eden işi hangi veri yapısının kaldıracağını sor.
3. Soruda geçen sinyalleri yakala: "aynı", "tekrar", "en uzun kesintisiz", "en sık k", "en kısa yol", "grup sayısı", "cooldown" gibi ifadeler pattern ipucudur.
4. Çözüm fikrini şu sırayla ifade et: durumum ne, her adımda ne güncelleniyor, ne zaman cevap değişiyor, neden hiçbir olasılığı kaçırmıyorum?
5. Kodu yazmadan önce en az üç test düşün: en küçük giriş, tekrar/çakışma içeren giriş ve sınır durumu.

## Hızlı pattern seçici

| Soruda gördüğün sinyal | İlk bakılacak pattern / veri yapısı | Bu klasörde örnek |
| --- | --- | --- |
| Aynı değer, tamamlayıcı, frekans, eşit imza | Hash map veya hash set | Two Sum, Valid Anagram, Contains Duplicate |
| Sıralı dizi ya da üçlü/çiftli toplam | Sorting + iki işaretçi | Three Sum, Merge Sorted Array |
| Tekrarsız/en uzun/en küçük geçerli alt dizi | Kayan pencere | Longest Substring Without Repeating Characters |
| Her indeks için soldaki ve sağdaki etki | Prefix/suffix taraması | Product of Array Except Self |
| En sık k öğe | Frekans sayımı + bucket veya min-heap | Top K Frequent Elements |
| Ardışık sayı dizisi | Hash set ile sadece başlangıçlardan ilerle | Longest Consecutive Sequence |
| Negatif değerler de varken en iyi kesintisiz toplam | Kadane / dinamik programlama | Maximum Subarray |
| Şebeke, bağlantı, bölge, kişi grubu | DFS/BFS + visited | Count Groups |
| Grid üzerinde en kısa adım sayısı | BFS + kuyruk + visited | Amazon Fresh |
| İşler arası bekleme/cooldown | Frekans + greedy; gerekirse heap | Task Scheduler |

## Veri yapısı refleksleri

- HashSet: "Daha önce gördüm mü?", "üyelik kontrolü hızlı mı olmalı?", "tekrar var mı?" sorularında kullan. Ortalama O(1) ekleme ve arama sağlar.
- Dictionary<TKey, TValue>: Bir değeri indeksine, frekansına veya başka bir duruma bağlamak gerektiğinde kullan.
- Queue: BFS için. Kuyruktan çıkan her katman, en kısa adım sayısı açısından bir sonraki mesafeyi temsil eder.
- PriorityQueue: "Her turda en büyük/en küçük önemli öğeyi seç" deniyorsa düşün. C# PriorityQueue varsayılan olarak min-heap'tir.
- Array[26]: Karakter kümesi küçük ve sabitse Dictionary'den daha sade ve hızlıdır; küçük harf İngilizce karakterleri buna iyi örnektir.
- Sorting: İki işaretçi, duplicate atlama veya değerleri gruplayarak düşünme için bir ön adımdır. O(n log n) maliyetini bilinçli kabul et.

## Soru bazlı notlar

### Arrays and hashing

#### Two Sum — tamamlayıcı (complement) hash map

- Sinyal: "İki sayı hedefe toplansın", indeks isteniyor ve dizi sıralı değil.
- Düşünce: Her sayı x için aradığım değer target - x. Geçmişte bu tamamlayıcıyı görmüşsem cevap hazırdır.
- Durum: Dictionary içinde değer → indeks tut. Önce tamamlayıcıyı ara, sonra mevcut değeri ekle; böylece aynı elemanı iki kere kullanmazsın.
- Karmaşıklık: O(n) zaman, O(n) alan.
- Tuzaklar: Aynı sayı iki kez gerekebilir; bu yüzden sadece set değil indeks saklayan map gerekir. Sıralama indeksleri bozacağı için burada ilk tercih değildir.

#### Contains Duplicate — üyelik kontrolü

- Sinyal: "Herhangi bir tekrar var mı?"
- Düşünce: Yeni değeri sete eklemeye çalış; eklenemiyorsa onu daha önce gördün.
- Karmaşıklık: O(n) zaman, O(n) alan.
- Tuzak: İlk duplicate bulunduğunda erken dön; tüm diziyi taramaya gerek yok.

#### Valid Anagram — frekans dengesi

- Sinyal: İki string aynı karakter multiset'ini mi taşıyor?
- Düşünce: Birinci string karakter sayısını artır, ikinci string ile azalt. Herhangi bir sayı negatife düşerse eşleşme yoktur.
- Veri yapısı: Sadece a-z varsa int[26]; genel Unicode varsa Dictionary<Rune, int>.
- Karmaşıklık: O(n) zaman. Sabit alfabe ile O(1), genel karakter kümesiyle O(k) ek alan.
- Tuzak: Önce uzunlukları kontrol et. Unicode gereksinimi varsa char yerine Rune ve normalization düşün.

#### Group Anagrams — kanonik anahtar

- Sinyal: Kelimeleri "aynı imzaya" sahip gruplara ayırma.
- Düşünce: Her kelimeyi aynı anagram grubundaki tüm kelimeler için eşit olacak bir anahtara dönüştür. Sıralanmış karakterler kolay bir anahtardır.
- Veri yapısı: Dictionary<anahtar, List<kelime>>.
- Karmaşıklık: Sıralı anahtarla O(n · k log k); k kelime uzunluğu. Sabit alfabe için frekans anahtarıyla O(n · k) yapılabilir.
- Tuzak: Grupları kelimenin kendisiyle değil imzasıyla anahtarla.

#### Longest Consecutive Sequence — sadece dizinin başlangıçlarından ilerle

- Sinyal: Sıralanmamış dizide en uzun ardışık sayı zinciri ve O(n) beklentisi.
- Düşünce: Bir sayıdan ancak num - 1 sette yoksa zincir başlat. Böylece 2, 3, 4'ten tekrar tekrar saymazsın.
- Veri yapısı: HashSet.
- Karmaşıklık: Ortalama O(n) zaman, O(n) alan.
- Tuzak: Her sayıdan ileri saymak O(n²)'ye dönebilir; başlangıç filtresi bunun ilacıdır.

#### Product of Array Except Self — prefix/suffix

- Sinyal: Her indeks için "kendisi hariç diğerlerinin etkisi", bölme yasak veya sıfır olabilir.
- Düşünce: İlk geçişte sonuç[i] içine soldaki çarpımı yaz. Sağdan ikinci geçişte sağ çarpımla çarp.
- Karmaşıklık: O(n) zaman, sonuç dizisi hariç O(1) ek alan.
- Tuzaklar: Sıfırlar bölmeli çözümü kırar. Prefix güncellenirken nums[i] ile çarpılır; sonuç[i] ile çarpmak yanlış sonuç üretir.

#### Top K Frequent Elements — frekans + seçim yapısı

- Sinyal: "En sık k", "en büyük/en küçük k".
- Düşünce: Önce frekansları çıkar; sonra k öğeyi en verimli biçimde seç.
- Seçenekler:
  - Bucket sort: Frekans en fazla n olduğu için frekansı indeks olarak kullan. O(n) zaman ve alan.
  - Boyutu k olan min-heap: Farklı değer sayısı u ise O(u log k) zaman. k, u'dan küçükse iyi seçimdir.
  - Tam sıralama: Daha kısa kod ama O(u log u); k küçükse gereksiz iş olabilir.
- Tuzak: C# min-heap'te heap boyutu k'yı aşınca en düşük frekanslı elemanı çıkar.

### Two pointers

#### Merge Sorted Array — sondan birleştirme

- Sinyal: Birinci dizinin sonunda boş alan var ve iki sıralı dizi tek dizide birleşecek.
- Düşünce: Baştan yazarsan nums1 içindeki henüz okunmamış değeri ezebilirsin. En büyük elemanı en sağdaki boş konuma koy.
- Durum: i = nums1'in geçerli sonu, j = nums2'nin sonu, write = toplam son indeks.
- Karmaşıklık: O(m + n) zaman, O(1) ek alan.
- Tuzak: Döngü koşulu j >= 0 olmalı. nums1'de kalan değerler zaten doğru yerde olduğundan ayrıca kopyalanmaz.

#### Three Sum — sort + sabit sol + iki işaretçi

- Sinyal: Üç sayı toplamı hedef (çoğunlukla 0), benzersiz üçlüler isteniyor.
- Düşünce: Diziyi sırala. Her i için kalan hedef -nums[i] olur; bu iki toplam problemini iki işaretçiyle çöz.
- Duplicate stratejisi: i için aynı değeri atla; geçerli üçlü bulduktan sonra sol ve sağ işaretçideki tekrarları atla.
- Karmaşıklık: O(n²) zaman, sorting nedeniyle O(log n)–O(n) çağrı yığını/uygulama alanı.
- Tuzak: Hash map ile de yapılabilir ama duplicate kontrolü daha karmaşıklaşır. Sıralama burada hem aramayı hem duplicate yönetimini basitleştirir.

### Sliding window

#### Longest Substring Without Repeating Characters — geçerli pencereyi koru

- Sinyal: String/dizide "en uzun kesintisiz parça" ve "tekrar olmadan".
- Düşünce: right pencereyi büyütür. Yeni karakter duplicate yaparsa left'i, duplicate kalkana kadar ilerlet. Her an pencere geçerlidir.
- Veri yapısı: HashSet<char>; daha hızlı varyantta karakter → son indeks Dictionary'si.
- Karmaşıklık: O(n) zaman, O(min(n, alfabe)) alan. Her karakter pencereye en fazla bir kez girer ve çıkar.
- Tuzak: Duplicate görünce tüm seti temizlemek yanlış pencereleri kaçırır. En iyi pencereyi döngü içinde güncelle ve boş string için 0 dön.

### Dynamic programming

#### Maximum Subarray — Kadane algoritması

- Sinyal: Kesintisiz alt dizinin maksimum toplamı; negatif değerler var.
- Düşünce: Her indekste şu soruyu sor: "Bu sayıyla yeni bir dizi mi başlatmalıyım, yoksa önceki toplamı uzatmak mı daha iyi?" current = max(nums[i], current + nums[i]).
- Durum: current = i'de biten en iyi toplam; best = şimdiye kadarki en iyi toplam.
- Karmaşıklık: O(n) zaman, O(1) alan.
- Tuzak: Tüm sayılar negatifse cevap 0 değildir; en büyük negatif sayıdır. Bu yüzden current ve best'i nums[0] ile başlat.

### String simulation / matematik

#### ZigZag Conversion — simülasyon veya cycle matematiği

- Sinyal: Karakterlerin satırlar arasında aşağı-yukarı hareketi ve ardından satır satır okuma.
- Önce çöz: Simülasyon. Her satır için StringBuilder tut; yönü uç satırlarda değiştir. O(n) zaman, O(n) alan.
- Optimize: Cycle uzunluğu 2 × (numRows - 1). Her satırın dikey ve orta satırlarda çapraz indekslerini gez.
- Tuzak: numRows = 1 ve numRows >= string uzunluğu durumlarında doğrudan string'i dön; aksi halde cycle sıfır olur.

### Heap / greedy

#### Task Scheduler — en sık görev idle sayısını belirler

- Sinyal: Görevler yeniden sıralanabiliyor, aynı tür arasında cooldown var ve minimum toplam süre soruluyor.
- Düşünce: En çok tekrar eden görevler iskeleti kurar. Diğer görevler boşlukları doldurur; yetmezse idle oluşur.
- Kapalı form: maxFreq en yüksek frekans, maxCount bu frekanstaki görev sayısı ise sonuç max(tasks.Length, (maxFreq - 1) × (n + 1) + maxCount).
- Alternatif: Zaman çizelgesini gerçekten üretmek gerekirse max-heap + cooldown queue kullan.
- Tuzak: Amaç bir görev sırası değil minimum süre ise simülasyon gereksiz olabilir.

### Graph / BFS / DFS

#### Process Logs — tek geçişte sayım

- Sinyal: Log satırlarından kullanıcı/işlem frekansı çıkarma ve eşik filtreleme.
- Düşünce: Her logda sender ve recipient sayacını artır. Aynı kullanıcı iki roldeyse bir kere say.
- Veri yapısı: Dictionary<kullanıcıId, sayı>; sonuç için filtre + sıralama.
- Karmaşıklık: O(L + u log u); L log sayısı, u eşik üstü kullanıcı sayısı.
- Tuzak: ID'ler sayısal sıralanıyorsa metinsel sıralama 10'u 2'den önce getirebilir; problem tanımına göre sayısal karşılaştır.

#### Count Groups — bağlı bileşen sayısı

- Sinyal: İnsanlar/şehirler/makineler arasında bağlantı matrisi ve "kaç ayrı grup?" sorusu.
- Düşünce: Ziyaret edilmemiş her düğüm yeni bir bileşenin başlangıcıdır. DFS/BFS ile ulaşabildiğin her düğümü işaretle, ardından grup sayısını bir artır.
- Veri yapısı: visited dizisi + DFS çağrı yığını veya BFS kuyruğu.
- Karmaşıklık: Komşuluk matrisi için O(n²) zaman, O(n) alan.
- Tuzak: visited olmadan döngülü grafikte sonsuz dolaşılır. Büyük ve derin grafiklerde recursive DFS stack overflow yapabileceği için iterative DFS/BFS düşün.

#### Amazon Fresh — grid üzerinde en kısa yol

- Sinyal: Grid, dört yön hareket, engeller, başlangıçtan hedefe minimum adım.
- Düşünce: Kenarların maliyeti eşitse BFS ilk ulaştığı hedefte en kısa mesafeyi verir. Kuyrukta (satır, sütun, mesafe) veya katman sayacı tut.
- Veri yapısı: Queue, visited matrisi, dört yön vektörü.
- Karmaşıklık: O(rows × cols) zaman ve alan.
- Tuzak: Hücreyi kuyruğa ekler eklemez visited yap; dequeue anında işaretlemek aynı hücrenin tekrar eklenmesine yol açar. Başlangıç/hedef geçersizliği ve ulaşılamaz hedefi kontrol et.

## OA kodlama kontrol listesi

- Girdiyi değiştirmek serbest mi? Değilse sort için kopya gerekebilir.
- Boş girdi, tek eleman, tüm elemanlar aynı, negatifler, sıfırlar ve duplicate'ler ne yapar?
- İndeks mi değer mi döneceğim? Sorting indeks bilgisini kaybettirir.
- Overflow olabilir mi? Çarpım ve toplam sorularında int yerine long gerekebilir.
- Hash tabanlı çözümde anahtarın gerçekten problemi tanımlayan doğru "imza" olduğundan emin ol.
- BFS'te visited ne zaman işaretleniyor? Sliding window'da pencere hangi invariant'ı koruyor?
- Açıklama sonunda zaman ve alan karmaşıklığını söyle.

## Bu çalışma alanındaki takip notları

- ProductOfArrayExceptSelf2 içinde prefix ve suffix güncellemeleri nums[i] ile yapılmalı; mevcut result[i] üzerinden güncelleme doğru sonucu vermez.
- LongestSubstringWithoutRepeatingCharacters'ın V2 yaklaşımı doğru kayan pencere modelidir. İlk sürüm duplicate görünce tüm pencereyi sıfırladığı için bazı örnekleri kaçırır.
- MaximumSubarray, ThreeSum ve TaskScheduler şu an iskelet/eksik durumunda. Bu notlardaki patternlerle tamamlamak iyi bir OA alıştırması olur.
