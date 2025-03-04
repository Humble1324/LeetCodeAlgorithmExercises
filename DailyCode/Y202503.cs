using System;

namespace LeetCode.DailyCode;
public class Y202503{

    public int RobNew(int[] nums){
        int lens = nums.Length;
        // 特殊情况处理：只有一个房子时直接返回
        if(lens == 1){
            return nums[0];
        }
        // 特殊情况处理：只有两个房子时返回较大的值
        if(lens == 2){
            return Math.Max(nums[0],nums[1]);
        }
        // 创建动态规划数组，dp[i,0]表示不偷第i个房子的最大金额
        // dp[i,1]表示偷第i个房子的最大金额
        int[,] dp =new int[lens,2];
        // 初始化：不偷第一个房子
        dp[0,0] = 0;
        // 初始化：偷第一个房子
        dp[0,1]=nums[0];
        // 动态规划过程
        for(int i = 1; i < lens; i++) {
            // 不偷当前房子时，最大金额为前一个房子偷或不偷的最大值
            dp[i,0]=Math.Max(dp[i-1,0],dp[i-1,1]);
            // 偷当前房子时，只能加上不偷前一个房子的金额
            dp[i,1]=nums[i]+dp[i-1,0];
        }
        // 返回最后一个房子偷或不偷的最大值
        return Math.Max(dp[lens-1,0],dp[lens-1,1]);
    }
}

public class OrderedStream {

    private string[] _stream;
    private int _ptr;
    public OrderedStream(int n) {
        _stream = new string[n];
        _ptr =0;
    }
    
    public IList<string> Insert(int idKey, string value) {
        _stream[idKey] = value;
        List<string> ans = new List<string>();
        
        while (_ptr < _stream.Length && _stream[_ptr] != null){
            ans.Add(_stream[_ptr]);
            _ptr++;
        }
        return ans;
    }
}
/**
 * Your OrderedStream object will be instantiated and called as such:
 * OrderedStream obj = new OrderedStream(n);
 * IList<string> param_1 = obj.Insert(idKey,value);
 */