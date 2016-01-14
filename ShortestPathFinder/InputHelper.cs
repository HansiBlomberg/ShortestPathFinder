using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NodeTransportationLimited.Graphs
{
    /// <summary>
    /// Some helper methods for the Get Shortest Path application
    /// </summary>
    public static class InputHelper
    {

        /// <summary>
        /// Checks if the number of nodes is within the specified
        /// range.
        /// </summary>
        /// <param name="numberOfNodes"></param>
        /// <returns>True if the number of nodes is acceptable</returns>
        public static bool isNumberOfNodesValid(int numberOfNodes)
        {
            if (numberOfNodes < 1 || numberOfNodes > 512) return false;
            return true;
        }

        /// <summary>
        /// Check if the start node and end node seem valid
        /// </summary>
        /// <param name="nodes"></param>
        /// <param name="startNode"></param>
        /// <param name="endNode"></param>
        /// <returns>True if the start node and end node are valid nodes</returns>
        public static bool isStartAndEndNodesValid(List<Node> nodes, int startNode, int endNode)
        {
            if (nodes.Exists(n => n.ID == startNode) && nodes.Exists(n => n.ID == endNode)) return true;
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
        public static bool parseBeginAndEndNodes(string input, out int beginValue, out int endValue)
        {
            
            beginValue = 0;
            endValue = 0;
            // 3: En textsträng med två heltal, som är mindre än antalet noder från första strängen(eftersom första noden är 0).
            // Talen är skilda med mellanslag
            // Exempel 0 4
            var splittedInput = input.Trim().Split(' ');
            if (splittedInput.Count() != 2 ) return false;
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

            foreach(var node in nodes)
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
        public static List<Node> parseValuePairs(string valuePairs)
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
            if ( allThePairs.Count() > 262144 )
            {
                return null; // Return null if too many pairs
            }
            foreach (var pair in allThePairs)
            {
                // Separate the values for each valuepair
                var splitPairs = pair.Trim().Split(' ');

                // Do some sanity checking before creating
                // and adding a Node object to the nodes collection
                
                if(splitPairs.Count() == 2) { // Only 2 is a pair!

                    // Now we can access splitPairs[0] and splitPairs[1]
                    // without being scared of out of range runtime errors...

                    // Now, make sure we have valid values in the pair
                    int value1, value2;
                    if ( int.TryParse(splitPairs[0], out value1) && int.TryParse(splitPairs[1], out value2) )
                    {
                        // If we are here, both value1 and value2 are good integers
                        // that we can validate further
                        if(value1 <= 512 && value2 <= 512) // Max 512 nodes!
                        {

                            CreateOrUpdateNode(nodes, value1, value2);
                            CreateOrUpdateNode(nodes, value2, value1);
                            
                        } // End the if about max 512 nodes
                    } // End the if about tryparsing the value pair


                } // End the if about the pair being 2 after split

            } // End the foreach of var pair in allThePairs

            return nodes;

        }

        private static void CreateOrUpdateNode(List<Node> nodes, int nodeID, int neighbourID) {

            Node node;

            // Create new is not exists
            if (nodes.Where(n => n.ID == nodeID).Count() == 0)
            {
                node = new Node(nodeID, neighbourID);
                node.ID = nodeID;
                nodes.Add(node);
            }
            else {

                // add neighbour to existing node
                node = nodes.Where(n => n.ID == nodeID).Single();
                node.NeighborIDs.Add(neighbourID);
            }

        }



    }
}


/*

Input, börjar analysera uppgiften där.

1: En textsträng för antal noder i grafen

Noderna skall ha benämning 0, 1, 2, 3 osv sedan

2: En textsträng med serie med talpar, exempel: 0 1, 2 3, 14 15

0 1 är ett talpar
1 2 är ett talpar
2 3 är ett talpar
3 4 är ett talpar

14 15 är ett talpar
kommatecknet separerar

Max 262144st talpar = kanter. En vanlig int hanterar mycket högre värde än så, så det spelar ingen roll.

Textsträngen kan vara tom = inga kanter

3: En textsträng med två heltal, som är mindre än antalet noder från första strängen (eftersom första noden är 0).

Talen är skilda med mellanslag
Exempel 0 4

Programmet skall hitta kortaste vägen mellan i detta fall 0 och 4. Med indataexemplet ovan så blir vägen 0-1-2-3-4.

Programmet skall dock skriva ut detta som 0, 2, 3, 4




*/
