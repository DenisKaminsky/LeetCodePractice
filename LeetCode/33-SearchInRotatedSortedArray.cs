namespace LeetCode.Task33
{
    public class SearchInRotatedSortedArray
    {
        public int Search(int[] nums, int target)
        {
            var numsSize = nums.Length;
            //find K
            var minItemIndex = 0;
            for (var i = numsSize - 1; i > 0; i--)
            {
                if (nums[i - 1] > nums[i])
                {
                    minItemIndex = i;
                    break;
                }
            }
            var k = minItemIndex == 0 ? 0 : numsSize - minItemIndex;

            //binary search
            var left = 0;
            var right = numsSize - 1;
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                int shiftedMid = (numsSize - k + mid) % numsSize;

                if (target > nums[shiftedMid])
                    left = mid + 1;
                else if (target < nums[shiftedMid])
                    right = mid - 1;
                else
                    return shiftedMid;
            }

            return -1;
        }
    }
}
