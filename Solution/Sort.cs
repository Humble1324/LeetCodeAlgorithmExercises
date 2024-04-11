﻿using System;
using System.Collections.Generic;

namespace LeetCode.Solution;

public class Sort
{
    //todo:补全排序

    public void HeapSort(int[] nums)
    {
    }

    public void MergingSort(int[] nums)
    {
    }


    /// <summary>
    /// 快速排序（双指针递归）
    /// </summary>
    /// <param name="nums">待排序数组</param>
    /// <param name="start">头</param>
    /// <param name="end">尾</param>
    public static void DoublePointerQuickSort(int[] nums, int start, int end)
    {
        //取中间值 放到合适的位置，左右固定
        //循环这个操作
        if (start > end) return;
        var random = new Random();

        //int pivotIndex=start; 之前取最小值会超时
        var pivotIndex = random.Next(start, end);

        //取end因为random会取不到end，所以end作为temp游标
        (nums[pivotIndex], nums[start]) = (nums[start], nums[pivotIndex]);

        var temp = nums[start];


        var left = start;
        var right = end;
        while (left < right)
            //while执行完当前temp左都是小，右都是大
        {
            //先执行右侧因为左侧left的数据已经存在temp内了，可以将右侧小于temp的值丢到左侧判断

            //从右找一个大于temp的值
            while (left < right && nums[right] >= temp) right--;

            //从左找一个小于temp的值
            while (left < right && nums[left] <= temp) left++;

            if (left >= right) break;
            //交换左大右小的值
            (nums[left], nums[right]) = (nums[right], nums[left]);
            //如果是left>=right那就代表两侧已经符合了
        }

        //遍历完后把基准从end移回来
        (nums[left], nums[start]) = (nums[start], nums[left]);

        DoublePointerQuickSort(nums, start, left - 1); //left-1是这次排序temp的位置
        DoublePointerQuickSort(nums, right + 1, end); //right和left都可以
    }

    /// <summary>
    /// 插入排序
    /// </summary>
    public static void InsertionSort(int[] nums, int left, int right)
    {
        for (var i = left + 1; i <= right; i++)
        {
            var temp = nums[i];
            var tempIndex = i;
            while (tempIndex > left && temp < nums[tempIndex - 1])
            {
                nums[tempIndex] = nums[tempIndex - 1];
                tempIndex--;
                //小一个往前位移一格
            }

            nums[tempIndex] = temp;
        }
    }

    static void Main()
    {
        int[] nums = new[] { 5, 1, 1, 2, 0, 0 };
        DoublePointerQuickSort(nums, 0, nums.Length - 1);
        for (var i = 0; i < nums.Length; i++)
        {
            Console.Write($"nums[i]{nums[i]} ");
        }
    }
}