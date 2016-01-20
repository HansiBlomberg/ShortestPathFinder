using Microsoft.VisualStudio.TestTools.UnitTesting;
using NodeTransportationLimited.Testing;

namespace NodeTransportationLimited.Graphs.ShortestPathFinder.Testing
{
/// <summary>
/// Denna klass är till för att visa hur enhetstester kan skrivas för att testa
/// Shortest Path Finder-programmet. Klassen innehåller två enhetstester som
/// lyckas om testerna körs när projektet överlämnas till
/// <i>Lernia Consulting AB</i>. Detta beror på att programmet ger i nuläget
/// korrekt utdata för just de två enhetstesterna.<br/><br/>
/// 
/// Klassen får utökas med fler enhetstester, och andra klasser innehållande 
/// tester får också skapas.<br/><br/>
/// 
/// Observera att de två enhetstesterna använder sig av en metod för att köra
/// programmet för de parametrar som önskas, och denna metod kan också användas
/// fortsättningsvis.
/// </summary>
	[TestClass]
	public class ApplicationTests
	{
		private static string newLine = System.Environment.NewLine;
		private static string readyStr = "Provide graph data now.";

        /// Konstruktorn har lagts till bara för att kunna exkludera den från
        /// projektets dokumentation. 
        /// <summary>
        /// 
        /// </summary>
        /// <exclude/>
        public ApplicationTests() { }

		/// <summary>
		/// Om en enhetstest använder StandardIORedirecter för att koppla om <i>standard
		/// input</i> och <i>output</i> så måste de återställas efteråt. Därför
		/// återställs dem av denna metod om så inte redan har skett.
		/// </summary>
		[TestCleanup]
		public void CleanUp()
		{
			if( StandardIORedirecter.IsReset() == false )
			{
				StandardIORedirecter.Reset();
			}
		}

