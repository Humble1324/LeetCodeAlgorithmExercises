using System.Collections.Generic;
using System;


    
    public partial class DailyCode
    {
        public int[] TwoSum(int[] nums, int target)
        {
            Dictionary<int, int> hashSum = new Dictionary<int, int>();
            int lens = nums.Length;
            for (int i = 0; i < lens; i++)
            {
                if (!hashSum.ContainsKey(nums[i]))
                {
                    hashSum.TryAdd(target - nums[i], i);
                }
                else
                {
                    return new int[] { hashSum[nums[i]], i };
                }
            }

            return null;
        }


    }
    