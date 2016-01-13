using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NodeTransportationLimited.Graphs;


namespace TempConsoleAppForTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            var nodes = InputHelper.parseValuePairs("0 1, 1 2, 2 3, 3 4");

            Console.WriteLine($"Nodes.count = {nodes.Count()}" );





            Console.WriteLine("Press a key to continue");
            Console.ReadKey();

        }
    }
}
