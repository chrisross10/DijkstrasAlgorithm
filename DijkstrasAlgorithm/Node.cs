using System.Collections.Generic;

namespace DijkstrasAlgorithm
{
    public class Node
    {
        public int Length;
        public List<string> Path;

        public Node(int l)
        {
            Length = l;
            Path = new List<string>();
        }
    }
}