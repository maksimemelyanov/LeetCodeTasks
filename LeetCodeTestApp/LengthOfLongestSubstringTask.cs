using NUnit.Framework;

namespace LeetCodeTestApp;

public class LengthOfLongestSubstringTask
{
    public int LengthOfLongestSubstring(string s)
    {
        var set = new HashSet<char>();
        var left = 0;
        var maxLength = 0;
        for (var right = 0; right < s.Length; right++)
        {
            while (set.Contains(s[right]))
            {
                set.Remove(s[left]);
                left++;
            }
            set.Add(s[right]);
            maxLength = Math.Max(maxLength, right - left + 1);
        }

        return maxLength;
    }
}

public class LengthOfLongestSubstringTask_Tests
{
    [Test]
    [TestCase("abcabcbb", 3)]
    [TestCase("bbbbb", 1)]
    [TestCase("pwwkew", 3)]
    public void Test(string input, int expected)
    {
        var result = new LengthOfLongestSubstringTask().LengthOfLongestSubstring(input);
        Assert.That(result, Is.EqualTo(expected));
    }
}