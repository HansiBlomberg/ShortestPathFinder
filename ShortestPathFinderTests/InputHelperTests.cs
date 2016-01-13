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
    /// 
    /// </summary>
    [TestClass()]
    public class InputHelperTests
    {
        /// <summary>
        /// Tests the isNumberOfNodesValid method
        /// </summary>
        [TestMethod()]
        public void isNumberOfNodesValidTest()
        {

            Assert.IsTrue(InputHelper.isNumberOfNodesValid(10));
            Assert.IsFalse(InputHelper.isNumberOfNodesValid(0));
            Assert.IsFalse(InputHelper.isNumberOfNodesValid(-1));
            Assert.IsFalse(InputHelper.isNumberOfNodesValid(513));
        }

        /// <summary>
        /// Tests the parseValuePairs method
        /// </summary>
        [TestMethod()]
        public void parseValuePairsTest()
        {

            Assert.IsTrue(InputHelper.parseValuePairs("").Count() == 0, "Empty string test failed!");
            Assert.IsTrue(InputHelper.parseValuePairs("0 1, 1 2, 2 3, 3 4").Count() == 5, "Count nodes = 5 failed!");
            Assert.IsTrue(InputHelper.parseValuePairs("0 1, 1 2, 2 3, 3 4").Where(vp => vp.NeighborIDs.Contains(1)).Count() == 2, "Find 2 occurences of 1 as neighbour failedS!");




        }
        /// <summary>
        /// Tests the parseBeginAndEndNodesTest
        /// </summary>
        [TestMethod()]
        public void parseBeginAndEndNodesTest()
        {
            int start, end;
            Assert.IsFalse(InputHelper.parseBeginAndEndNodes("x y", out start, out end), "x y not numbers test failed");
            Assert.IsTrue(InputHelper.parseBeginAndEndNodes("10 20", out start, out end), "start 10 end 20 test failed at step 1");

            Assert.IsTrue(start == 10, "start 10 end 20 test failed at step 2");
            Assert.IsTrue(end == 20, "start 10 end 20 test failed at step 3");



        }

        [TestMethod()]
        public void isStartAndEndNodesValidTest()
        {
            var nodes = InputHelper.parseValuePairs("0 1, 1 2, 2 3, 3 4");

            Assert.IsTrue(InputHelper.isStartAndEndNodesValid(nodes, 1, 3));
            Assert.IsFalse(InputHelper.isStartAndEndNodesValid(nodes, 1, 5));
        }
    }
}