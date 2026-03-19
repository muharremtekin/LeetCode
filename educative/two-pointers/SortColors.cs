public sealed class SortColorsProblem
{
    // https://www.educative.io/interview-prep/coding/sort-colors
    public void SortColors(int[] colors)
    {
        int low = 0;
        int mid = 0;
        int high = colors.Length - 1;

        // mid işaretçisi, high işaretçisini geçene kadar devam et
        while (mid <= high)
        {
            if (colors[mid] == 0)
            {
                // 0 gördük: low ile yer değiştir, ikisini de ilerlet
                Swap(colors, low, mid);
                low++;
                mid++;
            }
            else if (colors[mid] == 1)
            {
                // 1 gördük: yeri doğru, sadece mid'i ilerlet
                mid++;
            }
            else if (colors[mid] == 2)
            {
                // 2 gördük: high ile yer değiştir, SADECE high'ı gerilet.
                // mid'i artırmıyoruz çünkü yeni gelen sayıyı da kontrol etmeliyiz.
                Swap(colors, mid, high);
                high--;
            }
        }
    }

    // Yardımcı yer değiştirme metodu
    private void Swap(int[] arr, int i, int j)
    {
        int temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp;
    }
}