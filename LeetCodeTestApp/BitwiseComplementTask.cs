using Microsoft.TestPlatform.AdapterUtilities.ManagedNameUtilities;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace LeetCodeTestApp;

// 1009
public class BitwiseComplementTask
{
    public int BitwiseComplement(int n)
    {
        if (n == 0)
            return 1;
        var k = (int)Math.Log(n, 2) + 1;
        var p = (1 << k) - 1;
        return n ^ p;
    }
}

public class BitwiseComplementTask_Tests
{
    [TestCase(0, 1)]
    [TestCase(1, 0)]
    [TestCase(5, 2)]
    [TestCase(7, 0)]
    [TestCase(10, 5)]
    public void Test(int input, int expected)
    {
        var actual = new BitwiseComplementTask().BitwiseComplement(input);
        // ClassicAssert.AreEqual(expected, actual);
        Assert.That(expected, Is.EqualTo(actual));
    }
}