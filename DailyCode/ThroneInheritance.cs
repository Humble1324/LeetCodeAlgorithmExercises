using System.Collections.Generic;

public class ThroneInheritance
{
    // List<string> InheritanceOrder;
    private string _kingName;
    public Dictionary<string, List<string>> InheritanceOrder;
    public HashSet<string> deathPeople = new HashSet<string>();
    List<string> returnLists = new List<string>();

    public ThroneInheritance(string kingName)
    {
        //初始化国王
        InheritanceOrder = new();
        _kingName = kingName;
        InheritanceOrder.Add(kingName, new List<string>());
    }

    public void Birth(string parentName, string childName)
    {
        //parent的对象有了childName孩子
        if (InheritanceOrder.ContainsKey(parentName))
        {
            InheritanceOrder[parentName].Add(childName);
        }
        else
        {
            InheritanceOrder.Add(parentName, new List<string>());
            InheritanceOrder[parentName].Add(childName);
        }
    }

    public void Death(string name)
    {
        deathPeople.Add(name);
        //name的对象死亡
    }

    public IList<string> GetInheritanceOrder()
    {
        returnLists.Clear();
        dfsInherit(_kingName);

        //返回继承顺序
        return returnLists;
    }

    private void dfsInherit(string name)
    {
        if(!deathPeople.Contains(name))
        {
            returnLists.Add(name);
        }

        if (InheritanceOrder.ContainsKey(name))
        {
            foreach (var child in InheritanceOrder[name])
            {
                dfsInherit(child);
            }
        }
    }
}

/**
 * Your ThroneInheritance object will be instantiated and called as such:
 * ThroneInheritance obj = new ThroneInheritance(kingName);
 * obj.Birth(parentName,childName);
 * obj.Death(name);
 * IList<string> param_3 = obj.GetInheritanceOrder();
 */