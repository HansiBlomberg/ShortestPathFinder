using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NodeTransportationLimited.Graphs
{
    /// <summary>
    /// This class holds a node object
    /// 
    /// Properties:
    /// ID = The ID of the node object
    /// firstNeighborID = The ID of the first neighbor node
    /// secondNeighborID = The ID of the second neighbor node
    /// </summary>
    public class Node
    {
        /// <summary>
        /// ID of this Node
        /// </summary>
        public int ID { get; set; }


        /// <summary>
        /// ID of previous node on optimal path from source
        /// </summary>
        public int? PreviousID { get; set; }


        /// <summary>
        /// List of ID:s of neighbouring nodes
        /// </summary>
        public List<int> NeighborIDs { get; set; }
       
        /// <summary>
        /// Visited flag to be used by get shortest path algorithm
        /// </summary>
        public bool IsVisited;

        /// <summary>
        /// Distance property, shortest found distance to start node
        /// </summary>
        public int? Distance { get; set; }


        /// <summary>
        /// Constructor - will create a new Node with one neighbour Node ID
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="neighbourID"></param>
        public Node(int id, int neighbourID)
        {
            this.ID = id;
            this.NeighborIDs = new List<int>();
            NeighborIDs.Add(neighbourID);
            this.IsVisited = false;
            this.Distance = null; // null is for infinity
            this.PreviousID = null; // null until found
        }

    }




}
