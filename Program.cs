using System;
namespace NEAProject
{
    class ShortestPathAnalysis
    {
        int MinimumDistance(int CurrentGraphVertices, int[] Distance, bool[] VerticesSet)
        {
            var Minimum = int.MaxValue;
            var Minimum_index = -1;
            for (int v = 0; v < CurrentGraphVertices; v++)
            {
                if ((VerticesSet[v] == false) && (Distance[v] <= Minimum))
                {
                    Minimum = Distance[v];
                    Minimum_index = v;
                }
            }
            return Minimum_index;
        }
        void PrintSolution(List<RouteNode> route)
        {
            Console.Write("Vertex    Distance " + "from Source\n");
            foreach (var routeNode in route)
            {
                Console.WriteLine(routeNode.NodeIndex + "\t\t" + routeNode.Distance + "\n");
            }
        }
        List<RouteNode> DijkstraAlgorithm(int CurrentGraphVertices, int[,] CurrentGraph, int SourceNode, int DestinationNode)
        {
            int[] Distance = new int[CurrentGraphVertices];
            bool[] VerticesSet = new bool[CurrentGraphVertices];
            for (int i = 0; i < CurrentGraphVertices; i++)
            {
                Distance[i] = int.MaxValue;
                VerticesSet[i] = false;
            }
            Distance[SourceNode] = 0;
            for (int Count = 0; Count < (CurrentGraphVertices - 1); Count++)
            {
                int u = MinimumDistance(CurrentGraphVertices, Distance, VerticesSet);

                for (int v = 0; v < CurrentGraphVertices; v++)
                {
                    if (!VerticesSet[v] && CurrentGraph[u, v] != 0 && Distance[u] != int.MaxValue && Distance[u] + CurrentGraph[u, v] < Distance[v])
                    {
                        Distance[v] = Distance[u] + CurrentGraph[u, v];
                    }
                }
                VerticesSet[u] = true;
            }
            var route = Distance.Select((x, i) => new RouteNode { Distance = x, NodeIndex = i + 1 }).OrderBy(x => x.Distance).Where(x => x.NodeIndex <= DestinationNode).Reverse().ToList();
            var currentNode = route[0];
            var actualRoute = new List<RouteNode> { currentNode };
            for (int i = 0; i < route.Count; i++)
            {
                if (i < route.Count - 1)
                {
                    var nextNode = route[i + 1];
                    var routeDist = CurrentGraph[currentNode.NodeIndex - 1, nextNode.NodeIndex - 1];
                    if (routeDist > 0)
                    {
                        if (currentNode.Distance - routeDist == nextNode.Distance)
                        {
                            currentNode = nextNode;
                            actualRoute.Add(currentNode);
                        }
                    }
                }
            }
            actualRoute.Reverse();
            return actualRoute;
        }
        public static void Main()
        {
            //The amount of vertices of graph 1
            int Graph1Vertices = 5;
            //Creating the first graph          
            int[,] Graph1 = new int[5, 5]
                {
                {0,2,4,0,0 },
                {2,0,1,5,0 },
                {4,1,0,3,1 },
                {0,5,3,0,0 },
                {0,0,1,0,0 } };
            //The amount of vertices of graph 2
            int Graph2Vertices = 8;
            //Creating the second graph
            int[,] Graph2 = new int[8, 8]
                {
                {0,2,0,2,0,0,8,0 },
                {2,0,1,0,0,3,0,5 },
                {0,1,0,1,0,0,0,0 },
                {2,0,1,0,2,0,0,0 },
                {0,0,0,2,0,1,0,0 },
                {0,3,0,0,1,0,3,0 },
                {8,0,0,0,0,3,0,1 },
                {0,5,0,0,0,0,1,0 } };
            //The amount of vertices of graph 3
            int Graph3Vertices = 10;
            //Creating the third graph
            int[,] Graph3 = new int[10, 10]
            {
                {0,0,1,4,5,0,0,0,0,15 },
                {0,0,0,0,0,3,0,0,5,0 },
                {1,0,0,2,0,0,0,0,0,0 },
                {4,0,2,0,1,0,1,0,0,0 },
                {5,0,0,1,0,0,0,0,0,0 },
                {0,3,0,0,0,0,3,2,4,0 },
                {0,0,0,1,0,3,0,6,0,0 },
                {0,0,0,0,0,2,6,0,5,0 },
                {0,5,0,0,0,4,0,5,0,3 },
                {15,0,0,0,0,0,0,0,3,0 } };
            //Set a value for the amount of vertices that the program will use
            //Get the user to select a valid graph
            Console.WriteLine("Please select a graph");
            int SelectCurrentGraph = Convert.ToInt32(Console.ReadLine());
            while ((SelectCurrentGraph > 3) || (SelectCurrentGraph < 1))
            {
                Console.WriteLine("Invalid Graph, please select another one");
                SelectCurrentGraph = Convert.ToInt32(Console.ReadLine());
            }
            //Adjust the value of the amount of vertices based on what graph is selected
            //Set current graph to the graph selected
            int CurrentGraphVertices = 0;
            int[,] CurrentGraph = new int[,] { };
            if (SelectCurrentGraph == 1)
            {
                CurrentGraphVertices = Graph1Vertices;
                CurrentGraph = Graph1;
            }
            else if (SelectCurrentGraph == 2)
            {
                CurrentGraphVertices = Graph2Vertices;
                CurrentGraph = Graph2;
            }
            else
            {
                CurrentGraphVertices = Graph3Vertices;
                CurrentGraph = Graph3;
            }
            Console.WriteLine("Please select a source/starting node");
            int SelectSourceNode = Convert.ToInt32(Console.ReadLine());
            while ((SelectSourceNode < 0) && (SelectSourceNode >= CurrentGraphVertices))
            {
                Console.WriteLine("Invalid source node, please select another");
                SelectSourceNode = Convert.ToInt32(Console.ReadLine());
            }
            int SourceNode = SelectSourceNode - 1;
            ShortestPathAnalysis t = new ShortestPathAnalysis();
            t.PrintSolution(t.DijkstraAlgorithm(CurrentGraphVertices, CurrentGraph, SourceNode, 10));
        }
    }
    public class RouteNode
    {
        public int Distance { get; set; }

        public int NodeIndex { get; set; }
    }
}


