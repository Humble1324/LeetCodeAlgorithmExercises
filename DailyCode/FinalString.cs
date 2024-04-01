using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.DailyCode;

public partial class DailyCode
{
    public string FinalString(string s)
    {

        List<char> t = new List<char>();
        for (var i = 0; i < s.Length; i++)
        {
            if (s[i] != 'i')
                t.Add(s[i]);
            else
            {
                t.Reverse();
            }
        }
        return t.Aggregate("", (current, c) => current + c);
    }
}