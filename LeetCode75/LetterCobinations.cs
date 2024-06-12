using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode;

public partial class LeetCode75
{
    private static List<int> _nums = new List<int>();
    private static IList<string> _numResult=new List<string>();
    private static StringBuilder _tempPath ;
    
    static List<string> letterMap = new List<string>()
        { "", "", "abc", "def", "ghi", "jkl", "mno", "pqrs", "tuv", "wxyz" };

    public static IList<string> LetterCombinations(string digits)
    {
        if (digits.Length == 0) return new List<string>();
        _nums.Clear();
        _numResult.Clear();
        _tempPath = new StringBuilder("");
        foreach (var digit in digits)
        {
            _nums.Add(Int32.Parse(digit.ToString()));
        }

        NumberBackTracking(digits.Length,0);

        return _numResult;
    }

    static void NumberBackTracking( int Length, int startIndex)
    {
        if (_tempPath.Length == Length)
        {
            _numResult.Add(_tempPath.ToString());
            return;
        }

        for (var t = 0; t <= letterMap[_nums[startIndex]].Length-1; t++)
        {
            _tempPath = new StringBuilder(_tempPath + letterMap[_nums[startIndex]][t].ToString());
            NumberBackTracking(Length,startIndex+1);
            _tempPath.Remove(_tempPath.Length-1,1);
        }
    }

     public static void Main()
     {
         Console.Write(LetterCombinations("23"));
     }

    //存放符合条件的单一结果
    private List<IList<int>> _result = new List<IList<int>>();

    //存放符合条件结果的集合
    private List<int> _path = new List<int>();

    public IList<IList<int>> Combine(int n, int k)
    {
        backTracking(n, k, 1);
        return _result;
    }

    /// <summary>
    /// 回溯方法本体
    /// </summary>
    /// <param name="n">从1开始到n的数字</param>
    /// <param name="k">k个数字组合</param>
    /// <param name="startIndex">当前遍历的数字</param>
    void backTracking(int n, int k, int startIndex)
    {
        if (_path.Count == k)
        {
            _result.Add(new List<int>(_path));
            return;
        }

        for (var i = startIndex; i <= n; i++)
        {
            _path.Add(i);
            backTracking(n, k, i + 1);
            _path.RemoveAt(_path.Count - 1);
        }
    }
}