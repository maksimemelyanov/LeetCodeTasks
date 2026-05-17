using NUnit.Framework;

namespace LeetCodeTestApp;

public class MyAtoiTask
{
    public int MyAtoi(string s)
    {
        var i = 0;
        var result = 0;
        var isMinus = false;
        while (i < s.Length && s[i] == ' ')
            i++;
        if (i >= s.Length)
            return 0;
        if (s[i] == '-')
        {
            isMinus = true;
            i++;
        }
        else if (s[i] == '+')
        {
            isMinus = false;
            i++;
        }

        while (i < s.Length && (s[i] >= '0' && s[i] <= '9'))
        {
            int digit = s[i] - '0';
            if (result > (int.MaxValue - digit) / 10)
                return isMinus ? int.MinValue : int.MaxValue;
            result = result * 10 + digit;
            i++;
        }
        if (result > 0)
            return result * (isMinus ? -1 : 1);
        return result;
    }
}

public class MyAtoiTask_Tests
{
    [Test]
    [TestCase("42", 42)]
    [TestCase("-042", -42)]
    [TestCase("1337c0d3", 1337)]
    [TestCase("0-1", 0)]
    [TestCase("words and 987", 0)]
    [TestCase("-9128347233", int.MinValue)]
    public void Test(string input, int expected)
    {
        var result = new MyAtoiTask().MyAtoi(input);
        Assert.That(result, Is.EqualTo(expected));
    }
}