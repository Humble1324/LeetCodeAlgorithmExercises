using System;

namespace LeetCode.DailyCode;

public partial class DailyCode

{
    public int CoinChange(int[] coins, int amount)
    {
        int[] dp = new int[amount + 1];
        Array.Fill(dp, amount + 1);
        //填充一个一样多的dp数组，并且各个的情况默认为全是1，即最大值
        dp[0] = 0; //防止越界
        for (int i = 1; i <= amount; i++) //由最小金币数往大遍历
        {
            foreach (var coin in coins) //在每个金额都寻找当前最小的金币数
            {
                if (coin <= i)
                {
                    dp[i] = Math.Min(dp[i], dp[i - coin] + 1);
                    //当前金额的最小金币数为当前金额减去当前金币数的最小金币数+1
                    //即之前情况下的最优加上现在的最大值最优的情况
                }
            }
        }

        return dp[amount] > amount ? -1 : dp[amount];
    }

    public int Change(int amount, int[] coins)
    {
        //每个小的数字都等于最小的开始每个最多情况
        int[] dp = new int[amount + 1];
        Array.Fill(dp, 0);
        dp[0] = 1;
        foreach (var coin in coins) //由最小金币数往大遍历
        {
            for (int i = coin; i <= amount; i++)
                //在每个金额都寻找当前最小的金币数
            {
                if (coin <= i)
                {
                    dp[i] += dp[i - coin];
                    //当前金额的最小金币数为当前金额减去当前金币数的最小金币数+1
                    //即之前情况下的最优加上现在的最大值最优的情况
                }
            }
        }


        return dp[amount];
    }
}