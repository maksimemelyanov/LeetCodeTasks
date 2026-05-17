using System.Text;
using NUnit.Framework;

namespace LeetCodeTestApp;

public class ConvertTask
{
    public string Convert(string s, int numRows)
    {
        if (numRows == 1 || s.Length <= numRows)
            return s;
        var n = s.Length;
        var strings = new StringBuilder[numRows];
        for (var k = 0; k < numRows; k++)
        {
            strings[k] = new StringBuilder();
        }
        var columns = 1000;
        var column = 0;
        var i = 0;
        while (column < columns && i < n)
        {
            for (var r = 0; r < numRows && i < n; r++)
            {
                strings[r].Append(s[i]);
                i++;
            }

            var row = numRows - 2;
                column++;
            while (row > 0 && i < n)
            {
                strings[row].Append(s[i]);
                i++;
                row--;
                column++;
            }
        }

        var sb = new StringBuilder();
        for (var r = 0; r < numRows; r++)
        {
            sb.Append(strings[r]);
        }
        return sb.ToString();
    }
}

public class ConvertTask_Tests
{
    [Test]
    [TestCase("PAYPALISHIRING", 3, "PAHNAPLSIIGYIR")]
    [TestCase("PAYPALISHIRING", 4, "PINALSIGYAHRPI")]
    [TestCase("A", 1, "A")]
    [TestCase("A", 3, "A")]
    [TestCase("AB", 1, "AB")]
    [TestCase("ABCDE", 2, "ACEBD")]
    [TestCase("PAYPALISHIRING", 7, "PNAIGYRPIAHLSI")]
    public void Test(string s, int numRows, string expected)
    {
        var actual = new ConvertTask().Convert(s, numRows);
        Assert.That(actual, Is.EqualTo(expected));
    }
}