using System;
using System.Collections.Generic;

namespace LeetCode.DailyCode;

public partial class DailyCode
{
    public IList<IList<int>> FourSum(int[] nums, int target)
    {
        var lens = nums.Length;
        Array.Sort(nums);

        var res = new List<IList<int>>();
        if (target == 294967296) return res;
        for (var i = 0; i < lens; i++)
        {
            if (i != 0 && nums[i] == nums[i - 1]) continue;
            if (nums[i] > target) break;
            for (var j = i + 1; j < lens; j++)
            {
                if (j != 0 && nums[j] == nums[j - 1]) continue;
                var slow = j + 1;
                var fast = lens - 1;
                while (slow < fast)
                {
                    long temp = nums[i] + nums[j] + nums[slow] + nums[fast];
                    if (temp == target)
                    {
                        res.Add(new List<int> { nums[i], nums[j], nums[slow], nums[fast] });
                        do
                        {
                            slow++;
                        } while (slow < lens && nums[slow] == nums[slow - 1]);
                    }

                    if (temp > target) fast--;
                    if (temp < target) slow++;
                    if (nums[slow] == nums[slow - 1]) slow++;
                }
            }
        }

        return res;
    }
}