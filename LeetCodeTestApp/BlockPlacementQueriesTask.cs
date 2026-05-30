using NUnit.Framework;

namespace LeetCodeTestApp;

public class BlockPlacementQueriesTask
{
    public IList<bool> GetResults(int[][] queries) 
    {
        var maxX = queries.Max(q => q[1])+1;
        
        var borders = new SortedSet<int> { 0 };
        var tree = new SegmentTree(maxX);
        var result = new List<bool>();
        foreach (var q in queries)
        {
            if (q[0] == 1)
            {
                var x = q[1];
                var r = borders.GetViewBetween(x, maxX).FirstOrDefault();
                if (r == 0)
                    r = maxX;
                var l = borders.GetViewBetween(0, x).LastOrDefault();
                if (r != maxX)
                {
                    var gap = r - x;
                    tree.Update(r, gap);
                }
                tree.Update(x, x-l);
                borders.Add(x);
            }
            else
            {
                var x = q[1];
                var sz = q[2];
                var l = borders.GetViewBetween(0, x).LastOrDefault();
                var gap = tree.Query(0, l);
                var tail = x - gap;
                result.Add(Math.Max(gap, tail) >= sz);
            }
        }

        return result;
    }

    class SegmentTree
    {
        private int[] tree;
        private int size;

        public SegmentTree(int size)
        {
            this.size = size;
            tree = new int[1000*size];
        }
        
        public void Update(int index, int value)
        {
            Update(1, index, 0, size, value);
        }

        private void Update(int node, int index, int left, int right, int value)
        {
            if (left == right)
            {
                tree[node] = value;
                return;
            }
            var mid = (left + right) / 2;
            if (index <= mid)
                Update(node * 2, index, left, mid, value);
            else
                Update(node * 2 + 1, index, mid + 1, right, value);
            
            tree[node] = Math.Max(tree[node * 2], tree[node * 2 + 1]);
        }

        public int Query(int left, int right)
        {
            if (left > right)
                return 0;
            return Query(1, 0, size, left, right);
        }

        private int Query(int node, int left, int right, int queryLeft, int queryRight)
        {
            if (queryLeft > right || queryRight < left)
                return 0;
            if (queryLeft <= left && right <= queryRight)
                return tree[node];
            var mid = (left + right) / 2;
            return Math.Max(Query(node*2, left, mid, queryLeft, queryRight), Query(node * 2 + 1, mid+1, right, queryLeft, queryRight));
        }
    }
}

public class BlockPlacementQueriesTask_Tests
{
    public static IEnumerable<TestCaseData> test_cases()
    {
        yield return new TestCaseData(new int[][] { [2, 1, 1] }, new bool[] { true });
        yield return new TestCaseData(new int[][] { [2, 1, 2] }, new bool[] { false });
        yield return new TestCaseData(new int[][] { [1,1],[2,4,3] }, new bool[] { true });
        yield return new TestCaseData(new int[][] { [1, 2], [2, 3, 3], [2, 3, 1], [2, 2, 2] }, new bool[]{false, true, true} );
        yield return new TestCaseData(new int[][] { [1, 2], [2, 3, 3], [2, 3, 1], [2, 2, 2] }, new bool[]{false, true, true} );
        yield return new TestCaseData(new int[][] { [1,7],[2,7,6],[1,2],[2,7,5],[2,7,6] }, new bool[]{true, true, false} );
    }
    [Test]
    [TestCaseSource("test_cases")]
    public void Test(int[][] queries, bool[] expected)
    {
        var actual = new BlockPlacementQueriesTask().GetResults(queries);
        Assert.That(actual.Count, Is.EqualTo(expected.Length));
        for (var i = 0; i < actual.Count; i++)
        {
            Assert.That(actual[i], Is.EqualTo(expected[i]));
        }
    }
}