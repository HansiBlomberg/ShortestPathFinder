using Microsoft.VisualStudio.TestTools.UnitTesting;
using NodeTransportationLimited.Graphs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NodeTransportationLimited.Graphs.Tests
{
    /// <summary>
    /// Test class for GetShortestPathBetweenNodes
    /// </summary>
    [TestClass()]
    public class DijkstraFTWTests
    {
        /// <summary>
        /// Test cases for GetShortestPathBetweenNodes
        /// </summary>
        [TestMethod()]
        public void GetShortestPathBetweenNodesTest()
        {

            var algorithm = new DijkstraFTW();


            var nodes = InputHelper.parseValuePairs("0 1, 1 2, 2 3, 3 4");
            var start = 0;
            var end = 4;
            var shortestPathNodes = algorithm.GetShortestPathBetweenNodes(nodes, start, end);
            var nodesAsString = InputHelper.StringifyNodes(shortestPathNodes);
            Assert.IsTrue(nodesAsString == "0, 1, 2, 3, 4", "Test # 1 failed");



            nodes = InputHelper.parseValuePairs("0 3, 0 5, 0 1, 3 4, 1 5, 5 4, 5 2, 4 7, 2 6, 6 6, 6 7, 8 9, 9 10, 10 8");
            start = 0;
            end = 4;
            shortestPathNodes = algorithm.GetShortestPathBetweenNodes(nodes, start, end);
            nodesAsString = InputHelper.StringifyNodes(shortestPathNodes);
            Assert.IsTrue(nodesAsString == "0, 3, 4", "Test # 2 failed");




            nodes = InputHelper.parseValuePairs("0 3, 0 5, 0 1, 3 4, 1 5, 5 4, 5 2, 4 7, 2 6, 6 6, 6 7, 8 9, 9 10, 10 8");
            start = 6;
            end = 6;
            shortestPathNodes = algorithm.GetShortestPathBetweenNodes(nodes, start, end);
            nodesAsString = InputHelper.StringifyNodes(shortestPathNodes);
            Assert.IsTrue(nodesAsString == "6", "Test # 3 failed");




            nodes = InputHelper.parseValuePairs("0 3, 0 5, 0 1, 3 4, 1 5, 5 4, 5 2, 4 7, 2 6, 6 6, 6 7, 8 9, 9 10, 10 8");
            start = 10;
            end = 3;
            shortestPathNodes = algorithm.GetShortestPathBetweenNodes(nodes, start, end);
            nodesAsString = InputHelper.StringifyNodes(shortestPathNodes);
            Assert.IsTrue(nodesAsString == "", "Test # 4 failed");








        }
    }
}