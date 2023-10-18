using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.DailyCode;

public partial class DailyCode
{
    public int SumIndicesWithKSetBits(IList<int> nums, int k)
    {
        var lens = nums.Count;
        var sum = 0;
        for(var i = 0; i < lens; i++)
        {
            if (Convert.ToString(i, 2).Count(c => c == '1') == k)
            {
                sum += nums[i];
            };
        }
        return sum;
    }
}