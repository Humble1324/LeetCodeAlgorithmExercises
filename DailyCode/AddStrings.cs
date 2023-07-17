using System;
using System.Linq;
using System.Text;

namespace LeetCode.DailyCode;

public partial class DailyCode
{
    public static string AddStrings(string num1, string num2)
    {
        int lens1 = num1.Length;
        int lens2 = num2.Length;
        double sum1 = 0, sum2 = 0, sum = 0;
        for (int i = 0; i <lens1; i++)
        {
            sum1 += (num1[i] - '0')*Math.Pow(10,lens1-i-1);
        }
        for (int i = 0; i <lens2; i++)
        {
            sum2 += (num2[i] - '0')*Math.Pow(10,lens2-i-1);
        }

        sum = sum1 + sum2;
        return sum.ToString();
    }

    public static string AddStringsII(string num1, string num2)
    {
        int i = num1.Length-1;
        int j = num2.Length-1;
        int add = 0;
        string addStrings = "";
        while (i >= 0 || j >= 0||add!=0)
        {
            int x = i >= 0 ? num1[i] - '0' : 0;
            int y = j >= 0 ? num2[j] - '0' : 0;
            int result = x + y + add;
            addStrings+=(result% 10).ToString();
            add = result / 10;
            i--;
            j--;
        }

        string returnstring="";
        for (int t = 0; t < addStrings.Length; t++)
        {
            returnstring += addStrings[t];
        }
        return returnstring;
    }

    public static void Main(string[] args)
    {
        int[] candies = new int[] { 1,0,0,0,1,0,0 };
        Console.WriteLine("Test Log");
        var leet = new LeetCode75();
        Console.WriteLine(AddStringsII("9333852702227987", "85731737104263"));
    }
}