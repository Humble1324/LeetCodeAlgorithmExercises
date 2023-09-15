using System.Collections.Generic;

namespace LeetCode;

public partial class LeetCode75
{
    public string RemoveStars(string s)
    {
        var stringList = new List<char>();
        var charStack = new Stack<char>();
        var lens = s.Length;
        for (var i = 0; i < lens; i++)
            if (s[i] != '*')
                charStack.Push(s[i]);
            else if (charStack.Count != 0) charStack.Pop();

        while (charStack != null) stringList.Add(charStack.Pop());
        stringList.Reverse();
        s = "";
        foreach (var text in stringList) s += text;
        return s;
    }
}