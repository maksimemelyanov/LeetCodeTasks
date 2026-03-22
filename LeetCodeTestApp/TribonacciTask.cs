using NUnit.Framework;

namespace LeetCodeTestApp;

public class TribonacciTask
{
    public int Tribonacci(int n)
    {
        if (n == 0)
            return 0;
        if (n == 1 || n == 2)
            return 1;
        var a = 0;
        var b = 1;
        var c = 1;
        for (var i = 3; i <= n; i++)
        {
            var t = a + b + c;
            a = b;
            b = c;
            c = t;
        }

        return c;
    }
}

public class TribonacciTask_Tests
{
    [TestCase(4, 4)]
    [TestCase(25, 1389537)]
    public void Test(int n, int expected)
    {
        var actual = new TribonacciTask().Tribonacci(n);
        Assert.That(actual, Is.EqualTo(expected));
    }
}