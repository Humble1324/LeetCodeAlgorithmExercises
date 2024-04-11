using System.Text;

namespace LeetCode.DailyCode;

public partial class DailyCode
{
 
    public string MaximumBinaryString(string binary)
    {
        //最后答案不可能存在超过1个的0
        int lens = binary.Length;
        int j = 0;
        StringBuilder sBinary = new StringBuilder(binary);
        for (var i = 0; i < lens; i++)
        {
            if (sBinary[i] == '0')
            {
                while (j <= i || (j < lens && sBinary[j] == '1'))
                {
                    j++;//找到下一个1
                }

                if (j < lens)
                {
                    sBinary[j] = '1';
                    sBinary[i] = '1';
                    sBinary[i + 1] = '1';
                }
            }
        }


        return sBinary.ToString();
    }
}