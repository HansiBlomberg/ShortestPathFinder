﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public List<Node> GetShortestPathBetweenNodes(List<Node> nodes, Node start, Node end)
        {

            // I decided to run the Dijkstra backwards, might be confusing sorry
            Dijkstra(nodes, end);
            var returnNodes = new List<Node>();


            // returnNodes skall vara tom om det inte finns någon start.PreviousID
            // Return an empty nodes list if there is no start.PreviousID (remember, swapped start/end)
            if (start.PreviousID == null) return returnNodes;

            // returnNodes skall bara ha ett värde om PreviousID = end
            // Return a nodes list with just one item if PreviousID = end (remember, swapped start/end)
            if (start.PreviousID == end.ID)
            {
                returnNodes.Add(start);
                return returnNodes;
            }

            // returnNodes skall ha alla noder inkl start och end om det finns noder mellan

            var nextNodeInPath = start; // Because we ran Dijkstra with swapped start/end, start from parameters is now at the end
            returnNodes.Add(nextNodeInPath); 
            do
            {
                nextNodeInPath = nodes.Where(n => n.ID == nextNodeInPath.PreviousID).Single();
                returnNodes.Add(nextNodeInPath);
                
            } while (nextNodeInPath.ID != end.ID);


            return returnNodes;
            
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="start">Starting Node</param>
        
        /// /// <param name="nodes">List of nodes in the graph to be searched</param>
        
        private void Dijkstra(List<Node> nodes, Node start )
        {

          
            var unoptimizedNodes = new List<Node>();
            foreach (var node in nodes)
            {
                node.Distance = null; // null is for infinity
                if (node.ID == start.ID) node.Distance = 0;
                node.PreviousID = null; // null is for undefined previous neighbor

                
                unoptimizedNodes.Add(node);

            }
            
            while(unoptimizedNodes.Count > 0)
            {
                
                var node = NodeWithShortestDistance(unoptimizedNodes);
                unoptimizedNodes.Remove(node);
                foreach(var neighbourID in node.NeighborIDs)
                {
                    var neighbourNode = nodes.Where(n => n.ID == neighbourID).Single();
                    // what if node.distance = null
                    if (node.Distance != null)
                    {
                        var alternativeDistance = node.Distance + 1;
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
            // Node smallestDistanceNode = nodes.Where(n => n.Distance != null).First();
            Node smallestDistanceNode = nodes.First();
            if (smallestDistanceNode == null) return null;
            foreach(var node in nodes.Where(n=>n.Distance != null))
            {
                if (node.Distance < smallestDistanceNode.Distance) smallestDistanceNode = node;
            }
            return smallestDistanceNode;

        }




    }
}


/* PSEUDO CODE
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