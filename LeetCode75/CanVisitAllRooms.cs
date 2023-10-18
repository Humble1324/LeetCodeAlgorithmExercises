using System;
using System.Collections.Generic;
using System.Windows.Documents;
using LeetCode.DailyCode;

namespace LeetCode;

public partial class LeetCode75
{
    public static Dictionary<int, bool> canInRoom = new Dictionary<int, bool>();
    public static Dictionary<int, bool> isVistitedRoom = new Dictionary<int, bool>();
    public static Queue<int> BeEnteredRoom = new Queue<int>();

    public static bool CanVisitAllRoomsFunc(IList<IList<int>> rooms)
    {
        var roomsLens = rooms.Count;

        if (rooms[0].Count == 0) return false;
        canInRoom.Add(0, true);
        isVistitedRoom.Add(0, false);
        for (var i = 1; i < roomsLens; i++)
        {
            canInRoom.Add(i, false);
            isVistitedRoom.Add(i, false);
        }

        for (var i = 0; i < rooms[0].Count; i++)
        {
            canInRoom[rooms[0][i]] = true;
            BeEnteredRoom.Enqueue(rooms[0][i]);
        }

        while (BeEnteredRoom.Count > 0)
        {
            var roomKey = BeEnteredRoom.Dequeue();
            isVistitedRoom[roomKey] = true;
            if (rooms[roomKey].Count == 0) rooms[roomKey].Add(0);
            for (var i = 0; i < rooms[roomKey].Count; i++) //进入房间寻找可进入房间
            {
                canInRoom[roomKey] = true;
                if (isVistitedRoom[rooms[roomKey][i]] != true)
                    BeEnteredRoom.Enqueue(rooms[roomKey][i]); //加入待进入房间
            }
        }

        foreach (var keyValuePair in canInRoom)
        {
            if (keyValuePair.Value == false)
            {
                //Console.WriteLine(keyValuePair.Key);
                return false;
            }
        }

        return true;
    }

    public void FindRoom(List<int> roomKey)
    {
        foreach (var i in roomKey)
        {
            canInRoom[i] = true;
        }
    }

    public bool[] isVisited;
    private int num;

    public bool CanVisitAllRooms(IList<IList<int>> rooms)
    {
        int lens = rooms.Count;
        num = 0;
        isVisited = new bool[lens];
        dfs(rooms, 0);
        return num == lens;
    }

    public void dfs(IList<IList<int>> rooms, int x)
    {
        isVisited[x] = true;
        num++;
        for (int i = 0; i < rooms[x].Count; i++)
        {
            if (!isVisited[rooms[x][i]])
                dfs(rooms, rooms[x][i]);
        }
    }

    // public static void Main()
    // {
    //     List<IList<int>> test = new List<IList<int>>()
    //         { new List<int>() { 1 }, new List<int>() { 2 }, new List<int>() { 3 }, new List<int>() { }, };
    //     //Console.WriteLine(CanVisitAllRooms(test));
    // }
}