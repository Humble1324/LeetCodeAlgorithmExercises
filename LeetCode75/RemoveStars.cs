using System.Collections.Generic;

namespace LeetCode;

public partial class LeetCode75
{
    public string RemoveStars(string s) {
        List<char> stringList = new List<char>();
        Stack<char> charStack = new Stack<char>();
        int lens = s.Length;
        for (int i = 0; i < lens; i++)
        {
            if (s[i] != '*')
                charStack.Push(s[i]);
            else if(charStack.Count!=0)charStack.Pop();
        }

        while (charStack != null)
        {
           stringList.Add(charStack.Pop()); 
        }
        stringList.Reverse();
        s = "";
        foreach (var text in stringList)
        {
            s += text;
        }
        return s;
    }
}