using NUnit.Framework;

namespace LeetCodeTestApp;

public class ReverseTask
{
    public int Reverse(int x)
    {
        if (x == int.MinValue)
            return 0;
        var sign = Math.Sign(x);
        var abs = Math.Abs(x);
        var result = 0;
        while (abs > 0)
        {
            if ((int.MaxValue - abs % 10) / 10 < result)
                return 0;
            result = result * 10 + abs % 10;
            abs /= 10;
        }
        
        return result * sign;
    }
}

public class ReverseTask_Tests
{
    [TestCase(123, 321)]
    [TestCase(-123, -321)]
    [TestCase(120, 21)]
    [TestCase(1534236469, 0)]
    public void Test(int n, int expected)
    {
        var actual = new ReverseTask().Reverse(n);
        Assert.That(expected, Is.EqualTo(actual));
    }
}
