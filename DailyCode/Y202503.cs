using System;

namespace LeetCode.DailyCode;
public class Y202503{

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