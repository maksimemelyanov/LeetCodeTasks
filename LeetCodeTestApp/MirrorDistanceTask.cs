using NUnit.Framework;

namespace LeetCodeTestApp;

public class MirrorDistanceTask
{
    public int MirrorDistance(int n)
    {
        var reversed = 0;
        var x = n;
        while (x > 0)
        {
            reversed = reversed * 10 + x % 10;
            x /= 10;
        }
        return Math.Abs(n - reversed);
    }
}

public class MirrorDistanceTask_Tests
{
    [Test]
    [TestCase(25, 27)]
    [TestCase(10, 9)]
    [TestCase(7, 0)]
    public void Test(int input, int expected)
    {
        var actual = new MirrorDistanceTask().MirrorDistance(input);
        Assert.That(actual, Is.EqualTo(expected));
    }
}