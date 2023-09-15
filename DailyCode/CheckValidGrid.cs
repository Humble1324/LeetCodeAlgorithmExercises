namespace LeetCode.DailyCode;

public partial class DailyCode
{
    // 骑士在一张 n x n 的棋盘上巡视。在有效的巡视方案中，骑士会从棋盘的 左上角 出发，并且访问棋盘上的每个格子 恰好一次 。
    // 给你一个 n x n 的整数矩阵 grid ，由范围 [0, n * n - 1] 内的不同整数组成，其中 grid[row][col] 表示单元格 (row, col) 是骑士访问的第 grid[row][col] 个单元格。骑士的行动是从下标 0 开始的。
    // 如果 grid 表示了骑士的有效巡视方案，返回 true；否则返回 false。
    // 注意，骑士行动时可以垂直移动两个格子且水平移动一个格子，或水平移动两个格子且垂直移动一个格子。下图展示了骑士从某个格子出发可能的八种行动路线。
    public bool CheckValidGrid(int[][] grid) //grid是nxn
    {
        if (grid[0][0] != 0) return false;
        var count = grid.Length * grid.Length;
        var n = grid.Length;
        var indices = new int[n * n][];
        for (var i = 0; i < n * n; i++) indices[i] = new int[2];

        for (var i = 0; i < n; i++)
        for (var j = 0; j < n; j++)
        {
            indices[grid[i][j]][0] = i;
            indices[grid[i][j]][1] = j;
        }

        var index = 1;
        while (index < count)
        {
            if ((indices[index][0] - indices[index - 1][0]) * (indices[index][0] - indices[index - 1][0]) +
                (indices[index][1] - indices[index - 1][1]) * (indices[index][1] - indices[index - 1][1]) != 5)
            {
                return false;
            }

            index++;
        }

        return true;
    }
}