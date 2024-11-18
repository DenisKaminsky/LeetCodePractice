namespace LeetCode.Basics
{
    public class BinarySearch
    {
        public int Search(int target, int[] array)
        {
            var left = 0;
            var right = array.Length - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (target < array[mid])
                {
                    right = mid - 1;
                }
                else if (target > array[mid])
                {
                    left = mid + 1;
                }
                else
                {
                    return mid;
                }
            }

            return -1;
        }
    }
}
