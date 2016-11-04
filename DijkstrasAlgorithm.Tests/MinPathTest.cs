using System.Text.RegularExpressions;
using System.Xml.Schema;
using NUnit.Framework;

namespace DijkstrasAlgorithm.Tests
{
    [TestFixture]
    public class MinPathTest
    {
        [Test]
        public void NoGraph_NoPathZeroLength()
        {
            AssertMinPath("", 0, "[]");     // empty graph
            AssertMinPath("A", 0, "[]");    // one node
            AssertMinPath("BC1", 0, "[]");  // no start or end
            AssertMinPath("AC1", 0, "[]");  // no end
            AssertMinPath("BZ1", 0, "[]");  // no start
        }

        [Test]
        public void OneEdge()
        {
            AssertMinPath("AZ1", 1, "[A, Z]");
            AssertMinPath("AZ2", 2, "[A, Z]");
        }

        [Test]
        public void TwoEdges()
        {
            AssertMinPath("AB1,BZ1", 2, "[A, B, Z]");
        }

        private void AssertMinPath(string graph, int length, string path)
        {
            var pf = MakePathFinder(graph);
            if (length > 0)
                Assert.That(pf.GetLength(), Is.EqualTo(length));
            if (!string.IsNullOrEmpty(path))
                Assert.That(pf.GetPath(), Is.EqualTo(path));
        }

        private PathFinder MakePathFinder(string graph)
        {
            var pf = new PathFinder();
            var edgePattern = new Regex("(\\D+)(\\D+)(\\d+)");
            var edges = graph.Split(',');
            foreach (var edge in edges)
            {
                if (edgePattern.IsMatch(edge))
                {
                    var begin = edgePattern.Replace(edge, "$1");
                    var end = edgePattern.Replace(edge, "$2");
                    var length = int.Parse(edgePattern.Replace(edge, "$3"));
                    pf.AddEdge(begin, end, length);
                }
            }
            pf.FindPath("A", "Z");
            return pf;
        }
    }
}
