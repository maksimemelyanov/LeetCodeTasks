using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace LeetCodeTestApp;

public class PlusOneTask
{
    public int[] PlusOne(int[] digits)
    {
        var n = digits.Length;
        for (var i = n - 1; i >= 0; i--)
        {
            if (digits[i] < 9)
            {
                digits[i]++;
                return digits;
            }

            digits[i] = 0;
        }

        var result = new int[n + 1];
        result[0] = 1;
        return result;
    }
}

public class PlusOneTask_Tests
{
    [Test]
    [TestCase(new[] {1,2,3}, new[] {1, 2, 4})]
    [TestCase(new[] {4,3,2,1}, new[] {4,3,2,2})]
    [TestCase(new[] {9}, new[] {1, 0})]
    public void Test(int[] input, int[] expected)
    {
        var result = new PlusOneTask().PlusOne(input);
        ClassicAssert.AreEqual(expected.Length, result.Length);
        for (var i = 0; i < expected.Length; i++)
        {
            ClassicAssert.AreEqual(expected[i], result[i]);
        }
    }
}