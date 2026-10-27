public class MergeSortedArray2
{
    public void Merge(int[] nums1, int m, int[] nums2, int n)
    {
        // nums1 = [1,2,3,0,0,0], m = 3, nums2 = [2,5,6], n = 3

        int num1Last = m - 1; // last valid num1 item
        int num2Last = n - 1; // last valid num2 item
        int mergeIndex = m + n - 1; // last index of num1

        while (num2Last >= 0)
        {
            if (num1Last >= 0 && nums1[num1Last] > nums2[num2Last])
            {
                nums1[mergeIndex] = nums1[num1Last];
                num1Last--;
            }
            else
            {
                nums1[mergeIndex] = nums2[num2Last];
                num2Last--;
            }

            mergeIndex--;
        }
    }

    public void Merge2(int[] nums1, int m, int[] nums2, int n)
    {
        int nums1Right = m - 1;
        int nums2Right = n - 1;
        int mergeIndex = nums1.Length - 1;

        while (nums2Right >= 0)
        {
            if (nums1Right >= 0 && nums1[nums1Right] > nums2[nums2Right])
            {
                nums1[mergeIndex] = nums1[nums1Right];
                nums1Right--;
            }
            else
            {
                nums1[mergeIndex] = nums2[nums2Right];
                nums2Right--;
            }

            mergeIndex--;
        }
    }
}