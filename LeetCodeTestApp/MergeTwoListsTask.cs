using System.Text;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace LeetCodeTestApp;

public class ListNode
{
    public int val;
    public ListNode next;

    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}

public class MergeTwoListsTask
{
    public ListNode MergeTwoLists(ListNode list1, ListNode list2)
    {
        if (list1 == null)
            return list2;
        if (list2 == null)
            return list1;

        var dummy = new ListNode(0);
        var current = dummy;

        while (list1 != null && list2 != null)
        {
            if (list1.val <= list2.val)
            {
                current.next = list1;
                list1 = list1.next;
            }
            else
            {
                current.next = list2;
                list2 = list2.next;
            }

            current = current.next;
        }

        if (list1 != null)
            current.next = list1;
        else if (list2 != null)
            current.next = list2;

        return dummy.next;
    }
}

public class MergeTwoListsTask_Tests
{
    [Test]
    public void Test1()
    {
        var list1 = new ListNode(1, new ListNode(2, new ListNode(4)));
        var list2 = new ListNode(1, new ListNode(3, new ListNode(4)));
        var expected = new ListNode(1,
            new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(4))))));
        var result = new MergeTwoListsTask().MergeTwoLists(list1, list2);
        ClassicAssert.AreEqual(ToString(expected), ToString(result));
    }

    public string ToString(ListNode list)
    {
        var sb = new StringBuilder();
        sb.Append('[');
        var head = list;
        while (head != null)
        {
            sb.Append(head.val);
            if (head.next != null)
                sb.Append(", ");
            head = head.next;
        }

        sb.Append(']');
        return sb.ToString();
    }
}