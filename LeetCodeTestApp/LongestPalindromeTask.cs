using NUnit.Framework;

namespace LeetCodeTestApp;

public class LongestPalindromeTask
{
    public string LongestPalindrome(string s)
    {
        if (string.IsNullOrEmpty(s) || s.Length < 1)
            return "";
        var start = 0;
        var maxLength = 0;
        for (var i = 0; i < s.Length; i++)
        {
            var odd = ExpandAroundCenter(s, i, i);
            var even = ExpandAroundCenter(s, i, i + 1);
            var len =  Math.Max(odd, even);
            if (len > maxLength)
            {
                maxLength = len;
                start = i - (len - 1) / 2;
            }
        }
        return s.Substring(start, maxLength);
    }

    private int ExpandAroundCenter(string s, int left, int right)
    {
        while (left >= 0 && right < s.Length && s[left] == s[right]) // cbbd
        {
            left--;
            right++;
        }

        return right - left - 1;
    }
}

public class LongestPalindromeTask_Tests
{
    [Test]
    [TestCase("babad", "bab")]
    [TestCase("cbbd", "bb")]
    public void Test(string input, string expected)
    {
        var result = new LongestPalindromeTask().LongestPalindrome(input);
        Assert.That(result, Is.EqualTo(expected));
    }
}