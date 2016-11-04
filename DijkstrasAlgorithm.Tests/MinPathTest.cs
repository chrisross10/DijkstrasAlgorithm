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
            AssertMinPath("", 0, "{}");     // empty graph
            AssertMinPath("A", 0, "{}");    // one node
            AssertMinPath("BC1", 0, "{}");  // no start or end
            AssertMinPath("AC1", 0, "{}");  // no end
            AssertMinPath("BZ1", 0, "{}");  // no start
        }

        [Test]
        public void OneEdge()
        {
            AssertMinPath("AZ1", 1, ANY);
        }

        private string ANY = null;

        private void AssertMinPath(string graph, int length, string path)
        {
            var pf = MakePathFinder(graph);
            if (length > 0)
                Assert.That(pf.MinLength("A", "Z"), Is.EqualTo(length));
            if (!string.IsNullOrEmpty(path))
                Assert.That(pf.MinPath("A", "Z"), Is.EqualTo(path));
        }

        private PathFinder MakePathFinder(string graph)
        {
            var pf = new PathFinder();
            var edgePattern = new Regex("(\\D+)(\\D+)(\\d+)");
            if (edgePattern.IsMatch(graph))
            {
                var begin = edgePattern.Replace(graph, "$1");
                var end = edgePattern.Replace(graph, "$2");
                var length = int.Parse(edgePattern.Replace(graph, "$3"));
                pf.AddEdge(begin, end, length);
            }
            return pf;
        }
    }
}
