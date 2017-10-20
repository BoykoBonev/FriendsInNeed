using System;
namespace DijkstraWithPriorityQueue
{
    public class Node : IComparable<Node>
    {
        private const int defaultDijkstraDistance = int.MaxValue;
        public Node(int id, int distance = defaultDijkstraDistance, bool isHospital = false)
        {
            this.Id = id;
            this.Distance = distance;
            this.IsHospital = isHospital;
        }

        public int Id { get; set; }

        public int Distance { get; set; }

        public int CompareTo(Node other)
        {
            return this.Distance.CompareTo(other.Distance);
        }
      
        public bool IsHospital
        {
            get;
            set;
        }

        public void ResetDistance()
        {
            this.Distance = defaultDijkstraDistance;
        }

    }
}
