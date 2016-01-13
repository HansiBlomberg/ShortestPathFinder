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
    class Node
    {
        public int ID { get; set; }
        public List<int> NeighborIDs { get; set; }
       
    }


}
