using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace LeetCodeTestApp;

public class SingleNumberTask
{
    public int SingleNumber(int[] nums)
    {
        var numbers = new HashSet<int>();
        foreach (var n in nums)
        {
            if (!numbers.Remove(n))
                numbers.Add(n);
        }

        return numbers.First();

        var s = "abcde";
        var p = "c";
        var q = s.Contains(p);
    }
}

public class SingleNumberTask_Tests
{
    [TestCase(new int[] {2, 2, 1}, 1)]
    [TestCase(new int[] {4,1,2,1,2}, 4)]
    [TestCase(new int[] {1}, 1)]
    public void Test(int[] array, int expected)
    {
        var actual = new SingleNumberTask().SingleNumber(array);
        ClassicAssert.AreEqual(expected, actual);
    }
}