using System;
using System.Text;

namespace LeetCode.DailyCode;

public partial class DailyCode
{
    public string BaseNeg2(int n)
    {
        if (n == 0) return "0";
        StringBuilder sb = new StringBuilder();
        while (n != 0)
        {
            sb.Insert(0,Math.Abs(n % 2));
            n = (int)Math.Ceiling((double)n / -2);
        }

        return sb.ToString();
    }
}