using System;
using System.Collections.Generic;

namespace LeetCode;

public partial class LeetCode75
{
    public int MinReorder(int n, int[][] connections)
    {
        //找到根节点
        //向两端遍历，使得朝向0
        
        //初始化
        var e = new List<Tuple<int, int>>[n];
            //e是每个城市 每个城市通往的两个城市，对应通往是否有路
        for (var i = 0; i < e.Length; i++)
        {
            e[i] = new List<Tuple<int, int>>();
        }
        foreach (var connection in connections)//循环节点数次
        {
            e[connection[0]].Add(new Tuple<int, int>(connection[1],1));
            e[connection[1]].Add(new Tuple<int, int>(connection[0],0));
            
        }
        return dfsPic(0,-1,e);
    }



    public int dfsPic(int x, int dad, List<Tuple<int, int>>[] e)
    {
        int count = 0;
        foreach (var edge in e[x])
        {
            if(edge.Item1==dad)
                continue;
            count += edge.Item2 + dfsPic(edge.Item2, x, e);
        }
        
        return count;
    }
}