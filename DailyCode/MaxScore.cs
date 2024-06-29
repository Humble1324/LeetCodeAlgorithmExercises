using System;

namespace LeetCode.DailyCode;

public partial class DailyCode
{
    public long MaxScore(int[] nums, int x)
    { 
        //在下标 [1,n−1] 中选一个子序列，
        //其第一个数的奇偶性与 nums[0] 相同（偶数）。
        
        // 在下标 [1,n−1][ 中选一个子序列，
        // 其第一个数的奇偶性与nums[0] 不同（奇数）。

        long res = nums[0];
        long[] dp = { int.MinValue, int.MinValue };
        dp[nums[0] % 2] = nums[0]; //第一个值的奇偶性
        for (int i = 1; i < nums.Length; i++)
        {
            int parity = (int)(nums[i] % 2); 
            //0或者1

            long cur = Math.Max(dp[parity] + nums[i], dp[1 - parity] - x + nums[i]);
            //计算是换收益高还是继续收益高,状态转移方程
            
            res = Math.Max(res, cur);
            //更新结果
            
            dp[parity] = Math.Max(dp[parity], cur);
            //更新当前奇偶收益?
        }

        return res;
    }
}