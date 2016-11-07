namespace DijkstrasAlgorithm
{
    public class Edge
    {
        public readonly string Begin;
        public readonly string End;
        public readonly int Length;

        public Edge(string begin, string end, int length)
        {
            Begin = begin;
            End = end;
            Length = length;
        }
    }
}