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

        private void AssertMinPath(string graph, int length, string path)
        {
            var pf = new PathFinder(graph);
            Assert.That(pf.MinLength("A", "Z"), Is.EqualTo(length));
            Assert.That(pf.MinPath("A", "Z"), Is.EqualTo(path));
        }
    }
}
