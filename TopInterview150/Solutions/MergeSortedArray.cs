public class MergeSortedArray
{
    public static void Merge(int[] nums1, int m, int[] nums2, int n)
    {
        // nums1'in sonunda birleştirme işlemini yapacağımız yerin başlangıç indeksi
        int nums1Index = m - 1;

        // nums2'nin son elemanını gösteren indeks
        int nums2Index = n - 1;

        // nums1 dizisinin sonundan itibaren elemanların yerleştirileceği indeks
        int mergeIndex = m + n - 1;

        // nums2'de eleman kaldığı sürece döngü devam eder
        while (nums2Index >= 0)
        {
            // nums1'de hala eleman varsa ve nums1'in mevcut elemanı nums2'ninkinden büyükse
            if (nums1Index >= 0 && nums1[nums1Index] > nums2[nums2Index])
            {
                // nums1'in büyük olan elemanını en son boş yere yerleştir
                nums1[mergeIndex] = nums1[nums1Index];
                // nums1'deki bir önceki elemana geç
                nums1Index--;
            }
            else
            {
                // Aksi takdirde, nums2'nin elemanını en son boş yere yerleştir
                nums1[mergeIndex] = nums2[nums2Index];
                // nums2'deki bir önceki elemana geç
                nums2Index--;
            }

            // Birleştirme indeksini bir azalt (yukarıdaki işlemlerden sonra bir adım geri git)
            mergeIndex--;
        }
    }
}

// public void Merge(int[] nums1, int m, int[] nums2, int n) 
// {
//        int p1 = m-1;
//        int p2 = n-1;
//        int i = m+n-1;

//        while(p2>=0)
//        {
//            if(p1 >=0 && nums1[p1] > nums2[p2])
//                nums1[i--] = nums1[p1--];
//            else
//               nums1[i--]= nums2[p2--];
//        }
// }