using System;
using System.Text;

namespace LeetCode.DailyCode;

public partial class DailyCode

{
    public  string SmallestString(string s)
    {
        if (s.Length == 1)
        {
            if (s[0] == 'a')
            {
                return 'z'.ToString();
            }
            else
            {
                char ret = (char)(s[0] - 1);
                return ret.ToString();
            }
        }

        StringBuilder sb = new StringBuilder(s);
        int lens = s.Length;
        int left = 0, right = 0;
        //找到最长不带a的字符串
        for (int i = 0; i < lens; i++)
        {
            if (s[i] == 'a')
            {
                continue;
            }

            int tempSlow = i, tempFast = i;
            while (tempFast < lens && s[tempFast] != 'a')
            {
                tempFast++;
            }
            if (tempFast == lens)
            {
                tempFast--;
            }
            left = tempSlow;
            right = tempFast;
            break;
        }

        if (left == 0 && right == 0)
        {
            sb[^1] = 'z';
            return sb.ToString();
        }

        for (int i = left; i <= right; i++)
        {
            if (sb[i] != 'a')
                sb[i] = (char)(sb[i] - 1);
        }

        return sb.ToString();
    }

    public  string RemoveTrailingZeros(string num) {
        int lens = num.Length;
        int t=lens-1;
        while(t>=0){
            if(num[t]=='0'){
                t--;
            }else{
                
                break;
            }
        }

        //string nums = num.Substring(0, t);
        return num.Substring(0, t+1);
    }
    // public static void Main()
    // {
    //     Console.Write(RemoveTrailingZeros("1241402143"));
    // }
}