/*
 * ÇÖZÜM AÇIKLAMASI
 * ================
 *
 * Neden iki veri yapısı?
 * - List: O(1) random erişim (index ile) ama O(n) arama
 * - Dictionary: O(1) arama ama random erişim yok
 * - İkisini birleştirerek her işlemi O(1) yapıyoruz
 *
 * _indexMap ne işe yarıyor?
 * -------------------------
 * Bir değerin list'te nerede olduğunu O(1)'de bulmamızı sağlıyor.
 *
 * _list:     [10, 20, 30, 40]
 * index:      0   1   2   3
 * _indexMap: {10→0, 20→1, 30→2, 40→3}
 *
 * Remove'daki Swap Trick'i
 * ------------------------
 * List'in ortasından silmek O(n) çünkü elemanlar kaydırılır.
 * Ama sondan silmek O(1).
 *
 * 20'yi silmek istiyoruz:
 *
 * Önce: _list: [10, 20, 30, 40]
 *
 * 1. Son elemanı (40) silinecek yere koy: [10, 40, 30, 40]
 * 2. _indexMap'te 40'ın yeni index'ini güncelle
 * 3. Son elemanı sil: [10, 40, 30]
 * 4. 20'yi _indexMap'ten sil
 *
 * Sonuç: _list: [10, 40, 30], _indexMap: {10→0, 40→1, 30→2}
 */
public class RandomizedSet
{
    private List<int> _list;
    private Dictionary<int, int> _indexMap; // değer -> list'teki index
    private Random _random;

    public RandomizedSet()
    {
        _list = new();
        _indexMap = new();
        _random = new();
    }

    public bool Insert(int val)
    {
        if (_indexMap.ContainsKey(val))
            return false;

        _indexMap[val] = _list.Count;
        _list.Add(val);
        return true;
    }

    public bool Remove(int val)
    {
        if (!_indexMap.ContainsKey(val))
            return false;

        int index = _indexMap[val];
        int lastVal = _list[^1];

        _list[index] = lastVal;
        _indexMap[lastVal] = index;

        _list.RemoveAt(_list.Count - 1);
        _indexMap.Remove(val);

        return true;
    }

    public int GetRandom()
    {
        int index = _random.Next(0, _list.Count);
        return _list[index];
    }
}