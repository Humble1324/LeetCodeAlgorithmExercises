using System;

namespace LeetCode.DailyCode;

public class MyHashMap
{
    private int[] hash;
    public MyHashMap()
    {
        hash = new int[100000];
        Array.Fill(hash, -1);
    }

    public void Put(int key, int value)
    {
        hash[key] = value;
    }

    public int Get(int key)
    {
        if (hash.Length>key)
        {
            return hash[key];
        }

        return -1;
    }

    public void Remove(int key)
    {
        hash[key] = -1;
    }
}