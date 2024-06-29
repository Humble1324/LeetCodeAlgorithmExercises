using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.DailyCode;

public partial class DailyCode
{
    public static string DiscountPrices(string sentence, int discount)
    {
        StringBuilder sb = new StringBuilder(sentence);
        String[] a = sentence.Split(" ");
        for (int i = 0; i < a.Length; i++)
        {
            if (check(a[i]))
            {
                long price = long.Parse(a[i].Substring(1));
                double dis = (100 - discount) / 100.0;
                double newPrice = price * dis;
                a[i] = string.Format("${0:F2}", newPrice);
            }
        }


        return string.Join(" ", a);
    }

    private static bool check(string S)
    {
        if (S.Length == 1 || S[0] != '$')
        {
            return false;
        }

        int lens = S.Length;
        for (var i = 1; i < lens; i++)
        {
            if (!Char.IsDigit(S[i]))
                return false;
        }

        return true;
    }

    public int CountBeautifulPairs(int[] nums)
    {
        int ans = 0;
        Dictionary<int, List<int>> map = new Dictionary<int, List<int>>();
        //新增1~9的互质数表加入map
        map.Add(1, new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
        map.Add(2, new List<int>() { 1, 3, 5, 7, 9 });
        map.Add(3, new List<int>() { 1, 2, 4, 5, 7, 8 });
        map.Add(4, new List<int>() { 1, 3, 5, 7, 9 });
        map.Add(5, new List<int>() { 1, 2, 3, 4, 6, 7, 8, 9 });
        map.Add(6, new List<int>() { 1, 5, 7 });
        map.Add(7, new List<int>() { 1, 2, 3, 4, 5, 6, 8, 9 });
        map.Add(8, new List<int>() { 1, 3, 5, 7, 9 });
        map.Add(9, new List<int>() { 1, 2, 4, 5, 7, 8 });
        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = i + 1; j < nums.Length; j++)
            {
                //L是nums[i]的第一个数字
                int L =int.Parse(nums[i].ToString().Substring(0,1));
                int R = nums[j] % 10;
                //string L = nums[i].ToString();
                if (map[L].Contains(R))
                {
                    ans++;
                }
            }
        }

        return ans;
    }

    // public static void Main()
    // {
    //     Console.Write("");
    //     //Console.Write( ((1.0-64/100.0)*7383692).ToString("F2"));
    // }
}