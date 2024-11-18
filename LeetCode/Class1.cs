using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Daily
{
    public class KthLargest
    {
        private PriorityQueue<int, int> _data;
        private int _k;

        public KthLargest(int k, int[] nums)
        {
            _k = k;
            _data = new PriorityQueue<int, int>();
            foreach (var item in nums) {
                _data.Enqueue(item, item);
            }

            while (_data.Count > k)
            {
                _data.Dequeue();
            }
        }

        public int Add(int val)
        {
            if (_data.TryPeek(out _, out var first) && first >= val)
                return first;

            _data.Enqueue(val, val);
            if (_data.Count > _k)
            {
                _data.Dequeue();
            }

            var a = _data.Peek();

            return a;
        }
    }

    public class Solution
    {
        public int LargestCombination(int[] candidates)
        {
            //max value is 10.000.000. Size is 24 bits
            var max = 0;
            
            for (var i = 0; i < 24; i++)
            {
                max = Math.Max(candidates.Count(x => (x & (1 << i)) != 0), max);
            }

            return max;
        }

        public int MaxSubArray(int[] nums)
        {
            var left = 0;
            var right = 0;

            var result = nums[0];
            var subarraySum = 0;

            while (right < nums.Length)
            {
                while (left < right && subarraySum < 0)
                {
                    subarraySum -= nums[left];
                    left++;
                }

                subarraySum += nums[right];
                result = Math.Max(result, subarraySum);

                right++;
            }

            return result;
        }

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
                    return mid;
            }

            return -1;
        }

        public long MinEnd(int n, int x)
        {
            //X should be the first item, otherwise we will never get back to X
            long result = x;
            long originalX = x;
            for (var i = 0; i < n - 1; i++)
            {
                //increment
                result++;
                //apply mask
                result |= originalX;
            }

            return result;
        }

        public int Reverse(int x)
        {
            var isNegative = x < 0;
            if (isNegative)
            {
                x *= -1;
            }
            
            var digits = new List<byte>(10);
            while (x != 0)
            {
                digits.Add((byte)(x % 10));
                x /= 10;
            }

            long result = 0;
            foreach (int digit in digits)
            {
                result = result * 10 + digit;
                if (result > int.MaxValue)
                    return 0;
            }

            return isNegative
                ? (int)result * -1
                : (int)result;
        }

        public int MinimizedMaximum(int n, int[] quantities)
        {
            Array.Sort(quantities);

            if (quantities.Length == n)
                return quantities[^1];

            var totalNumberOfProducts = quantities.Sum();

            var result = 0;
            foreach (var item in quantities)
            {
                int equalPart = totalNumberOfProducts / n;
                if (equalPart <= item / 2)
                {
                    n -= 2;
                    result = Math.Max(result, item - equalPart);
                }
                else
                {
                    result = Math.Max(result, item);
                    n--;
                }

                totalNumberOfProducts -= item;
            }

            return result;
        }
        public int FindLengthOfShortestSubarray(int[] arr)
        {
            //subarray can be in 3 positions: prefix, postfix, middle
            var arrayLength = arr.Length;
            if (arrayLength == 1)
                return 0;

            //calculate left part. It will point to last item before postfix
            var left = 0;
            while (left + 1 < arrayLength && arr[left] <= arr[left + 1])
            {
                left++;
            }

            //array already sorted
            if (left == arrayLength - 1)
                return 0;

            //calculate right part. It will point to the first item after prefix
            var right = arrayLength - 1;
            while (right >= 1 && arr[right - 1] <= arr[right])
            {
                right--;
            }

            //length of postfix: arrayLength - left - 1
            //length of prefix: right
            //chose the minimum between prefix and postfix
            var result = Math.Min(arrayLength - left - 1, right);

            int i = 0, j = right;
            while (i <= left && j <= arrayLength - 1)
            {
                if (arr[i] <= arr[j])
                {
                    result = Math.Min(result, j - i - 1);
                    i++;
                }
                else
                {
                    j++;
                }
            }
            
            return result;
        }

        public int MinimumSubarrayLength(int[] nums, int k)
        {
            var subarrayResult = 0;
            var subarrayLength = 0;

            var result = -1;
            for (var leftPointer = 0; leftPointer < nums.Length; leftPointer++)
            {
                if (nums[leftPointer] >= k)
                    return 1;

                subarrayResult |= nums[leftPointer];
                subarrayLength++;

                if (subarrayResult < k) 
                    continue;

                //we found a subarray that satisfies the requirements.
                //now we need to compress it, if possible, so that it has a minimum length
                subarrayResult = 0;
                subarrayLength = 0;
                while (subarrayResult < k)
                {
                    subarrayResult |= nums[leftPointer - subarrayLength];
                    subarrayLength++;
                }

                //update result
                result = result == -1 
                    ? subarrayLength
                    : Math.Min(subarrayLength, result);

                //update the left pointer to the next item after the first item in the subarray so we can continue searching
                if (leftPointer != nums.Length - 1)
                    leftPointer = leftPointer - subarrayLength + 1;
                subarrayResult = 0;
                subarrayLength = 0;
            }

            return result;
        }


        public int MaxProfitAssignment2(int[] difficulty, int[] profit, int[] worker)
        {
            var items = profit
                .Select((profit, index) => (Element: (Difficulty: difficulty[index], Profit: profit), Priority: profit * -1));

            var jobs = new PriorityQueue<(int Difficulty, int Profit), int>(items);
            
            var result = 0;
            while (jobs.Count > 0)
            {
                var job = jobs.Dequeue();
                for (var j = 0; j < worker.Length; j++)
                {
                    if (worker[j] == -1 || worker[j] < job.Difficulty)
                        continue;

                    worker[j] = -1;
                    result += job.Profit;
                }
            }

            return result;
        }

        public int MaxProfitAssignment(int[] difficulty, int[] profit, int[] workers)
        {
            Array.Sort(profit, difficulty);
            Array.Sort(workers);

            var result = 0;
            var workersRight = workers.Length - 1;
            Array.Sort(workers);
            for (var i = profit.Length - 1; i >= 0; i--)
            {
                for (var j = workersRight; j >= 0; j--)
                {
                    if (workers[j] < difficulty[i])
                        break;

                    workersRight--;
                    result += profit[i];
                }
            }

            return result;
        }

        public bool JudgeSquareSum(int c)
        {
            var a = (int)Math.Sqrt(c);
            var aSquare = a * a;

            //if a^2 == c, then b = 0
            if (aSquare == c)
                return true;

            while (a > 0)
            {
                var b = (int)Math.Sqrt(c - aSquare);
                if (aSquare + b*b == c)
                    return true;

                a--;
                aSquare = a*a;
            }

            return false;
        }

        public int[] GetMaximumXor(int[] nums, int maximumBit)
        {
            var xor = nums[0];
            var maxK = (int)Math.Pow(2, maximumBit) - 1;
            for (var i = 1; i < nums.Length; i++)
            {
                xor ^= nums[i];
            }

            var result = new int[nums.Length];
            for (var i = nums.Length - 1; i >= 0; i--)
            {
                result[nums.Length - i - 1] = xor ^ maxK; 

                xor ^= nums[i];
            }

            return result;
        }



        public int[] ConstructRectangle(int area)
        {
            int start = (int)Math.Sqrt(area);
            for (var w = start; w >= 1; w--)
            {
                if (area % w == 0)
                    return new[] { area / w, w };
            }
            return new[] { area, 1 };
        }


        public bool CanSortArray(int[] nums)
        {
            var groups = new List<(int Min, int Max)>(nums.Length);

            var min = nums[0];
            var max = min;
            var prevNumberOfSetBits = int.PopCount(min);
            foreach (var num in nums)
            {
                var currentNumberOfSetBits = int.PopCount(num);
                if (currentNumberOfSetBits != prevNumberOfSetBits)
                {
                    groups.Add((min, max));
                    min = num;
                    max = num;
                }
                else
                {
                    min = Math.Min(min, num);
                    max = Math.Max(max, num);
                }

                prevNumberOfSetBits = currentNumberOfSetBits;
            }
            groups.Add((min, max));

            for (var i = 0; i < groups.Count - 1; i++)
            {
                if (groups[i].Max > groups[i + 1].Min)
                    return false;
            }

            return true;
        }

        public int[][] Construct2DArray(int[] original, int m, int n)
        {
            if (original.Length != m * n)
                return Array.Empty<int[]>();

            var result = new int[m][];
            var rowCounter = -1;
            for (var i = 0; i < original.Length; i++)
            {
                var columnIndex = i % n;
                if (columnIndex == 0)
                {
                    rowCounter++;
                    result[rowCounter] = new int[n];
                }

                result[rowCounter][columnIndex] = original[i];
            }

            return result;
        }

        public int ChalkReplacer(int[] chalk, int k)
        {
            long totalChalkForSingleLoop = 0;
            foreach (var chalkForStudent in chalk)
            {
                totalChalkForSingleLoop += chalkForStudent;
            }

            long numberOfFullLoops = (long)k / totalChalkForSingleLoop;

            long chalkLeft = k - (numberOfFullLoops * totalChalkForSingleLoop);
            for (var i = 0; i < chalk.Length; i++)
            {
                chalkLeft -= chalk[i];

                if (chalkLeft < 0)
                    return i;

                if (chalkLeft == 0)
                    return i + 1;
            }

            return 0;
        }

        public bool RotateString(string s, string goal)
        {
            if (s.Length != goal.Length)
                return false;

            return (s + s).Contains(goal);

            /*var sb = new StringBuilder(s);
            foreach (var c in s)
            {
                var shiftedString = sb.ToString();
                if (shiftedString == goal)
                    return true;

                sb.Clear();
                sb.Append($"{shiftedString.Substring(1, s.Length - 1)}{shiftedString.Substring(0,1)}");
            }

            return false;*/
        }
    }
}
