public class ContainerWithMostWater
{

    public static int Solution(int[] height)
    {
        int maxArea = 0;
        int left = 0;
        int right = height.Length - 1;

        while (left < right)
        {
            int area = Math.Min(height[left], height[right]) * (right - left);
            maxArea = Math.Max(maxArea, area);

            if (height[left] < height[right])
                left++;
            else
                right--;
        }

        return maxArea;
    }
}