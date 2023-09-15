using System;
using System.Linq;

namespace LeetCode.DailyCode;

public partial class DailyCode
{
    public int MinFallingPathSum(int[][] matrix)
    {
        var lens = matrix.Length;
        var dp = new int[lens][];
        for (var i = 0; i < lens; i++) dp[i] = new int[lens];
        Array.Copy(matrix, 0, dp, 0, lens); //复制数组

        for (var i = 1; i < lens; i++)
        for (var j = 0; j < lens; j++)
        {
            var temp = matrix[i - 1][j];
            if (j > 0) //作为第一排则不执行
                temp = Math.Min(temp, matrix[i - 1][j + 1]);

            if (j < lens - 1) //其余皆执行两个if ，保证三选一
                temp = Math.Min(temp, matrix[i - 1][j - 1]);

            dp[i][j] = temp + matrix[i][j];
        }


        return dp[lens - 1].Min();
    }
}