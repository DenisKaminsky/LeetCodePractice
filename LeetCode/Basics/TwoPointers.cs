using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Basics
{
    public class TwoPointers
    {
        public int[] TwoSum(int[] numbers, int target)
        {
            var left = 0;
            var right = numbers.Length - 1;
            while (left < right)
            {
                var sum = numbers[left] + numbers[right];
                if (sum == target)
                    return new int[] { left + 1, right + 1 };
                else if (sum < target)
                    left++;
                else
                    right--;
            }

            return Array.Empty<int>();
        }

        public IList<IList<int>> ThreeSum(int[] nums)
        {
            Array.Sort(nums);

            var result = new List<IList<int>>();
            for (var i = 0; i < nums.Length; i++)
            {
                var first = nums[i];

                if (i > 0 && first == nums[i - 1])
                    continue;

                var left = i + 1;
                var right = nums.Length - 1;
                while (left < right)
                {
                    var sum = first + nums[left] + nums[right];

                    if (sum > 0)
                        right--;
                    else if (sum < 0)
                        left++;
                    else
                    {
                        result.Add(new List<int> { first, nums[left], nums[right] });
                        left++;
                        while (nums[left] == nums[left - 1] && left < right)
                        {
                            left++;
                        }
                    }
                }
            }

            return result;
        }
    }
}
