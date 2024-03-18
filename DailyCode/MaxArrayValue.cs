using System;
using System.Collections.Generic;

namespace LeetCode.DailyCode;

public partial class DailyCode
{
    public long MaxArrayValue(int[] nums)
    {
        int lens = nums.Length;
        //dp[i] = nums[i]>=nums[i-1]?dp[i+1]+nums[i]:nums[i];
        List<long> dp = new List<long>(lens);
        dp[lens - 1] = nums[lens - 1];
        long temp = nums[lens - 1];
        for (var i = lens-2; i>=0; i--)
        {
            dp[i] = nums[i+1] >= nums[i] ? dp[i + 1] + nums[i] : nums[i];
            temp = Math.Max(dp[i], temp);
        }
        return temp;
    }
}