using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DijkstrasAlgorithm
{
    public class PathFinder
    {
        private readonly List<Edge> _edges = new List<Edge>();
        private readonly HashSet<string> _nodeNames = new HashSet<string>();
        private readonly Dictionary<string, Node> _nodes = new Dictionary<string, Node>();
        private Node _endNode;

        public void FindPath(string begin, string end)
        {
            var unvisited = InitializeSearch(begin, end);

            for (var node = begin; node != null; node = GetNext(unvisited))
            {
                unvisited.Remove(node);
                Visit(node);
            }

            SetupEndNode(end);
        }

        private List<string> InitializeSearch(string begin, string end)
        {
            _nodeNames.Add(begin);
            _nodeNames.Add(end);
            var unvisited = new List<string>(_nodeNames);
            foreach (var node in unvisited)
                _nodes.Add(node, new Node(int.MaxValue));

            _nodes[begin].Length = 0;
            return unvisited;
        }

        private void Visit(string node)
        {
            var neighbours = FindEdges(node);
            var curNode = _nodes[node];
            foreach (var e in neighbours)
            {
                var nbr = _nodes[e.End];

                var newLength = curNode.Length + e.Length;
                if (nbr.Length > newLength)
                {
                    nbr.Length = newLength;
                    nbr.Path = new List<string>();
                    nbr.Path.AddRange(curNode.Path);
                    nbr.Path.Add(node);
                }
            }
        }

        private void SetupEndNode(string end)
        {
            _endNode = _nodes[end];
            if (_endNode.Length != int.MaxValue)
                _endNode.Path.Add(end);
            else
                _endNode.Length = 0;
        }

        private string GetNext(IEnumerable<string> unvisited)
        {
            foreach (var name in unvisited)
            {
                var candidate = _nodes[name];
                if (candidate.Length != int.MaxValue)
                    return name;
            }
            return null;
        }

        private IEnumerable<Edge> FindEdges(string begin)
        {
            return _edges.Where(e => e.Begin.Equals(begin)).ToList();
        }

        public int GetLength()
        {
            return _endNode.Length;
        }

        public string GetPath()
        {
            var sb = new StringBuilder();
            sb.Append("[");
            foreach (var p in _endNode.Path)
            {
                sb.AppendFormat("{0}, ", p);
            }
            sb.Append("]");
            sb.Replace(", ]", "]");
            return sb.ToString();
        }

        public void AddEdge(string begin, string end, int length)
        {
            _edges.Add(new Edge(begin, end, length));
            _nodeNames.Add(begin);
            _nodeNames.Add(end);
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

        private class Node
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
}