using System.Collections.Generic;
using System.Linq;

namespace DijkstrasAlgorithm
{
    public class PathFinder
    {
        private List<Edge> _edges = new List<Edge>();

        public int MinLength(string begin, string end)
        {
            return _edges.Where(e => e.Begin.Equals(begin) && e.End.Equals(end)).Sum(e => e.Length);
        }

        public string MinPath(string begin, string end)
        {
            return "{}";
        }

        public void AddEdge(string begin, string end, int length)
        {
            _edges.Add(new Edge(begin, end, length));
        }

        private class Edge
        {
            public readonly string Begin;
            public readonly string End;
            public readonly int Length;

            public Edge(string begin, string end, int length)
            {
                this.Begin = begin;
                this.End = end;
                this.Length = length;
            }
        }
    }
}