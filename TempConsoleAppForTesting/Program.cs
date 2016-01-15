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
            // Fixa en inputHelper som returnerar start och end på önskad path?

            if (InputHelper.isStartAndEndNodesValid(nodes, 0, 4))
                Console.WriteLine("Kör på!");
            else
                Console.WriteLine("Scheisse NEIN!!!!!");

            Console.WriteLine($"Nodes.count = {nodes.Count()}");

            foreach (var node in nodes)
            {
                if (node.ID == 0)
                    node.Start = true;

                if (node.ID == 4)
                    node.Destination = true;
            }

            var steps = 0;
            var q = new Queue<Node>();
            foreach (var node in nodes)
            {
                if (node.Start)
                    Console.WriteLine();
                else if (node.Destination)
                    Console.WriteLine();
                else
                    node.isVisited = true;

                q.Enqueue(node);
                
                foreach (var nodeNeighbour in node.NeighborIDs)
                {
                    if (node.isVisited)
                        Console.WriteLine();
                    else if (node.Destination)
                        Console.WriteLine();
                }
            }

            Console.WriteLine("Press a key to continue");
            Console.ReadKey();


        }
    }
}
