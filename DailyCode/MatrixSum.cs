using System;

namespace LeetCode.DailyCode;

public partial class DailyCode
{
    public int MatrixSum(int[][] nums)
    {
        var columnlens = nums[0].Length;
        var rowlens = nums.Length;
        int sum = 0, tempMax = 0;
        foreach (var rownum in nums) Array.Sort(rownum);

        for (var i = 0; i < columnlens; i++)
        {
            for (var j = 0; j < rowlens; j++)
                if (nums[j][i] >= tempMax)
                    tempMax = nums[j][i];

            sum += tempMax;
        }

        return sum;
    }
}