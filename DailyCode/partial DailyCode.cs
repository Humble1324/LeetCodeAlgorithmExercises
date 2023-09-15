using System;

namespace LeetCode.DailyCode;

public partial class  DailyCode
{
    public int GiveGem(int[] gem, int[][] operations)
    {
        foreach (var operation in operations)
        {
            gem = Operation(gem, operation[0], operation[1]);
            // gem[operation[1]] += gem[operation[0]] / 2;
            // gem[operation[0]] -= gem[operation[0]] / 2;
        }

        int min = Int32.MaxValue;
        int max = Int32.MinValue;
        for (int i = 0; i < gem.Length; i++)
        {
            if (gem[i] < min) min = gem[i];
            if (gem[i] > max) max = gem[i];
        }

        return max - min;
    }

    public int[] Operation(int[] gem ,int x,int y)
    {
        gem[y] += gem[x] / 2;
        gem[x] -= gem[x] / 2;
        return gem;
    }
}