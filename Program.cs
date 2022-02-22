using System;

namespace NEAProject
{
    public class ShortestPathAnalysis
    {
        int MinimumDistance(int CurrentGraphVertices, int[] Distance, bool[] VerticesSet)
        {
            int Minimum = int.MaxValue, Minimum_index = -1;
            for (int v = 0; v < CurrentGraphVertices; v++)
                if ((VerticesSet[v] == false) && (Distance[v] <= Minimum))
                {
                    Minimum = Distance[v];
                    Minimum_index = v;
                }
            return Minimum_index;
        }
        void PrintSolution(int CurrentGraphVertices, int[] Distance, int n)
        {
            Console.Write("Vertex    Distance " + "from Source\n");
            for (int i = 0; i < CurrentGraphVertices; i++)
                Console.WriteLine(i + "\t\t" + Distance[i] + "\n");
        }
        void DijkstraAlgorithm(int CurrentGraphVertices,int[, ] CurrentGraph, int SourceNode)
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
                int u = MinimumDistance(CurrentGraphVertices,Distance, VerticesSet);
                for (int v = 0; v < CurrentGraphVertices; v++)
                    if (!VerticesSet[v] && CurrentGraph[u, v] != 0 && Distance[u] != int.MaxValue && Distance[u] + CurrentGraph[u, v] < Distance[v])
                        Distance[v] = Distance[u] + CurrentGraph[u, v];
            }
            PrintSolution(CurrentGraphVertices, Distance, CurrentGraphVertices);


        }
        public static void Main(string[] args)
        {
            //Creating the first graph          
            int[,] Graph1 = new int[5, 5]
                {
                {0,2,4,0,0 },
                {2,0,1,5,0 },
                {4,1,0,3,1 },
                {0,5,3,0,0 },
                {0,0,1,0,0 } };
            //The amount of vertices of graph 1
            int Graph1Vertices = 5;
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
            //The amount of vertices of graph 2
            int Graph2Vertices = 8;
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
                {0,5,0,0,0,5,0,5,0,3 },
                {15,0,0,0,0,0,0,0,3,0 } };
            //The amount of vertices of graph 3
            int Graph3Vertices = 10;
            //Set a value for the amount of vertices that the program will use
            //Get the user to select a valid graph
            Console.WriteLine("Please select a graph");
            int SelectCurrentGraph = Convert.ToInt32(Console.ReadLine());
            while ((SelectCurrentGraph > 3) && (SelectCurrentGraph < 1))
            {
                Console.WriteLine("Invalid Graph, please select another one");
                SelectCurrentGraph = Convert.ToInt32(Console.ReadLine());
            }
            //Adjust the value of the amount of vertices based on what graph is selected
            //Set current graph to the graph selected
            if (SelectCurrentGraph == 1)
            {
                int CurrentGraphVertices = Graph1Vertices;
                int[,] CurrentGraph = Graph1;
                Console.WriteLine("Please select a source/starting node");
                int SelectSourceNode = Convert.ToInt32(Console.ReadLine());
                while ((SelectSourceNode > 0) && (SelectSourceNode <= CurrentGraphVertices))
                {
                    int SourceNode = SelectSourceNode - 1;
                    ShortestPathAnalysis t = new ShortestPathAnalysis();
                    t.DijkstraAlgorithm(CurrentGraphVertices,CurrentGraph, SourceNode);
                }
            }
            else if (SelectCurrentGraph == 2)
            {
                int CurrentGraphVertices = Graph2Vertices;
                int[,] CurrentGraph = Graph2;
                Console.WriteLine("Please select a source/starting node");
                int SelectSourceNode = Convert.ToInt32(Console.ReadLine());
                while ((SelectSourceNode > 0) && (SelectSourceNode <= CurrentGraphVertices))
                {
                    int SourceNode = SelectSourceNode - 1;
                    ShortestPathAnalysis t = new ShortestPathAnalysis();
                    t.DijkstraAlgorithm(CurrentGraphVertices,CurrentGraph, SourceNode);
                }
            }
            else if (SelectCurrentGraph==3)
            {
                int CurrentGraphVertices = Graph3Vertices;
                int[,] CurrentGraph = Graph3;
                Console.WriteLine("Please select a source/starting node");
                int SelectSourceNode = Convert.ToInt32(Console.ReadLine());
                while ((SelectSourceNode>0)&& (SelectSourceNode <= CurrentGraphVertices))
                {
                    int SourceNode = SelectSourceNode - 1;
                    ShortestPathAnalysis t = new ShortestPathAnalysis();
                    t.DijkstraAlgorithm(CurrentGraphVertices,CurrentGraph, SourceNode);
                }
            }
        }
    }
    
}

        
