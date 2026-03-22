using System.Text;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace LeetCodeTestApp;

public class ToHexTask
{
    public string ToHex(int num)
    {
        var hexAlphabet = "0123456789abcdef".ToCharArray();
        var builder = new StringBuilder();
        if (num == 0)
            return "0";
            // n = (int)((num + Int32.MaxValue) & 0xFFFFFFFF);
        var n = (uint)num;
        while (n > 0)
        {
            var k = n % 16;
            builder.Append(hexAlphabet[k]);
            n = n / 16;
        }

        var hexNumber = new string(builder.ToString().Reverse().ToArray());
        return hexNumber;
    }
}

public class ToHeTask_Tests
{
    [TestCase(26, "1a")]
    [TestCase(-1, "ffffffff")]
    [TestCase(123, "7b")]
    public void Test(int n, string expected)
    {
        var actual = new ToHexTask().ToHex(n);
        ClassicAssert.AreEqual(expected, actual);
    }
}