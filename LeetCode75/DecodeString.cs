namespace LeetCode;

public partial class LeetCode75
{
    public static string DecodeString(string s)
    {
        var index = 0;
        return Decodes(s);
    }

    public static string Decodes(string s)
    {
        //递归终止条件：字符串内没数字
        var lens = s.Length;
        var temp = 0;
        var returns = "";
        var isAll = true;
        for (var i = 0; i < lens; i++)
            if (s[i] >= '1' && s[i] <= '9')
            {
                var j = i + 2;
                var temptext = "";
                temp = s[i] - '0';
                var count = 1;
                while (j < lens && (s[j] != ']' || count == 0))
                {
                    if (s[j] == '[') count++;
                    if (s[j] == ']') count--;
                    temptext += s[j++];
                }

                isAll = false;
                returns += Decodes(temptext);
            }

        if (isAll) returns = s;

        return returns;
    }
    // public static void Main()
    // {
    //     Console.Write(DecodeString("3[a2[c]]"));
    // }
}