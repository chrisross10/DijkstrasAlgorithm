using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DijkstrasAlgorithm
{
    public class PathFinder
    {
        private readonly List<Edge> _edges = new List<Edge>();
        private List<string> _path = new List<string>();
        private int _length;

        public void FindPath(string begin, string end)
        {
            List<string> p = new List<string>();
            int l = 0;
            p.Add(begin);

            for (Edge e = FindEdge(begin); e != null; e = FindEdge(e.End))
            {
                p.Add(e.End);
                l += e.Length;
                if (e.End.Equals(end))
                {
                    _length = l;
                    _path = p;
                    return;
                }
            }
        }

        private Edge FindEdge(string begin)
        {
            return _edges.FirstOrDefault(e => e.Begin.Equals(begin));
        }

        public void AddEdge(string begin, string end, int length)
        {
            _edges.Add(new Edge(begin, end, length));
        }

        public int GetLength()
        {
            return _length;
        }

        public string GetPath()
        {
            var sb = new StringBuilder();
            sb.Append("[");
            foreach (var p in _path)
            {
                sb.AppendFormat("{0}, ", p);
            }
            sb.Append("]");
            sb.Replace(", ]", "]");
            return sb.ToString();
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