using NUnit.Framework;

namespace DijkstrasAlgorithm.Tests
{
    [TestFixture]
    public class MinPathTest
    {
        [Test]
        public void NoGraph_NoPathZeroLength()
        {
            AssertPath("", "{}0");
        }

        private void AssertPath(string graph, string expected)
        {
            Assert.That(MinPath(graph, "A", "Z"), Is.EqualTo(expected));
        }

        private string MinPath(string graph, string begin, string end)
        {
            return "{}0";
        }
    }
}
