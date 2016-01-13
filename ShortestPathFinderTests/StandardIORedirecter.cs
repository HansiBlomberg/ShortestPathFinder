// VARNING: NI FÅR INTE GÖRA NÅGRA ÄNDRINGAR TILL DENNA FIL.

// OM NI GÖR ÄNDRINGAR TILL DENNA FIL SÅ BLIR NI OMGÅENDE UNDERKÄNDA
// I KURSENS PROJEKT.

using System;
using System.IO;

namespace NodeTransportationLimited.Testing
{

/// <summary>
/// Denna klass används för att koppla om standard input och output till
/// strängar. Detta görs i testningssyfte när man vill kunna kontrollera
/// vad för data ett program får via standard input och vad den skriver
/// till standard output.<br/><br/>
/// 
/// <b>VARNING: Inga ändringar får göras till denna
/// klass av Lernia Consulting AB.</b>
/// </summary>
	public static class StandardIORedirecter
	{
		private static StringReader redirectedI = null;
		private static StringWriter redirectedO = null;

/// <summary>
/// Säger om <i>standard input</i> och <i>output</i> har återställts
/// till så som den var innan de kopplades om till strängar av denna klass.
/// <br/><br/>
/// 
/// <b>VARNING: Inga ändringar får göras till denna metod.</b>
/// </summary>
/// <returns>Returnerar true om <i>standard input</i> och <i>output</i> har
/// återställts.</returns>
		public static bool IsReset()
		{
			return redirectedI == null;
		}

/// <summary>
/// Kopplar om <i>standard input</i> och <i>output</i> till strängar. När en
/// läsning görs via standard input (via Console.ReadLine() t.ex.) så läses
/// datat från strängen som <i>standard input</i> har kopplats till, medan
/// skrivningar till standard output (via Console.WriteLine()) hamnar i den
/// sträng som den har kopplats till. Det som skrivits till standard output
/// kan sedan läsas med StandardIORedirecter.getOutput().<br/><br/>
/// 
/// Det krävs att
/// <i>standard input</i> och <i>output</i> har återställts från tidigare
/// omkopplingar innan denna metod används. Annars kastas en
/// InvalidOperationException.
/// Återställning ska göras med StandardIORedirecter.reset().<br/><br/>s
/// 
/// <b>VARNING: Inga ändringar får göras till denna metod.</b>
/// </summary>
/// <param name="input"></param>
		public static void Redirect( string input )
		{
			if( IsReset() == false )
			{
				throw new System.InvalidOperationException(
					"The standard IO redirecter must be reset before being redirected again"
				);
			}

			redirectedI = new StringReader( input );
			redirectedO = new StringWriter();

			Console.SetIn( redirectedI );
			Console.SetOut( redirectedO );
		}

/// <summary>
/// Återställer <i>standard input</i> och <i>output</i> till så som de var
/// innan de omkopplades med StandardIORedirecter.redirect(). Återställning
/// får <b>inte</b> redan ha skett innan denna metod anropas. I sådant fall
/// kastas en InvalidOperationException.<br/><br/>
/// 
/// <b>VARNING: Inga ändringar får göras till denna metod.</b>
/// </summary>
		public static void Reset()
		{
			if ( IsReset() == true )
			{
				throw new System.InvalidOperationException(
					"The standard IO redirecter has already been reset"
				);
			}

			redirectedI = null;
			redirectedO = null;

			StreamReader standardI = new StreamReader( Console.OpenStandardInput() );

			StreamWriter standardO = new StreamWriter( Console.OpenStandardOutput() );
			standardO.AutoFlush = true;

			Console.SetIn( standardI );
			Console.SetOut( standardO );
		}

/// <summary>
/// Returnerar det som har skrivits till <i>standard output</i> efter omkoppling
/// med metoden StandardIORedirecter.redirect(). getOutput() får <b>inte</b>
/// anropas om <i>standard output</i> har återställts. I sådant fall
/// kastas en InvalidOperationException.<br/><br/>
/// 
/// <b>VARNING: Inga ändringar får göras till denna metod.</b>
/// </summary>
/// <returns>En sträng innehållande det som har skrivits till <i>standard output
/// </i>.</returns>
		public static string getOutput()
		{
			if ( IsReset() == true )
			{
				throw new System.InvalidOperationException(
					"Standard IO must have been redirected before retrieving output"
				);
			}

			return redirectedO.ToString();
		}
	}
}
