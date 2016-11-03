using NUnit.Framework;

namespace DijkstrasAlgorithm.Tests
{
    [TestFixture]
    public class MinPathTest
    {
        [Test]
        public void NoGraph_NoPathZeroLength()
        {
            Assert.That(MinPath(""), Is.EqualTo("{}0"));
        }

        private string MinPath(string graph)
        {
            return "{}0";
        }
    }
}
