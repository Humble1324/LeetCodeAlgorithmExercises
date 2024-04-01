using System;

namespace LeetCode.DailyCode;

public partial class DailyCode
{
    public static bool ValidPartition(int[] nums) {
        //dp1：前两个相等
        //dp2: 前三个相等或前三个差值为1

        var lens = nums.Length;
        var dp = new bool[lens + 1];
        dp[0] = true;
        for (var i = 1; i <= lens; i++)
        {
            if (i >= 2)
            {
                dp[i] = dp[i - 2] && ValidTwo(nums[i - 2], nums[i - 1]);
            }

            if (i >= 3)
            {
                dp[i] = dp[i] || (dp[i - 3] || ValidThree(nums[i - 3], nums[i - 2], nums[i - 1]));
            }
            //当前往前的数组是否合理
            Console.WriteLine($"\t i:{i},dp[i]:{dp[i]} ");

        }

        return dp[lens];

    }

    public static bool ValidTwo(int a, int b)
    {
        return a==b;
    }

    public static bool ValidThree(int num1, int num2, int num3)
    {
        return (num1==num2&&num2==num3||num1+1==num2&&num2+1==num3);
    }
     // public static void Main()
     // {
     //     ValidPartition(new int[] { 4,4,4,5,6 });
     // }
}