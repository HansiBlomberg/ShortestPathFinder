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

            int numberOfNodes = 0;
			string nrNodesStr = System.Console.ReadLine();
            if(!int.TryParse(nrNodesStr, out numberOfNodes))
            {
                System.Console.WriteLine("Not a valid number, exiting...");
                return;
            }

            if (!InputHelper.IsNumberOfNodesValid(numberOfNodes))
            {
                System.Console.WriteLine("Not a valid number, exiting...");
                return;
            }
            string edgesStr = System.Console.ReadLine();
            var nodes = InputHelper.ParseValuePairs(edgesStr);

            if (nodes == null )
            {
                System.Console.WriteLine("Not a valid list of nodes, exiting...");
                return;

            }

      
            int startNode, endNode;
            string startEndStr = System.Console.ReadLine();
            if(!InputHelper.ParseBeginAndEndNodes(startEndStr, out startNode, out endNode))
            {
                System.Console.WriteLine("Not a valid input of start and endnode, exiting...");
                return;
            }

            if(!InputHelper.IsStartAndEndNodesValid(numberOfNodes,startNode, endNode))
            {
                System.Console.WriteLine("Invalid start or endnode, exiting...");
                return;
            }


            // If we got HERE, we have:
            // a valid number of nodes in numberOfNodes
            // a list of Nodes in nodes
            // The starting node in startNode
            // The end node in endNode
            // Let the fun begin!!
            var algorithm = new DijkstraFTW();
            var shortestPathNodes = algorithm.GetShortestPathBetweenNodes(nodes, startNode, endNode);
            var output = InputHelper.StringifyNodes(shortestPathNodes);

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
