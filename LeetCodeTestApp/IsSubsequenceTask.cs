using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace LeetCodeTestApp;

// 392
public class IsSubsequenceTask
{
    public bool IsSubsequence(string s, string t)
    {
        var sIndex = 0;
        var tIndex = 0;
        var sLength = s.Length;
        var tLength = t.Length;
        while (sIndex < sLength && tIndex < tLength)
        {
            if (s[sIndex] == t[tIndex])
                sIndex++;
            tIndex++;
        }

        return sIndex == sLength;
    }
}

[TestFixture]
public class IsSubsequenceTask_Tests
{
    [Test]
    [TestCase("abc", "ahbgdc", true)]
    [TestCase("axc", "ahbgdc", false)]
    public void Test(string s, string t, bool expected)
    {
        var result = new IsSubsequenceTask().IsSubsequence(s, t);
        ClassicAssert.AreEqual(expected, result);
    }
}