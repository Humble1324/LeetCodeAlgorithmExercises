namespace LeetCode.DailyCode;

public partial class DailyCode
{
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
        if(l1.val==0) return l2;
        if(l2.val==0) return l1;
        int doublel1 = l1.val;
        int doublel2 = l2.val;
        int temp1=10;
        int temp2=10;
        l1 = l1.next;
        l2 = l2.next;
        ListNode returnListNode = new ListNode(0);
        ListNode cur = returnListNode.next;
        while(l1!=null){
            doublel1 = l1.val*temp1;
            temp1 = temp1*10;
            l1 = l1.next;
        }
        while(l2!=null){
            doublel2 = l2.val*temp2;
            temp2 = temp2*10;
            l2 = l2.next;
        }
        int doubleLN = doublel1+doublel2;
        while(doubleLN>0){
            ListNode temp = new();
            temp.val=(doubleLN%10);
            doubleLN/=10;
            cur.next =temp;
            cur = cur.next;
        }
        // ListNode listNode = new();
        // listNode.val=(doubleLN%10);
        // listNode.next = cur;
        // returnListNode.next = listNode;
        // cur = listNode;
        return returnListNode.next;
    }

    public class ListNode {
         public int val;
             public ListNode next;
             public ListNode(int val=0, ListNode next=null) {
                 this.val = val;
                 this.next = next;
             }
     }
}