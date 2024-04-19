using System;
using System.Collections.Generic;

namespace LeetCode.Solution;

public class DP
{
    public static int DeleteAndEarn(int[] nums)
    {
        Dictionary<int, int> Dic = new Dictionary<int, int>();
        foreach (var num in nums)
        {
            if (Dic.ContainsKey(num))
                Dic[num] += num;
            else
            {
                Dic.Add(num, num);
            }
        }

        int dp = 0;
        int downDown = 0;
        int down = 0;

        for (int i = 1; i < 10001; i++)
        {
            if (Dic.TryGetValue(i, out var value))
            {
                down = value;
                break;
            }
        }

        for (var i = 2; i <= Dic.Count; i++)
        {
            dp = Math.Max(down, downDown + Dic[i - 1]);
            downDown = down;
            down = dp;
        }

        return down;
    }

    public int Rob(int[] nums)
    {
        int lens = nums.Length;
        if (lens == 1)
        {
            return nums[0];
        }

        if (lens == 2)
        {
            return Math.Max(nums[0], nums[1]);
        }

        int dp = 0;
        int downDown = 0;
        int down = nums[0];
        for (int i = 2; i <= lens; i++)
        {
            dp = Math.Max(down, downDown + nums[i - 1]);
            downDown = down;
            down = dp;
            //不拿当前的拿上一格大还是拿前前格和这格大
        }

        return down;
    }

    public int Fib(int n)
    {
        int[] dp = new int[n + 1];
        dp[0] = 0;
        dp[1] = 1;
        if (n < 2) return n;
        for (int i = 2; i <= n; i++)
        {
            dp[i] = dp[i - 1] + dp[i - 2];
        }

        return dp[n];
    }

    public int MinCostClimbingStairs(int[] cost)
    {
        var lens = cost.Length;
        int down = 0;
        int downDown = 0;
        int dp = 0;
        for (int i = 2; i <= lens; i++)
        {
            dp = Math.Min(cost[i - 1] + down, cost[i - 2] + downDown);
            downDown = down;
            down = dp;
        }

        return dp;
    }

    public int ClimbStairs(int n)
    {
        if (n == 1) return 1;
        var dp = new int[n + 1];
        dp[1] = 1;
        dp[2] = 2;
        for (var i = 3; i <= n; i++)
        {
            dp[i] = dp[i - 2] + dp[i - 1];
        }

        return dp[n];
    }

    public int ClimbStairsII(int n)
    {
        if (n == 1) return 1;
        int downDown = 0, down = 0, cur = 1;
        for (var i = 1; i <= n; i++)
        {
            downDown = down;
            down = cur;
            cur = downDown + down;
        }

        return cur;
    }

    // static void Main()
    // {
    //     Console.WriteLine(DeleteAndEarn(new[] { 3, 4, 2 }));
    // }
}