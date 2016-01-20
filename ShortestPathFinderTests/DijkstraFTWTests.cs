using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace NodeTransportationLimited.Graphs.Tests
{
    /// <summary>
    /// Test class for GetShortestPathBetweenNodes
    /// </summary>
    [TestClass()]
    public class DijkstraFTWTests
    {
        private Random random = new Random();

        /// <summary>
        /// Test cases for GetShortestPathBetweenNodes
        /// </summary>
        [TestMethod()]
        public void GetShortestPathBetweenNodesTest()
        {
            var algorithm = new DijkstraFTW();

            var nodes = InputHelper.ParseValuePairs("0 1, 1 2, 2 3, 3 4");
            var start = 0;
            var end = 4;
            var shortestPathNodes = algorithm.GetShortestPathBetweenNodes(nodes, start, end);
            var nodesAsString = InputHelper.StringifyNodes(shortestPathNodes);
            Assert.IsTrue(nodesAsString == "0, 1, 2, 3, 4", "Test # 1 failed");

            nodes = InputHelper.ParseValuePairs("0 3, 0 5, 0 1, 3 4, 1 5, 5 4, 5 2, 4 7, 2 6, 6 6, 6 7, 8 9, 9 10, 10 8");
            start = 0;
            end = 4;
            shortestPathNodes = algorithm.GetShortestPathBetweenNodes(nodes, start, end);
            nodesAsString = InputHelper.StringifyNodes(shortestPathNodes);
            Assert.IsTrue(nodesAsString == "0, 3, 4", "Test # 2 failed");

            nodes = InputHelper.ParseValuePairs("0 3, 0 5, 0 1, 3 4, 1 5, 5 4, 5 2, 4 7, 2 6, 6 6, 6 7, 8 9, 9 10, 10 8");
            start = 6;
            end = 6;
            shortestPathNodes = algorithm.GetShortestPathBetweenNodes(nodes, start, end);
            nodesAsString = InputHelper.StringifyNodes(shortestPathNodes);
            Assert.IsTrue(nodesAsString == "6", "Test # 3 failed");

            nodes = InputHelper.ParseValuePairs("0 3, 0 5, 0 1, 3 4, 1 5, 5 4, 5 2, 4 7, 2 6, 6 6, 6 7, 8 9, 9 10, 10 8");
            start = 10;
            end = 3;
            shortestPathNodes = algorithm.GetShortestPathBetweenNodes(nodes, start, end);
            nodesAsString = InputHelper.StringifyNodes(shortestPathNodes);
            Assert.IsTrue(nodesAsString == "", "Test # 4 failed");

            // Test with weighted nodes
            nodes = InputHelper.ParseValuePairs("0 1, 1 2, 2 3, 3 4, 4 5, 5 6, 6 7, 1 10, 10 7 10");
            start = 1;
            end = 7;
            shortestPathNodes = algorithm.GetShortestPathBetweenNodes(nodes, start, end);
            nodesAsString = InputHelper.StringifyNodes(shortestPathNodes);
            Assert.IsTrue(nodesAsString == "1, 2, 3, 4, 5, 6, 7", "Test # 5 failed");

            // Test with weighted nodes other way around
            nodes = InputHelper.ParseValuePairs("0 1, 1 2, 2 3, 3 4, 4 5, 5 6, 6 7, 1 10, 10 7 10");
            start = 7;
            end = 1;
            shortestPathNodes = algorithm.GetShortestPathBetweenNodes(nodes, start, end);
            nodesAsString = InputHelper.StringifyNodes(shortestPathNodes);
            Assert.IsTrue(nodesAsString == "7, 6, 5, 4, 3, 2, 1", "Test # 6 failed");
        }
        /// <summary>
        /// Test cases for GetShortestPathBetweenNodes
        /// This time the order of nodes is randomized before
        /// we send it to the algorithm
        /// </summary>
        [TestMethod()]
        public void RandomizedGetShortestPathBetweenNodesTest()
        {
            var algorithm = new DijkstraFTW();
            var start = 1;
            var end = 13;

            var nodes = InputHelper.ParseValuePairs("1 2, 2 3, 3 4, 4 5, 5 12, 1 6, 6 8, 8 9, 9 11, 11 13, 12 13, 1 10, 10 10, 10 7, 7 12, 14 15, 15 16, 16 14, 20 19, 10 3, 4 7, 6 4, 7 5");

            for (int i = 0; i < 20; i++)
            {
                MakeNodeOrderRandom(nodes);
                var shortestPathNodes = algorithm.GetShortestPathBetweenNodes(nodes, start, end);
                var nodesAsString = InputHelper.StringifyNodes(shortestPathNodes);
                Assert.IsTrue(nodesAsString == "1, 10, 7, 12, 13", "Test # 1 failed");
             }
        }

        private void MakeNodeOrderRandom(List<Node> nodes)
        {
            int n = nodes.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                Node node = nodes[k];
                nodes[k] = nodes[n];
                nodes[n] = node;
            }
        }
    }
}