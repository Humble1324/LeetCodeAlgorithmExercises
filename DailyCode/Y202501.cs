﻿using System;

namespace LeetCode.DailyCode;

public class Y202501
{
    public static string LargestGoodInteger(string num)
    {
        int lens = num.Length;
        string max = int.MinValue.ToString();
        for (int index = 0; index < lens;)
        {
            int temp = index + 1;
            int tCount = 1;
            int t = num[index] - '0';
            while (temp < lens && (num[temp] - '0') == t && tCount < 3)
            {
                temp++;
                tCount++;
            }

            if (tCount == 3)
            {
                max =int.Parse(max)>int.Parse(num.Substring(index, 3))?max:num.Substring(index, 3);
            }

            index = temp;
        }

        return max == int.MinValue.ToString() ? "" : max.ToString();
    }
        public int GenerateKey(int num1, int num2, int num3)
        {
            int ans = 0;
            int pow10 = 1;
            while (num1 > 0 && num2 > 0 && num3 > 0)
            {
                ans+= Math.Min(num1%10,Math.Min(num2%10,num3%10))*pow10;
                num1 /= 10;
                num2 /= 10;
                num3 /= 10;
                pow10 *= 10;
            }
            return ans;
        
            //test
    //
    // public static void Main(string[] args)
    // {
    //     Console.WriteLine(LargestGoodInteger("6777133339"));
    // }
}