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



            // Test with weighted nodes
            nodes = InputHelper.parseValuePairs("0 1, 1 2, 2 3, 3 4, 4 5, 5 6, 6 7, 1 10, 10 7 10");
            start = 1;
            end = 7;
            shortestPathNodes = algorithm.GetShortestPathBetweenNodes(nodes, start, end);
            nodesAsString = InputHelper.StringifyNodes(shortestPathNodes);
            Assert.IsTrue(nodesAsString == "1, 2, 3, 4, 5, 6, 7", "Test # 5 failed");

            //// Test with weighted nodes other way around, we have a problem with this atm
            //nodes = InputHelper.parseValuePairs("0 1, 1 2, 2 3, 3 4, 4 5, 5 6, 6 7, 1 10, 10 7 10");
            //start = 7;
            //end = 1;
            //shortestPathNodes = algorithm.GetShortestPathBetweenNodes(nodes, start, end);
            //nodesAsString = InputHelper.StringifyNodes(shortestPathNodes);
            //Assert.IsTrue(nodesAsString == "7, 6, 5, 4, 3, 2, 1", "Test # 6 failed");







        }


        /// <summary>
        /// Currently failing test cases for GetShortestPathBetweenNodes
        /// </summary>
        [TestMethod()]
        public void FailingGetShortestPathBetweenNodesTest()
        {

            var algorithm = new DijkstraFTW();


            List<Node> nodes;
            int start = 0;
            int end = 4;
            List<Node> shortestPathNodes;
            string nodesAsString;
            



          

            // Test with weighted nodes other way around, we have a problem with this atm
            nodes = InputHelper.parseValuePairs("0 1, 1 2, 2 3, 3 4, 4 5, 5 6, 6 7, 1 10, 10 7 10");
            start = 7;
            end = 1;
            shortestPathNodes = algorithm.GetShortestPathBetweenNodes(nodes, start, end);
            nodesAsString = InputHelper.StringifyNodes(shortestPathNodes);
            Assert.IsTrue(nodesAsString == "7, 6, 5, 4, 3, 2, 1", "Test # 6 failed");







        }

    }
}