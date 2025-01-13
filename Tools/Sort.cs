using System;

namespace LeetCode.Tools;

public class Sort
{
    public static void QuickSort(int[] arr, int left, int right)
    {
        if (left >= right) return;
        
       var ram = new Random();
       int t = ram.Next(left, right);
       (arr[left], arr[t]) = (arr[t], arr[left]); 

        int temp = arr[left];
        int l = left;
        int r = right;
        while (l < r)
        {    
            //先右--再左++因为刚交换完大小，左侧才是小的值，所以如果颠倒排序就出问题了
            // eg:交换完后 temp=6 arr[l]=5,arr[r]=7，这时候l++会导致换错 应是r--
            while (l < r && arr[r] >= temp)
            {
                r--;
            } 
            while (l < r && arr[l] <= temp)
            {
                l++;
            }
            
            if (l > r) break;
            (arr[l], arr[r]) = (arr[r], arr[l]);
        }


        //l==r
        (arr[left], arr[l]) = (arr[l], arr[left]);
        string test = "";
        for (var i = 0; i < arr.Length; i++)
        {
            test += arr[i];

        }
        Console.WriteLine($"left={left},right={right},test={test}");
        QuickSort(arr, left, l - 1);
        QuickSort(arr, r + 1, right);
    }


    /// <summary>
    /// 有序使用二分
    /// </summary>
    /// <param name="arr"></param>
    /// <param name="low"></param>
    /// <param name="high"></param>
    /// <param name="target"></param>
    /// <returns></returns>
    public int BinarySearch(int[] arr, int low, int high, long target)
    {
        int res = high + 1;
        while (low <= high)
        {
            int mid = low + (high - low) >> 1;
            if (arr[mid] > target)
            {
                res = mid;
                high = mid - 1;
            }
            else
            {
                low = mid + 1;
            }
        }

        return res;
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
        //值
        var temp = nums[start];
        //两个下标
        var left = start;
        var right = end;

        //while执行完当前temp左都是小，右都是大
        while (left < right)
        {
            //先执行右侧因为左侧left的数据已经存在temp内了，可以将右侧小于temp的值丢到左侧判断

            //从右找第一个小于temp的值
            while (left < right && nums[right] >= temp)
            {
                right--;
            }

            //从左找第一个大于temp的值
            while (left < right && nums[left] <= temp)
            {
                left++;
            }

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

    public static void HeapSort(int[] nums)
    {
        int lens = nums.Length - 1;

        BuildMaxHeap(nums, lens);

        for (int i = lens; i >= 1; i--)
        {
            // Move current root to end
            (nums[0], nums[i]) = (nums[i], nums[0]);
            lens -= 1;
            // call max heapify on the reduced heap
            MaxHeapify(nums, 0, lens);
        }
    }

    public void  MergeSort(int[] nums, int left, int right)
    {
        if (left > right) return;
        var mid = left + (right - left) >>> 1;
        MergeSort(nums, left, mid);
        MergeSort(nums, mid + 1, right);
        // 如果数组的这个子区间本身有序，无需合并
        MergeOfTwoSortedArray(nums, left, mid, right);

    }

    public void MergeOfTwoSortedArray(int[] nums, int left, int mid, int right)
    {
        int lens = right - left + 1;
        int[] tempAns = new int[lens];
        int i = left, j = mid + 1, k = 0;
        while (i <= mid && j <= right)
        {
            if (nums[i] >= nums[j])
            {
                tempAns[k++] = nums[j++];
            }
            else
            {
                tempAns[k++] = nums[i++];
            }
        }

        while (i <= mid)
        {
            tempAns[k++] = nums[i++];
        }

        while (j <= right)
        {
            tempAns[k++] = nums[j++];
        }
        Array.Copy(tempAns,0,nums,left,lens);
    }

    public static void BuildMaxHeap(int[] nums, int lens)
    {
        for (int i = lens / 2; i >= 0; --i)
        {
            MaxHeapify(nums, i, lens);
        }
    }

    public static void MaxHeapify(int[] nums, int i, int lens)
    {
        for (; (i << 1) + 1 <= lens;)
        {
            int largest;
            int left = (i << 1) + 1;
            int right = (i << 1) + 2;
            //当前填入位置 以及初始化

            //如果左侧大于根节点
            if (left <= lens && nums[left] > nums[i])
            {
                largest = left;
            }
            else
            {
                largest = i;
            }

            //如果右侧侧大于根节点
            if (right <= lens && nums[right] > nums[largest])
            {
                largest = right;
            }

            if (largest != i)
            {
                (nums[largest], nums[i]) = (nums[i], nums[largest]);
                i = largest;
            }
            else
            {
                break;
            }
        }
    }

     // static void Main()
     // {
     //     int[] nums = new[] { 5,1,1,2,0,0 };
     //     QuickSort(nums,0,5);
     // }
}