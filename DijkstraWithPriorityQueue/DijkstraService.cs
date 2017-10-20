using System.Collections.Generic;
using System.Linq;

namespace DijkstraWithPriorityQueue
{
    public static class DijkstraService
    {
        public static void InitializeGraph(List<Edge>[] graph)
        {
            for (int i = 0; i < graph.Length; i++)
            {
                graph[i] = new List<Edge>();
            }
        }

        public static void AddEdgeToGraph(List<Edge>[] graph, Node[] nodes, int firstId, int secondId, int weight)
        {
            var firstNode = new Node(firstId);
            nodes[firstId] = firstNode;

            var secondNode = new Node(secondId);
            nodes[secondId] = secondNode;

            graph[firstId].Add(new Edge(secondId, weight));
            graph[secondId].Add(new Edge(firstId, weight));
        } 

        public static void CleanDijkstraDistance(Node[] nodes)
        {
            foreach (var node in nodes)
            {
                if (node != null)
                {
                    node.ResetDistance();
                }
            }
        }

        public static void Dijkstra(List<Edge>[] graph, Node[] nodes, int startNodeId)
        {
            var queue = new PriorityQueue<Node>();

            nodes[startNodeId].Distance = 0;
            queue.Enqueue(nodes[startNodeId]);
            var used = new bool[nodes.Length];

            while (queue.Count > 0)
            {
                var currentNode = queue.Dequeue();
                for (int i = 0; i < graph[currentNode.Id].Count(); i++)
                {
                    var edge = graph[currentNode.Id][i];

                    var newDistance = currentNode.Distance + edge.Distance;

                    if (!used[edge.DestinationNodeId] && newDistance < nodes[edge.DestinationNodeId].Distance)
                    {
                        nodes[edge.DestinationNodeId].Distance = newDistance;
                        queue.Enqueue(nodes[edge.DestinationNodeId]);
                    }
                }

                used[currentNode.Id] = true;
            }
        }

        public static int ComputeDistance(Node[] nodes)
        {
            int currentResult = 0;

            foreach (var node in nodes)
            {
                if (node != null && !node.IsHospital)
                {
                    currentResult += node.Distance;
                }
            }

            return currentResult;
        }
    }
}
