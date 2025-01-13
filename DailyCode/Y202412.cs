using System;
using System.Linq;

namespace LeetCode.DailyCode;

public class Y202412
{
    public int NumRookCaptures(char[][] board)
    {
        int cnt = 0, st = 0, ed = 0;
        int x = -1, y = -1;
        int[] dx = { 0, 1, 0, -1 };
        int[] dy = { 1, 0, -1, 0 };
        for (var i = 0; i < board.Length; i++)
        {
            for (var j = 0; j < board[i].Length; j++)
            {
                if (board[i][j] == 'R')
                {
                    x = i;
                    y = j;
                    break;
                }
            }
        }
        for (int i = 0; i < 4; i++) {
            for (int step = 0; ; step++) {
                int tx = st + step * dx[i];
                int ty = ed + step * dy[i];
                if (tx < 0 || tx >= 8 || ty < 0 || ty >= 8 || board[tx][ty] == 'B') {
                    break;
                }
                if (board[tx][ty] == 'p') {
                    cnt++;
                    break;
                }
            }
        }
        return cnt;

    }
    public bool SquareIsWhite(string coordinates)
    {
        int x = coordinates[0] - 'a';
        int y = (int)coordinates[1];
        return x % 2 != y % 2;
    }
    public int[] ConstructTransformedArray(int[] nums)
    {
        int[] result = new int[nums.Length];
        for (var i = 0; i < nums.Length; i++)
        {
            if (nums[i] != 0)
            {
                result[i] =nums[CycleNumsIndex(nums,i,nums[i])];
            }
            else
            {
                result[i] = nums[i];
            }
        }

        return result;
    }

    private int CycleNumsIndex(int[] nums, int index, int step)
    {
        int lens = nums.Length;
        return (index + step % lens  + lens) % lens;
    }
    // public bool IsSubstringPresent(string s)
    // {
    //     var temp = Array.Reverse(s);
    //     for (var i = 0; i < s.Length-1; i++)
    //     {
    //         
    //     }
    // }
}