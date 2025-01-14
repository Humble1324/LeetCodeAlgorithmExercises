using System.Collections.Generic;
using System.Text.Json.Nodes;

namespace LeetCode.Solution;

public class ChangeJson
{
    // 题目：
    // 实现一个函数将下面数组格式变量（格式如下）转换成树形格式变量（格式如下），并打印出来。
    // 数组格式例子： ( 说明：value表示当前值，id表示唯一标识，parent表示其父节点的id编号，如果没有父节点则为null)
    // [
    // { value: '江苏', parent: null, id: '1' },
    // { value: '苏州', parent: '1', id: '1.1' },
    // { value: '吴中区', parent: '1.1', id: '1.1.1' },
    // { value: '浙江', parent: null, id: '2' },
    // { value: '杭州', parent: '2', id: '2.1' },
    // { value: '余杭区', parent: '2.1', id: '2.1.1' }
    // ]
    //
    // 树形格式例子：( 说明：value表示当前值，id表示唯一标识，children表示该节点下所有的子节点 )
    // [
    // { value: '江苏', id: '1', children: [
    //     { value: '苏州', id: '1.1', children: [
    //         { value: '吴中区', id: '1.1.1' }
    //         ]} 
    //     ]},
    // { value: '浙江', id: '2', children: [
    //     { value: '杭州',  id: '2.1', children: [
    //         { value: '余杭区', id: '2.1.1' } 
    //         ]}
    //     ]}
    // ]
    //
    // 需注意的是树形结构可能会有多层（1层，2层，3层，...），取决于数组变量的实际值。
    public void Bird()
    {
        var Structs = new List<MyStruct>
        {
            new (new KeyValue("江苏", null, "1"),
                new KeyValue("苏州", "1", "1.1"), new KeyValue("吴中区", "1.1", "1.1.1")),
            new (new KeyValue("浙江", null, "2"),
                new KeyValue("杭州", "2", "2.1"), new KeyValue("余杭区", "2.1", "2.1.1"))
        };

        foreach (var @struct in Structs)
        {
            
        }
    }
}

public class MyStruct
{
    public KeyValue k1;
    public KeyValue k2;
    public KeyValue k3;

    public MyStruct(KeyValue kk1, KeyValue kk2, KeyValue kk3)
    {
        k1 = kk1;
        k2 = kk2;
        k3 = kk3;
    }
}

public class KeyValue
{
    public string value;
    public string? parent;
    public string id;

    public KeyValue(string v, string? p, string i)
    {
        value = v;
        parent = p;
        id = i;
    }
}