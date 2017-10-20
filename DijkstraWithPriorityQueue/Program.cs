using System;
using System.Linq;
using System.Collections.Generic;

namespace DijkstraWithPriorityQueue
{
	class MainClass
	{
		public static void Main()
		{
            var firstImputLine = Console.ReadLine().Split(' ');
            var nodesCount = int.Parse(firstImputLine[0]);
            var streetsCount = int.Parse(firstImputLine[1]);

            var hostpitalNodes = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            List<Edge>[] graph = new List<Edge>[nodesCount + 1];
            Node[] nodes = new Node[nodesCount + 1];

            DijkstraService.InitializeGraph(graph);

            for (int i = 0; i < streetsCount; i++)
            {
                var currentStreetInfo = Console.ReadLine().Split(' ');
                var firstStreetNodeId = int.Parse(currentStreetInfo[0]) ;
                var secondStreetNodeId = int.Parse(currentStreetInfo[1]) ;
                var weight = int.Parse(currentStreetInfo[2]);

                DijkstraService.AddEdgeToGraph(graph,nodes, firstStreetNodeId, secondStreetNodeId, weight);
            }

            foreach (var hospitalId in hostpitalNodes)
            {
                nodes[hospitalId].IsHospital = true;
            }

            int minDistance = int.MaxValue;
            foreach (var hospitalId in hostpitalNodes)
            {
                DijkstraService.Dijkstra(graph, nodes, hospitalId);

                var currentResult = DijkstraService.ComputeDistance(nodes);

                if(currentResult < minDistance) {
                    minDistance = currentResult;
                }

                DijkstraService.CleanDijkstraDistance(nodes);
            }

            Console.WriteLine(minDistance);
        }
	};
};