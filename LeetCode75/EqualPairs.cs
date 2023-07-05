using System;
using System.Collections.Generic;

namespace LeetCode;

public partial class LeetCode75
{
    /*
    给你一个下标从 0 开始、大小为 n x n 的整数矩阵 grid ，返回满足 Ri 行和 Cj 列相等的行列对 (Ri, Cj) 的数目。
    
    如果行和列以相同的顺序包含相同的元素（即相等的数组），则认为二者是相等的。
    */
    public static int EqualPairs(int[][] grid)
    {
        int lens = grid[0].Length;
        if (lens == 1) return 1;
        int sum = 0;
        Dictionary<string, int> rows = new();
        int[][] columns = new int[lens][];
        for (int i = 0; i < lens; i++)
        { 
            columns[i] = new int[lens];
            for (int j = 0; j < lens; j++)
            {
                columns[i][j] =grid[j][i];
            }
        }

        for (int i = 0; i < lens; i++)
        {
            if (rows.ContainsKey(string.Join(",", grid[i])))
            {
                rows[string.Join(",", grid[i])]++;
            }
            else
            {
                rows.Add(string.Join(",",grid[i]),1);
            }
        }

        for (int j = 0; j < columns[0].Length; j++)
        {
            if (rows.ContainsKey(string.Join(",",columns[j])))
                sum+=rows[string.Join(",",columns[j])];
        }



        return sum;
    }

    // public static void Main()
    // {
    //     Console.Write(EqualPairs(new int[][]
    //     {
    //         new int[] { 11,1}, new int[] {1,11}
    //     }));
    // }
}