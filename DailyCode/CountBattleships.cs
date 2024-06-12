using System.Collections.Generic;

namespace LeetCode.DailyCode;

public partial class DailyCode
{
    public int CountBattleships(char[][] board)
    {
        int count = 0;
        int m = board.Length;
        int n = board[0].Length;
        for (var i = 0; i < m; i++)
        {
            for (var j = 0; j < n; j++)
            {
                if (i > 0 && board[i - 1][j] == 'X')
                {
                    continue;
                }

                if (j > 0 && board[i][j - 1] == 'X')
                {
                    continue;
                }

        
            }
        }

        return count;
    }
}