// VARNING: NI FÅR INTE GÖRA NÅGRA ÄNDRINGAR TILL DENNA FIL.

// OM NI GÖR ÄNDRINGAR TILL DENNA FIL SÅ BLIR NI OMGÅENDE UNDERKÄNDA
// I KURSENS PROJEKT.

using NodeTransportationLimited.Testing;
using System;

namespace NodeTransportationLimited.Graphs.ShortestPathFinder.Testing
{

/// <summary>
/// Denna klass används för testning av Shortest Path Finder-programmet.<br/><br/>
/// 
/// <b>VARNING: Inga ändringar får göras till denna
/// klass av Lernia Consulting AB.</b>
/// </summary>
	public static class TestUtilities
	{

/// <summary>
/// De tre strängparametrarna som metoden får är de tre strängar som
/// Shortest Path Finder-programmet ska få via <i>standard input</i>. Metoden
/// kopplar sedan om <i>standard input</i> till en sträng som bildats med hjälp
/// av de tre strängparametrarna. Därefter startas programmet som alltså får
/// de tre parametrarna via <i>standard input</i>.<br/><br/>
/// 
/// Läs specifikationen för att se hur de tre strängarna ska vara skrivna och
/// hur de ges till programmet via <i>standard input</i>)<br/><br/>
/// 
/// Efter att programmet har avslutats så återställer denna metod <i>standard
/// input</i> och <i>output</i> till sina ursprungslägen.<br/><br/>
/// 
/// <i>standard input</i> och <i>output</i> får <b>inte</b> ha kopplats om med
/// metoden StandardIORedirecter.redirect() utan att ha återställts innan
/// metoden RunApp() (d.v.s. denna metod) anropas. I sådant fall kommer ett fel
/// att kastas.<br/><br/>
/// 
/// <b>VARNING: Inga ändringar får göras till denna metod av
/// Lernia Consulting AB.</b>
/// </summary>
/// <param name="nrNodesStr">Ett heltal i form av en sträng som är antalet noder
/// i grafen.</param>
/// <param name="edgesStr">Kanterna i grafen.</param>
/// <param name="startEndStr">Det nodpar som den kortaste stigen ska gå mellan.</param>
/// <returns>En sträng innehållande det som Shortest Path Finder-programmet
/// skrev till <i>standard output</i> under hela sin körning.</returns>
		public static string RunApp(
			string nrNodesStr,
			string edgesStr,
			string startEndStr
		)
		{
			string input =
				nrNodesStr + Environment.NewLine +
				edgesStr + Environment.NewLine +
				startEndStr + Environment.NewLine
			;

			StandardIORedirecter.Redirect( input );

			Application.Run();

			string output = StandardIORedirecter.getOutput();

			StandardIORedirecter.Reset();

			return output;
		}
	}
}
