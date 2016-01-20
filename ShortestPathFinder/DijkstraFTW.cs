using System;
using System.Collections.Generic;
using System.Linq;

namespace NodeTransportationLimited.Graphs
{
    /// <summary>
    /// Finds the shortest path between two graph nodes in a set of graph nodes
    /// using Dijkstra algorithm
    /// </summary>
    public class DijkstraFTW
    {
        /// <summary>
        /// Returns a List of Node in order of the shortest path between begin and end inclusive
        /// </summary>
        /// <param name="nodes">List of nodes in the graph to be searched</param>
        /// <param name="start">Start Node</param>
        /// <param name="end">End Node</param>
        /// <returns></returns>
        public List<Node> GetShortestPathBetweenNodes(List<Node> nodes, int start, int end)
        {
            var returnNodes = new List<Node>();

            // Handle the case of start or end not existing in the nodes list
            // This will happen because we only create nodes with paths
            // but the user might enter a start or end node that does not have a path.
            // We can just return an empty list of notes, unless start = end where we
            // will return that one node.
            if (!nodes.Exists(n => n.ID == start) || !nodes.Exists(n => n.ID == end))
            {
                if (start == end) returnNodes.Add(new Node(start));
                return returnNodes;
            }

            var startNode = nodes.Where(n => n.ID == start).Single();
            var endNode = nodes.Where(n => n.ID == end).Single();

            // If start node and end node is the same, we can cheat
            if (start == end)
            {
                returnNodes.Add(startNode);
                return returnNodes;
            }

            Dijkstra(nodes, startNode);
            var nodeStack = new Stack<Node>();
            
            // Return an empty nodes list if there is no end.PreviousID
            // This handles the case when there is no path from endNode towards startnode.
            if (endNode.PreviousID == null) return returnNodes;

            // returnNodes skall ha alla noder inkl start och end om det finns noder mellan
            var nextNodeInPath = endNode;
            nodeStack.Push(nextNodeInPath);

            do
            {
                nextNodeInPath = nodes.Where(n => n.ID == nextNodeInPath.PreviousID).Single();
                nodeStack.Push(nextNodeInPath);

            } while (nextNodeInPath.ID != startNode.ID);

            foreach (var node in nodeStack) returnNodes.Add(node);

            return returnNodes;
        }
        
        private void Dijkstra(List<Node> nodes, Node start)
        {
            var unoptimizedNodes = new List<Node>();

            foreach (var node in nodes)
            {
                node.Distance = null; // null is for infinity
                if (node.ID == start.ID) node.Distance = 0;
                node.PreviousID = null; // null is for undefined previous neighbor
                unoptimizedNodes.Add(node);
            }

            while (unoptimizedNodes.Count > 0)
            {
                var node = NodeWithShortestDistance(unoptimizedNodes);
                unoptimizedNodes.Remove(node);

                foreach (var neighbour in node.Neighbours)
                {
                    var neighbourNode = nodes.Where(n => n.ID == neighbour.ID).Single();

                    if (node.Distance != null)
                    {
                        var alternativeDistance = node.Distance + neighbour.Weight;
                        if (alternativeDistance < neighbourNode.Distance || neighbourNode.Distance == null)
                        {
                            neighbourNode.Distance = alternativeDistance;
                            neighbourNode.PreviousID = node.ID;
                        }
                    }
                }
            }
        }

        private Node NodeWithShortestDistance(List<Node> nodes)
        {
            Node smallestDistanceNode = nodes.FirstOrDefault();
            if (smallestDistanceNode == null) throw new ArgumentOutOfRangeException("List<Node> nodes", "Please dont call me with an empty list!");
            foreach (var node in nodes.Where(n => n.Distance != null))
            {
                if (node.Distance < smallestDistanceNode.Distance || smallestDistanceNode.Distance == null) smallestDistanceNode = node;
            }
            return smallestDistanceNode;
        }
    }
}


/* PSEUDO CODE FOR DIKSTRA ALGORITHM
  	function Dijkstra(Graph, source):
2: 	for each vertex v in Graph: 	// Initialization
3: 	dist[v] := infinity 	// initial distance from source to vertex v is set to infinite
4: 	previous[v] := undefined 	// Previous node in optimal path from source
5: 	dist[source] := 0 	// Distance from source to source
6: 	Q := the set of all nodes in Graph 	// all nodes in the graph are unoptimized - thus are in Q
7: 	while Q is not empty: 	// main loop
8: 	u := node in Q with smallest dist[ ]
9: 	remove u from Q
10: 	for each neighbor v of u: 	// where v has not yet been removed from Q.
11: 	alt := dist[u] + dist_between(u, v)
12: 	if alt < dist[v] 	// Relax (u,v)
13: 	dist[v] := alt
14: 	previous[v] := u
15: 	return previous[ ] 

    */
