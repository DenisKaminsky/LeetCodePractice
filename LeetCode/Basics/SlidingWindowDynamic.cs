namespace LeetCode.Basics
{
    public class SlidingWindowDynamic
    {
        public int MaxSubArray(int[] nums)
        {
            var left = 0;
            var right = 0;

            var result = nums[0];
            var subSum = 0;
            while (right < nums.Length)
            {
                while (left < right && subSum < 0)
                {
                    subSum -= nums[left];
                    left++;
                }

                subSum += nums[right];
                result = Math.Max(result, subSum);

                right++;
            }

            return result;
        }

        public int[] SubarraySum(int[] arr, long target)
        {
            var left = 0;
            var right = 0;

            long subSum = 0;
            while (right < arr.Length)
            {
                subSum += arr[right];

                while (left < right && subSum > target)
                {
                    subSum -= arr[left];
                    left++;
                }

                if (subSum == target)
                    return [left + 1, right + 1];

                right++;
            }

            return [-1];
        }
    }
}
