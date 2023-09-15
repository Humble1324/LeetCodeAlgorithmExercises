using System;
using System.Collections.Generic;

namespace LeetCode.DailyCode;

public partial class DailyCode
{
    public IList<IList<int>> ThreeSum(int[] nums)
    {
        var sumsum = new List<IList<int>>();
        Array.Sort(nums);
        var lens = nums.Length;
        for (var i = 0; i < lens; i++)
        {
            if (nums[i] > 0) break;
            if (i > 0 && nums[i] == nums[i - 1]) continue;
            int slow = i + 1, fast = lens - 1;
            while (slow < fast)
            {
                var temp = nums[i] + nums[slow] + nums[fast];
                if (temp == 0)
                {
                    sumsum.Add(new List<int> { nums[i], nums[slow], nums[fast] });
                    while (slow < fast && nums[slow] == nums[slow + 1]) slow++;
                    while (slow < fast && nums[fast] == nums[fast - 1]) fast--;
                    fast--;
                    slow++;
                }
                else if (temp > 0)
                {
                    fast--;
                }
                else if (temp < 0)
                {
                    slow++;
                }
            }
        }

        return sumsum;
    }
}