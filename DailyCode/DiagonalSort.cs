using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.JavaScript;

namespace LeetCode.DailyCode;

public partial class DailyCode

{
    public IList<IList<int>> FindWinners(int[][] matches)
    {
        HashSet<int> winnerSet = new HashSet<int>();
        HashSet<int> loser = new HashSet<int>();
        Dictionary<int, int> onlyOneDic = new Dictionary<int, int>();
        foreach (var match in matches)
        {
            for (var i = 0; i < match.Length; i++)
            {
                if (i == 0 && !loser.Contains(match[i]))
                {
                    winnerSet.Add(match[i]);
                }

                if (i == 1)
                {
                    loser.Add(match[i]);
                    winnerSet.Remove(match[i]);
                    if (onlyOneDic.ContainsKey(match[i]))
                    {
                        onlyOneDic[match[i]]++;
                    }
                    else
                    {
                        onlyOneDic.Add(match[i], 1);
                    }
                }
            }
        }

        List<IList<int>> res = new List<IList<int>>();
        List<int> answers1 = new();

        foreach (var i in winnerSet)
        {
            answers1.Add(i);
        }

        answers1.Sort();
        res.Add(answers1);
        List<int> answers = new();

        foreach (var keyValuePair in onlyOneDic)
        {
            if (keyValuePair.Value == 1)
            {
                answers.Add(keyValuePair.Key);
            }
        }

        answers.Sort();
        res.Add(answers);
        return res;
    }
}