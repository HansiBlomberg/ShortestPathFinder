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

// Konstruktorn har lagts till bara för att kunna exkludera den från
// projektets dokumentation. 
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
				"0 1, 1 2, 2 3, 3 4, 4 5, 6 7",
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
	}
}