        /// <summary>
        /// 
        /// </summary>
        /// <exclude/>
		[TestMethod]
        public void Run_EightNodesOnALine_From0To7()
        {
            string output =
            TestUtilities.RunApp(
            "8",
            "0 1, 1 2, 2 3, 3 4, 4 5, 5 6, 6 7",
            "0 7"
            );

            Assert.AreEqual(
            output,
            readyStr +
            newLine +
            "0, 1, 2, 3, 4, 5, 6, 7" +
            newLine
            );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <exclude/>
        [TestMethod]
		public void Run_OrdinaryGraphWithSixNodes_From0To4()
		{
			string output =
			TestUtilities.RunApp(
				"6",
				"0 1, 0 2, 1 2, 2 3, 2 4, 3 5",
				"0 4"
			);

			Assert.AreEqual(
				output,
				readyStr +
				newLine +
				"0, 2, 4" +
				newLine
			);
		}

        /// <summary>
        /// 
        /// </summary>
        /// <exclude/>
        [TestMethod]
        public void Run_EightNodesOnALine_From0To7OtherWayAround()
        {
            string output =
            TestUtilities.RunApp(
            "8",
            "0 1, 1 2, 2 3, 3 4, 4 5, 5 6, 6 7",
            "7 0"
            );

            Assert.AreEqual(
            output,
            readyStr +
            newLine +
            "7, 6, 5, 4, 3, 2, 1, 0" +
            newLine
            );
        }
        /// <summary>
        /// 
        /// </summary>
        /// <exclude/>
        [TestMethod]
        public void Run_TwentyNodesWithSeveralPossiblePathsWithDifferentLength()
        {
            string output =
            TestUtilities.RunApp(
            "21",
            "1 2, 2 3, 3 4, 4 5, 5 12, 1 6, 6 8, 8 9, 9 11, 11 13, 12 13, 1 10, 10 10, 10 7, 7 12, 14 15, 15 16, 16 14, 20 19, 10 3, 4 7, 6 4, 7 5",
            "1 13"
            );
            Assert.AreEqual(
            output,
            readyStr +
            newLine +
            "1, 10, 7, 12, 13" +
            newLine
            );
        }
        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void UnconnectedGraph_OnlyOneNode()
        {
            string output = TestUtilities.RunApp("1", "0", "0 0");
            Assert.AreEqual(output, readyStr + newLine + "0" + newLine);
        }
        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void ConnectedGraph_OnlyOneNode()
        {
            string output = TestUtilities.RunApp("1", "0 0", "0 0");
            Assert.AreEqual(output, readyStr + newLine + "0" + newLine);
        }
        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void ConnectedGraph_OnlyTwoNodes()
        {
            string output = TestUtilities.RunApp("2", "0 1", "0 1");
            Assert.AreEqual(output, readyStr + newLine + "0, 1"+newLine);
        }
        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void UnconnectedGraph_OnlyTwoNodes()
        {
            string output = TestUtilities.RunApp("2", "0, 1", "0 1");
            Assert.AreEqual(output, readyStr + newLine + "" + newLine);
        }
        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void ConnectedGraph_JustSomeNodes()
        {
            string output = TestUtilities.RunApp("5", "2 4, 1 3, 2 2,4 3","2 1");
            Assert.AreEqual(output, readyStr + newLine + "2, 4, 3, 1" + newLine);
        }
        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void ConnectedGraph_CurrentNodeIsConnectedWithTheNextNode()
        {
            string output = TestUtilities.RunApp("10", "0 1, 1 2, 2 3, 3 4, 4 5, 5 6, 6 7,7 8, 8 9", "0 9");
            Assert.AreEqual(output, readyStr + newLine + "0, 1, 2, 3, 4, 5, 6, 7, 8, 9" + newLine);
        }
        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void UnconnectedGraph_NodesAreNotConnected()
        {
            string output = TestUtilities.RunApp("2", "0, 1", "0 1");
            Assert.AreEqual(output, readyStr + newLine + "" + newLine);
        }
        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void ConnectedGraph_StartNodeHaveAConnectionToItselfAndOthers()
        {
            string output = TestUtilities.RunApp("2", "0 0,0 1", "0 1");
            Assert.AreEqual(output, readyStr + newLine + "0, 1" + newLine);
        }
        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void UnconnectedGraph_StartNodeHaveOnlyAConnectionToItself()
        {
            string output = TestUtilities.RunApp("1", "0 0", "0 0");
            Assert.AreEqual(output, readyStr + newLine + "0" + newLine);
        }
        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void ConnectedGraph_StartNodeHaveNoConnection()
        {
            string output = TestUtilities.RunApp("3", "0, 1 2", "0 2");
            Assert.AreEqual(output, readyStr + newLine + "" + newLine);
        }
        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void ConnectedGraph_EndNodeHaveNoConnection()
        {
            string output = TestUtilities.RunApp("3", "0 1,2", "0 2");
            Assert.AreEqual(output, readyStr + newLine + "" + newLine);
        }
        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void ConnectedGraph_StartAndEndNodesHaveConnectionsButNoShortestPath()
        {
            string output = TestUtilities.RunApp("4", "0 1,2 3", "0 3");
            Assert.AreEqual(output, readyStr + newLine + "" + newLine);
        }
        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void ConnectedGraph_ManyNodesOnAShortestPathGotConnectionsToItself()
        {
            string output = TestUtilities.RunApp("10", "0 0,0 1,1 2,2 2,2 3,3 4,4 5,5 5,5 6,6 7,7 7, 7 8,8 8,8 9,9 9", "0 9");
            Assert.AreEqual(output, readyStr + newLine + "0, 1, 2, 3, 4, 5, 6, 7, 8, 9"+newLine);
        }
        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void ConnectedGraph_StartAndEndNodesAreDirectlyConnected()
        {
            string output = TestUtilities.RunApp("2", "0 1", "0 1");
            Assert.AreEqual(output, readyStr + newLine + "0, 1" + newLine);
        }
        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void ConnectedGraph_NothingSpecialAboutThisGraphOne()
        {
            string output = TestUtilities.RunApp("10", "3 5,8 7,5 8", "3 8");
            Assert.AreEqual(output, readyStr + newLine + "3, 5, 8" + newLine);
        }
        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void ConnectedGraph_NothingSpecialAboutThisGraphTwo()
        {
            string output = TestUtilities.RunApp("10", "1 9, 4 5, 1 4", "9 5");
            Assert.AreEqual(output, readyStr + newLine + "9, 1, 4, 5" + newLine);
        }
    }
}
