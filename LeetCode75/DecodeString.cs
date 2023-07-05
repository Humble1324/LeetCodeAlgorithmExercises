using System;

namespace LeetCode;

public partial class LeetCode75
{
    public static string DecodeString(string s)
    {
        int index = 0;
        return Decodes(s);
    }

    public static string Decodes(string s)
    {
        //递归终止条件：字符串内没数字
        int lens = s.Length;
        int temp = 0;
        string returns = "";
        bool isAll = true;
        for (int i = 0; i < lens; i++)
        {
            if (s[i] >= '1' && s[i] <= '9')
            {
                var j = i + 2;
                string temptext = "";
                temp = s[i] - '0';
                int count = 1;
                while (j<lens&&(s[j] != ']'||count==0))
                {
                    if (s[j] == '[') count++;
                    if (s[j] == ']') count--;
                    temptext += s[j++];
                }
                isAll =false;
                returns += Decodes(temptext);
            }
        }
        if(isAll)returns= s;

        return returns;
    }   
    // public static void Main()
    // {
    //     Console.Write(DecodeString("3[a2[c]]"));
    // }
}