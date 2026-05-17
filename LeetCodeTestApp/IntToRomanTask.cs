using System.Text;
using NUnit.Framework;

namespace LeetCodeTestApp;

public class IntToRomanTask
{
    public string IntToRoman(int num)
    {
        var values = new int[] { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
        var symbols = new string[] {"M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I"};
        var sb = new StringBuilder();
        for (var i = 0; i < values.Length && num > 0; i++)
        {
            while (num >= values[i])
            {
                num -= values[i];
                sb.Append(symbols[i]);
            }
        }

        return sb.ToString();

    }
}

public class IntToRomanTask_Tests
{
    [Test]
    [TestCase(3749,"MMMDCCXLIX")]
    [TestCase(58,"LVIII")]
    [TestCase(1994,"MCMXCIV")]
    public void Test(int num, string expected)
    {
        var resuult = new IntToRomanTask().IntToRoman(num);
        Assert.That(resuult, Is.EqualTo(expected));
    }
}