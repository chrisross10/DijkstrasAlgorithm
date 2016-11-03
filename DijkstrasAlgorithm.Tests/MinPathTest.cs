using NUnit.Framework;

namespace DijkstrasAlgorithm.Tests
{
    [TestFixture]
    public class MinPathTest
    {
        [Test]
        public void NoGraph_NoPathZeroLength()
        {
            AssertMinPath("", 0, "{}");
        }

        private void AssertMinPath(string graph, int length, string path)
        {
            var pf = new PathFinder(graph);
            Assert.That(pf.MinLength("A", "Z"), Is.EqualTo(length));
            Assert.That(pf.MinPath("A", "Z"), Is.EqualTo(path));
        }
    }
}
