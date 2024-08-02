using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.DailyCode;

public class Y202408
{
    public int MaxmiumScore(int[] cards, int cnt)
    {
        Array.Sort(cards);

        int ans = 0;
        int tmp = 0;
        int odd = -1, even = -1;
        int end = cards.Length - cnt;
        for (int i = cards.Length - 1; i >= end; i--)
        {
            tmp += cards[i];
            if ((cards[i] & 1) != 0)
            {
                odd = cards[i];
            }
            else
            {
                even = cards[i];
            }
        }

        if ((tmp & 1) == 0)
        {
            return tmp;
        }

        for (int i = cards.Length - cnt - 1; i >= 0; i--)
        {
            if ((cards[i] & 1) != 0)
            {
                if (even != -1)
                {
                    ans = Math.Max(ans, tmp - even + cards[i]);
                    break;
                }
            }
        }

        for (int i = cards.Length - cnt - 1; i >= 0; i--)
        {
            if ((cards[i] & 1) == 0)
            {
                if (odd != -1)
                {
                    ans = Math.Max(ans, tmp - odd + cards[i]);
                    break;
                }
            }
        }

        return ans;
    }

    public static long NumberOfRightTriangles(int[][] grid)
    {
        int m = grid.Length;
        int n = grid[0].Length;
        int[] col = new int[n];
        long ans = 0;
        for (var i = 0; i < m; i++)
        {
            for (var j = 0; j < n; j++)
            {
                col[j] += grid[i][j];
            }
        }

        for (var i = 0; i < m; i++)
        {
            int row = grid[i].Sum();
            for (var j = 0; j < n; j++)
            {
                if (grid[i][j] == 1)
                {
                    ans += ((row - 1) * (col[j] - 1));
                }
            }
        }

        return ans;
    }
//
// public static bool IsLegal(int x, int y, int val)
// {
//     if (m == 0 || n == 0)
//     {
//         return false;
//     }
//
//     return x < n && y < m && x >= 0 && y >= 0 && val == 1;
// }

    // public static void Main()
    // {
    //     NumberOfRightTriangles(new[] { new[] { 1, 0, 1 }, new[] { 1, 0, 0 }, new[] { 1, 0, 0 } });
    // }
}