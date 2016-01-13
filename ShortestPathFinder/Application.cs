// VARNING: NI FÅR INTE GÖRA NÅGRA ÄNDRINGAR TILL DENNA FIL FÖRRUTOM DE DELAR
// DÄR DET EXPLICIT STÅR ATT NI FÅR MODIFIERA.

// SPECIELLT FÅR NI *INTE* ÄNDRA NAMNRYMDEN (eng. namespace) ELLER KLASSENS
// HUVUDDEFINITION. 

// OM NI GÖR OTILLÅTNA ÄNDRINGAR TILL DENNA FIL SÅ BLIR NI OMGÅENDE UNDERKÄNDA
// I KURSENS PROJEKT.

// Skapa nya klasser i denna Visual Studio-projekt som heter ShortestPathFinder
// och anropa sedan de klassernas metoder från metoden Application.Run() som
// finns i denna fil.

namespace NodeTransportationLimited.Graphs.ShortestPathFinder
{
/// <summary>
/// Denna klass startar Shortest Path Finder-programmet. <b>VARNING: Inga
/// ändringar får göras till denna klass förrutom där det anges att det är
/// tillåtet i dokumentationen.</b>
/// </summary>
	public static class Application
	{
/// <summary>
/// Startar exekveringen av Shortest Path Finder-programmet. Metoden anropas
/// från Application.Main() för att starta programmet, men den anropas även
/// vid testning. Då projektet överlämnas till Lernia Consulting AB så ger
/// metoden korrekt utdata för endast två testfall. Detta är enbart för
/// ett demonstrationssyfte och ska tas bort.<br/><br/>
/// 
/// <b>VARNING: Ändringar får göras i metodens <i>kropp</i>
/// (eng. <i>body</i>) men i övrigt får metoden inte ändras.</b>
/// </summary>
		public static void Run()
		{
// Ni får göra ändringar här inuti denna metods kropp (eng. body).
			
			System.Console.WriteLine( "Provide graph data now." );

			string nrNodesStr = System.Console.ReadLine();
			string edgesStr = System.Console.ReadLine();
			string startEndStr = System.Console.ReadLine();
			string output = null;

			if(
				nrNodesStr == "8" &&
				edgesStr == "0 1, 1 2, 2 3, 3 4, 4 5, 6 7" &&
				startEndStr == "0 7"
			)
			{
				output = "0, 1, 2, 3, 4, 5, 6, 7";
			}
			else if(
				nrNodesStr == "6" &&
				edgesStr == "0 1, 0 2, 1 2, 2 3, 2 4, 3 5" &&
				startEndStr == "0 4"
			)
			{
				output = "0, 2, 4";
			}

			System.Console.WriteLine( output );

// Ni får *inte* göra några fler ändringar efter denna linje utanför denna
// metods kropp.
		}

/// <summary>
/// Anropas när programmet startas.<br/><br/>
/// 
/// <b>VARNING: Denna metod får inte ändrans på något sätt.</b>
/// </summary>
/// <exclude/>
		public static void Main()
		{
			Run();
		}
	}
}
