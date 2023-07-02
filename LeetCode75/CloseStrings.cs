using System;
using System.Collections.Generic;

namespace LeetCode;

public partial class LeetCode75
{
    /*
    如果可以使用以下操作从一个字符串得到另一个字符串，则认为两个字符串 接近 ：
    
    操作 1：交换任意两个 现有 字符。
    例如，abcde -> aecdb
    操作 2：将一个 现有 字符的每次出现转换为另一个 现有 字符，并对另一个字符执行相同的操作。
    例如，aacabb -> bbcbaa（所有 a 转化为 b ，而所有的 b 转换为 a ）
    你可以根据需要对任意一个字符串多次使用这两种操作。
    
    给你两个字符串，word1 和 word2 。如果 word1 和 word2 接近 ，就返回 true ；否则，返回 false 。
    */
    public static bool CloseStrings(string word1, string word2)
    {
        if (word1.Length != word2.Length) return false;
        Dictionary<char, int> dic1 = new();
        foreach (var text in word1)
        {
            if (dic1.ContainsKey(text)) dic1[text]++;
            else dic1.Add(text,0);
        }
        Dictionary<char, int> dic2 = new();
        foreach (var text in word2)
        {
            if (dic2.ContainsKey(text)) dic2[text]++;
            else dic2.Add(text,0);
        }

        foreach (var dic1key in dic1)
        {
            if (!dic2.ContainsKey(dic1key.Key)) return false;
        }
        List<int> word1List = new List<int>();
        List<int> word2List = new List<int>();
        foreach (var dic1key in dic1)
        {
            word1List.Add(dic1key.Value);
        }
        foreach (var dic1key in dic2)
        {
            word2List.Add(dic1key.Value);
        }
        word1List.Sort();
        word2List.Sort();
        if (word1List.Count != word2List.Count) return false;
        for (int i = 0; i < word1List.Count; i++)
        {
            if (word1List[i] != word2List[i]) return false;
        }
        return true;
    }
    // public static void Main(string[] args)
    // {
    //     int[] candies = new int[] { 1,0,0,0,1,0,0 };
    //     Console.WriteLine("Test Log");
    //     var leet = new LeetCode75();
    //     Console.WriteLine(CloseStrings("cabbba"
    //     ,"aabbss"));
    // }
}