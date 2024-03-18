using System.Linq;
using System.Text;

namespace LeetCode.DailyCode;

public partial class MyClass
{
    public string MaximumOddBinaryNumber(string s)
    {
        int nums = 0;
        StringBuilder ts = new StringBuilder(new string(Enumerable.Repeat('0', s.Length).ToArray()));
        //最后一位一定要1
        foreach (var c in s)
        {
            if (c == '1') nums++;
        }

        if (nums >= 1)
        {
        
        
            nums--;
            ts[s.Length - 1] = '1';
        }

        for (var i = 0; i < s.Length - 1; i++)
        {
            if (nums >= 1)
            {
                ts[i] = '1';
                nums--;
            }
            else
            {
                ts[i] = '0';
            }
        }

        return ts.ToString();
    }
}