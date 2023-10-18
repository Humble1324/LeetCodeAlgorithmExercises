using System;
using System.Text;

namespace LeetCode.DailyCode;

public partial class DailyCode
{
    public int MaximumSwap(int num)
    {
        // 示例 1 :
        // 输入: 2736
        // 输出: 7236
        // 解释: 交换数字2和数字7。
        StringBuilder s = new StringBuilder(num.ToString());
        int lens = s.Length;
        int max = num;
        for (int i = 0; i < lens; i++)
        {
            for (int j = 0; j < lens; j++)
            {
                (s[i], s[j]) = (s[j], s[i]);
                max = Math.Max(max, int.Parse(s.ToString()));
                (s[i], s[j]) = (s[j], s[i]);
            }
        }


        return max;
    }
}