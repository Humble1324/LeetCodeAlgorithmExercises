﻿using System;
using System.Collections.Generic;

namespace LeetCode.Solution;

public class DP
{
    //自上而下
    public int CombinationSum4(int[] nums, int target)
    {
        int[] dp = new int[target + 1];

        dp[0] = 1;
        for (int i = 1; i <= target; i++)
        {
            foreach (var num in nums)
            {
                if (num <= i)
                {
                    dp[i] += dp[i - num];
                }
            }
        }

        return dp[target];
    }

    //自下而上
    public int CombinationSum4II(int[] nums, int target)
    {
        int[] memo = new int[target + 1];
        Array.Fill(memo, -1);
        return CombinationDfs(target, nums, memo);
    }

    public int CombinationDfs(int i, int[] nums, int[] memo)
    {
        //遍历到最底
        if (i == 0)
        {
            return 1;
        }

        //如果当前情况已知，就直接返回
        if (memo[i] != -1)
        {
            return memo[i];
        }

        //当前结果没出现过，遍历并记录
        int res = 0;
        for (var i1 = 0; i1 < nums.Length; i1++)
        {
            if (nums[i1] <= i)
            {
                res += CombinationDfs(i - i1, nums, memo);
            }
        }

        return memo[i] = res;
    }

    public static int DeleteAndEarn(int[] nums)
    {
        Array.Sort(nums);
        Dictionary<int, int> Dic = new Dictionary<int, int>();
        Dic.Add(nums[0], 1);
        List<int> arr = new();
        for (int i = 1; i < nums.Length; i++)
        {
            Dic.TryAdd(nums[i], 0);
            Dic[nums[i]]++;
            if (Dic[nums[i]] == 1)
            {
                arr.Add(nums[i]);
            }
        }

        int[] dp = new int[arr.Count + 1];
        dp[1] = arr[0] * Dic[arr[0]];
        for (int i = 2; i <= arr.Count; i++)
        {
            int cur = arr[i - 1];
            if (cur == arr[i - 2] + 1)
            {
                dp[i] = Math.Max(dp[i - 1], dp[i - 2] + cur * Dic[cur]);
            }
            else
            {
                dp[i] = dp[i - 1] + cur * Dic[cur];
            }
        }

        return dp[arr.Count];
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