using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace LeetCodeTestApp;

public class IsValidTask
{
    public bool IsValid(string s)
    {
        var pairs = new Dictionary<char, char>();
        pairs.Add('(', ')');
        pairs.Add('[', ']');
        pairs.Add('{', '}');
        var stack = new Stack<char>();
        foreach (var c in s)
        {
            if (pairs.ContainsKey(c))
                stack.Push(c);
            else if (stack.TryPop(out var open))
            {
                if (pairs[open] != c)
                    return false;
            }
            else return false;
        }

        return stack.Count == 0;
    }
}

public class IsValidTask_Tests
{
    [Test]
    [TestCase("()", true)]
    [TestCase("()[]{}", true)]
    [TestCase("(]", false)]
    [TestCase("([])", true)]
    [TestCase("([)]", false)]
    public void Test(string input, bool expected)
    {
        var result = new IsValidTask().IsValid(input);
        ClassicAssert.AreEqual(expected, result);
    }
}
