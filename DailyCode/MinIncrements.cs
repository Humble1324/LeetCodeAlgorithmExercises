using System;

namespace LeetCode.DailyCode;

public partial class DailyCode
{
    public int MinIncrements(int n, int[] cost)
    {
        //自下而上，两两比对，差值求和
        int sum = 0;
        for (int i = n - 2; i > 0; i -= 2)
        {
            sum += Math.Abs(cost[i] - cost[i + 1]);

            cost[i / 2] += Math.Max(cost[i], cost[i + 1]);
        }

        return sum;
    }
}