using NUnit.Framework;

namespace LeetCodeTestApp;

public class LadderLengthTask
{
    public int LadderLength(string beginWord, string endWord, IList<string> wordList)
    {
        var words = new List<string>(wordList) { beginWord };
        var wordLength = beginWord.Length;
        var adjustments = new Dictionary<string, List<string>>();
        for (var i = 0; i < words.Count; i++)
        {
            for (var j = 0; j < wordLength; j++)
            {
                var mask = words[i].Substring(0, j) + '*' + words[i].Substring(j + 1, wordLength - j - 1);
                if (!adjustments.ContainsKey(mask))
                    adjustments.Add(mask, new List<string>());
                adjustments[mask].Add(words[i]);
            }
        }
        var queue = new Queue<(string, int)>();
        queue.Enqueue((beginWord, 1));
        var visited = new HashSet<string> { beginWord };
        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            for (var i = 0; i < wordLength; i++)
            {
                var mask = current.Item1[..i] + '*' + current.Item1.Substring(i + 1, wordLength - i - 1);
                foreach (var word in adjustments[mask])
                {
                    if (word == endWord)
                        return current.Item2 + 1;
                    if (visited.Add(word))
                    {
                        queue.Enqueue((word, current.Item2 + 1));
                    }
                }
            }
        }

        return 0;
    }
}

public class LadderLengthTask_Tests
{
    [Test]
    [TestCase("hit", "cog", new string[] {"hot","dot","dog","lot","log","cog"}, 5)]
    [TestCase("hit", "cog", new string[] {"hot","dot","dog","lot","log"}, 0)]
    public void Test(string beginWord, string endWord, string[] wordList, int expected)
    {
        var actual = new LadderLengthTask().LadderLength(beginWord, endWord, wordList);
        Assert.That(actual, Is.EqualTo(expected));
    }
}