using System;
using System.Collections.Generic;

namespace LeetCode.DailyCode;

public class Y202503
{
    public int RobNew(int[] nums)
    {
        int lens = nums.Length;
        // 特殊情况处理：只有一个房子时直接返回
        if (lens == 1)
        {
            return nums[0];
        }

        // 特殊情况处理：只有两个房子时返回较大的值
        if (lens == 2)
        {
            return Math.Max(nums[0], nums[1]);
        }

        // 创建动态规划数组，dp[i,0]表示不偷第i个房子的最大金额
        // dp[i,1]表示偷第i个房子的最大金额
        int[,] dp = new int[lens, 2];
        // 初始化：不偷第一个房子
        dp[0, 0] = 0;
        // 初始化：偷第一个房子
        dp[0, 1] = nums[0];
        // 动态规划过程
        for (int i = 1; i < lens; i++)
        {
            // 不偷当前房子时，最大金额为前一个房子偷或不偷的最大值
            dp[i, 0] = Math.Max(dp[i - 1, 0], dp[i - 1, 1]);
            // 偷当前房子时，只能加上不偷前一个房子的金额
            dp[i, 1] = nums[i] + dp[i - 1, 0];
        }

        // 返回最后一个房子偷或不偷的最大值
        return Math.Max(dp[lens - 1, 0], dp[lens - 1, 1]);
    }
    public int DivisorSubstrings(int num, int k)
    {
        int ans = 0;
        string s = num.ToString();
        for (var i = 0; i <= s.Length - k;i++)
        {
            int t = int.Parse(s.Substring(i, k));
            if (t != 0 && num % t == 0)
            {
                ans++;
            }
        }
        return ans;
    }
    public static int SumOfBeauties(int[] nums)
    {
        //如果前面所有的都小于他,后面所有都大于他 返回2
        //如果第一条不满足 再判断如果i-1<i<i+1 返回1
        //都不满足返回0
        int lens = nums.Length;
        int[] leftMax = new int[lens];
        int[] rightMin = new int[lens];
        leftMax[0] = nums[0];
        rightMin[lens - 1] = nums[lens - 1];

        int ans = 0;
        for (var i = 1; i < lens ; i++)
        {
            leftMax[i] = Math.Max(leftMax[i - 1], nums[i]);
        }

        for (var i = lens - 2; i >= 0; i--)
        {
            
            rightMin[i] = Math.Min(rightMin[i + 1], nums[i]);
        }

        for (var i = 1; i < lens - 1; i++)
        {
            if (nums[i] > leftMax[i-1] && nums[i] < rightMin[i+1])
            {
                ans += 2;
            }
            else if (nums[i] > nums[i - 1] && nums[i]< nums[i + 1])
            {
                ans++;
            }
        }

        return ans;
    }
}