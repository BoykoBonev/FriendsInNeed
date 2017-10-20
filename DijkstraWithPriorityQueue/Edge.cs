namespace DijkstraWithPriorityQueue
{
    public class Edge
    {
        public Edge(int distanceNodeId, int distance)
        {
            this.DestinationNodeId = distanceNodeId;
            this.Distance = distance;
        }

        public int DestinationNodeId
        {
            get;
            set;
        }

        public int Distance
        {
            get;
            set;
        }
    }
}
