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
        /// List of neighbours
        /// </summary>
        public List<Neighbour> Neighbours { get; set; }
       
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
        /// <param name="id">ID of new node</param>
        /// <param name="neighbourID">ID of neighbour node</param>
        /// <param name="neighbourWeight">Optional Weight of neighbour path</param>
        public Node(int id, int neighbourID, int neighbourWeight = 1)
        {

            this.ID = id;
            this.Neighbours = new List<Neighbour>();
            var neighbour = new Neighbour();
            neighbour.ID = neighbourID;
            neighbour.Weight = neighbourWeight;
            Neighbours.Add(neighbour);
            this.IsVisited = false;
            this.Distance = null; // null is for infinity
            this.PreviousID = null; // null until found
        }


        /// <summary>
        /// Constructor - will create a new Node without neighbours
        /// 
        /// </summary>
        /// <param name="id">ID of new node</param>
       
        public Node(int id)
        {

            this.ID = id;
            this.Neighbours = new List<Neighbour>();
            this.IsVisited = false;
            this.Distance = null; // null is for infinity
            this.PreviousID = null; // null until found
        }

    }


    /// <summary>
    /// Struct to hold Neighbour ID and its weight
    /// </summary>
    public struct Neighbour
    {
        /// <summary>
        /// ID of neighbour Node
        /// </summary>
        public int ID { get; set; }
        
        /// <summary>
        /// Weight of connection between this node and neighbour node
        /// </summary>
        public int Weight { get; set; }

    }


}
