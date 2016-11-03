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
            Assert.That(MinLength(graph, "A", "Z"), Is.EqualTo(length));
            Assert.That(MinPath(graph, "A", "Z"), Is.EqualTo(path));
        }

        private int MinLength(string graph, string begin, string end)
        {
            return 0;
        }

        private string MinPath(string graph, string begin, string end)
        {
            return "{}";
        }
    }
}
