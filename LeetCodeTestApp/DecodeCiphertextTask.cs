using System.Text;
using NUnit.Framework;

namespace LeetCodeTestApp;

public class DecodeCiphertextTask
{
    public string DecodeCiphertext(string encodedText, int rows) 
    {
        var columns = encodedText.Length / rows;
        var sb = new StringBuilder();
        for (var x = 0; x < columns; x++)
        {
            for (var y = 0; y < rows && y + x < columns; y++)
            {
                sb.Append(encodedText[y * (columns + 1) + x]);
            }
        }
        while(sb.Length > 0 && sb[^1] == ' ')
            sb.Remove(sb.Length - 1, 1);
        return sb.ToString();
    }
}

public class DecodeCiphertextTask_Tests
{
    [Test]
    [TestCase("ch   ie   pr", 3, "cipher")]
    [TestCase("iveo    eed   l te   olc", 4, "i love leetcode")]
    [TestCase("coding", 1, "coding")]
    public void Test(string encoded, int rows, string expected)
    {
        var actual = new DecodeCiphertextTask().DecodeCiphertext(encoded, rows);
        Assert.That(actual, Is.EqualTo(expected));


    }
}