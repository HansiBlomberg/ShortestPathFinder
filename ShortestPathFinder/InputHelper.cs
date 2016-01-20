using System.Collections.Generic;
using System.Linq;

namespace NodeTransportationLimited.Graphs
{
    /// <summary>
    /// Some helper methods for the Get Shortest Path application
    /// </summary>
    public static class InputHelper
    {
        // God knows why, but the application is only allowed to handle a maximum of 512 nodes.
        // Maybe because the MS DOS command line lenght is limited to 2048 or so characters?
        private const int MAX_ALLOWED_NODES = 512;
        private const int MAX_ALLOWED_EDGES = 262144;
        /// <summary>
        /// Checks if the number of nodes is within the specified
        /// range.
        /// </summary>
        /// <param name="numberOfNodes"></param>
        /// <returns>True if the number of nodes is acceptable</returns>
        public static bool IsNumberOfNodesValid(int numberOfNodes)
        {
            if (numberOfNodes < 1 || numberOfNodes > MAX_ALLOWED_NODES) return false;
            return true;
        }
        /// <summary>
        /// Check if the start node and end node seem valid
        /// </summary>
        /// <param name="numberOfNodes">Number of nodes in the graph</param>
        /// <param name="startNode">Start node</param>
        /// <param name="endNode">End node</param>
        /// <returns>True if the start node and end node are valid nodes</returns>
        public static bool IsStartAndEndNodesValid(int numberOfNodes, int startNode, int endNode)
        {
            // We dont create all nodes, only nodes that have neighbours
            // if (nodes.Exists(n => n.ID == startNode) && nodes.Exists(n => n.ID == endNode)) return true;
            if (startNode >= 0 && startNode < numberOfNodes && endNode >= 0 && endNode < numberOfNodes) return true;
            return false;
        }
        /// <summary>
        /// Parses the input string and returns true if successful with the beginValue and endValue set correctly
        /// Returns false if not successful, if so the beginValue and endValue is both set to 0
        /// </summary>
        /// <param name="input">String with the first and last node in the path as numbers with a space between</param>
        /// <param name="beginValue">Beginning of path</param>
        /// <param name="endValue">End of path</param>
        /// <returns></returns>
        public static bool ParseBeginAndEndNodes(string input, out int beginValue, out int endValue)
        {
            beginValue = 0;
            endValue = 0;
            // 3: En textsträng med två heltal, som är mindre än antalet noder från första strängen(eftersom första noden är 0).
            // Talen är skilda med mellanslag
            // Exempel 0 4
            var splittedInput = input.Trim().Split(' ');
            if (splittedInput.Count() != 2) return false;
            if (!int.TryParse(splittedInput[0], out beginValue)) return false;
            if (!int.TryParse(splittedInput[1], out endValue)) return false;
            return true;
        }
        /// <summary>
        /// Returns a string representation of a list of nodes
        /// </summary>
        /// <param name="nodes"></param>
        /// <returns>a string representation of a list of nodes</returns>
        public static string StringifyNodes(List<Node> nodes)
        {
            string returnString = "";
            foreach (var node in nodes)
            {
                if (returnString != "") returnString += ", ";
                returnString += node.ID.ToString();
            }
            return returnString;
        }
        /// <summary>
        /// Parses a string of valuepairs
        /// </summary>
        /// <param name="valuePairs"></param>
        /// <returns>A collection of Node or NULL if bad input data</returns>
        public static List<Node> ParseValuePairs(string valuePairs)
        {
            var nodes = new List<Node>();

            // Lets get rid of accidental spaces
            valuePairs = valuePairs.Trim();
            while (valuePairs.Contains("  "))
            {
                valuePairs.Replace("  ", " "); // Replace two spaces with one space until no double spaces left
            }

            if (valuePairs == "") return nodes; // Check the empty string use case

            // Extract the valuePairs into the array allThePairs
            var allThePairs = valuePairs.Split(',');
            if (allThePairs.Count() > MAX_ALLOWED_EDGES)
            {
                return null; // Return null if too many pairs
            }
            foreach (var pair in allThePairs)
            {
                // Separate the values for each valuepair
                var splitPairs = pair.Trim().Split(' ');

                // Do some sanity checking before creating
                // and adding a Node object to the nodes collection

                if (splitPairs.Count() == 2 || splitPairs.Count() == 3)  // Only 2 or 3 is a valid "pair"
                                                                         // if (splitPairs.Count() == 2)  // Replace the line above with this line to kill the support for weighted graphs. Dijkstra will be rotating in his grave though
                { // Only 2 or 3 is a valid "pair"

                    // Now we can access splitPairs[0] and splitPairs[1]
                    // without being scared of out of range runtime errors...

                    // Now, make sure we have valid values in the pair
                    int node1, node2;
                    int pathWeight = 1; // Default pathWeight = 1

                    if (int.TryParse(splitPairs[0], out node1) && int.TryParse(splitPairs[1], out node2))
                    {
                        // If we are here, both value1 and value2 are good integers
                        // that we can validate further

                        // Lets se if we got a valid pathWeight value also
                        if (splitPairs.Count() == 3)
                            if (!int.TryParse(splitPairs[2], out pathWeight)) pathWeight = 1; // Make sure we always have a valid pathweight value

                        if (node1 <= 512 && node2 <= 512) // Max 512 nodes!
                        {
                            CreateOrUpdateNode(nodes, node1, node2, pathWeight);
                            CreateOrUpdateNode(nodes, node2, node1, pathWeight);
                        } // End the if about max 512 nodes
                    } // End the if about tryparsing the value pair
                } // End the if about the pair being 2 after split
            } // End the foreach of var pair in allThePairs
            return nodes;
        }

        private static void CreateOrUpdateNode(List<Node> nodes, int nodeID, int neighbourID, int neighbourWeight = 1)
        {
            Node node;

            // Create new node if not exists
            if (nodes.Where(n => n.ID == nodeID).Count() == 0)
            {
                node = new Node(nodeID, neighbourID, neighbourWeight);
                node.ID = nodeID;
                nodes.Add(node);
            }
            else
            {
                // add neighbour to existing node
                node = nodes.Where(n => n.ID == nodeID).Single();
                var neighbour = new Neighbour();
                neighbour.ID = neighbourID;
                neighbour.Weight = neighbourWeight;
                node.Neighbours.Add(neighbour);
            }
        }
    }
}



