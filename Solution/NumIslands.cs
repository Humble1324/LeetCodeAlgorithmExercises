using System;
using System.Collections.Generic;

namespace LeetCode.Solution;

public partial class Solution
{
    int count = 0;

    public int NumIslands(char[][] grid)
    {
        var m = grid.Length;
        var n = grid[0].Length;
        for (var i = 0; i < m; i++)
        {
            for (var j = 0; j < n; j++)
            {
                if (grid[i][j] == '1')
                {
                    DfsIslands(grid, i, j);
                    count++;
                }
            }
        }

        return count;
    }

    public void DfsIslands(char[][] grid, int m, int n)
    {
        if (m >= grid.Length || m < 0 || n >= grid[0].Length || n < 0) return;
        if (grid[m][n] != '1') return;
        grid[m][n] = '2';
        DfsIslands(grid, m + 1, n);
        DfsIslands(grid, m - 1, n);
        DfsIslands(grid, m, n + 1);
        DfsIslands(grid, m, n - 1);

        return;
    }

}