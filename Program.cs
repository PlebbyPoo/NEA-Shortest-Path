using System;

namespace NEAProject
{
    public class Program 
    {
        public static void Main(string[] args)
        {
            //Creating the first graph of 3           
            double pInfinity = double.PositiveInfinity;
            double[,] Graph1 = new double[5, 5]
                {
            {0,2,4, pInfinity, pInfinity },
            {2,0,1,5, pInfinity },
            {4,1,0,3,1 },
            {pInfinity,5,3,0,pInfinity },
            {pInfinity,pInfinity,1,pInfinity,0 } };
            //Create the list of nodes for Graph1
            
            //Creating the second graph
            double[,] Graph2 = new double[8, 8]
                {
                {0,2,pInfinity,2,pInfinity,pInfinity,8,pInfinity },
                {2,0,1,pInfinity,pInfinity,3,pInfinity,5 },
                {pInfinity,1,0,1,pInfinity,pInfinity,pInfinity,pInfinity },
                {2,pInfinity,1,0,2,pInfinity,pInfinity,pInfinity },
                {pInfinity,pInfinity,pInfinity,2,0,1,pInfinity,pInfinity },
                {pInfinity,3,pInfinity,pInfinity,1,0,3,pInfinity },
                {8,pInfinity,pInfinity,pInfinity,pInfinity,3,0,1 },
                {pInfinity,5,pInfinity,pInfinity,pInfinity,pInfinity,1,0 } };
            //Create the list of nodes for Graph2

            //Creating the third graph
            double[,] Graph3 = new double[10, 10]
            {
                {0,pInfinity,1,4,5,pInfinity,pInfinity,pInfinity,pInfinity,15 },
                {pInfinity,0,pInfinity,pInfinity,pInfinity,3,pInfinity,pInfinity,5,pInfinity },
                {1,pInfinity,0,2,pInfinity,pInfinity,pInfinity,pInfinity,pInfinity,pInfinity },
                {4,pInfinity,2,0,1,pInfinity,1,pInfinity,pInfinity,pInfinity },
                {5,pInfinity,pInfinity,1,0,pInfinity,pInfinity,pInfinity,pInfinity,pInfinity },
                {pInfinity,3,pInfinity,pInfinity,pInfinity,0,3,2,4,pInfinity },
                {pInfinity,pInfinity,pInfinity,1,pInfinity,3,0,6,pInfinity,pInfinity },
                {pInfinity,pInfinity,pInfinity,pInfinity,pInfinity,2,6,0,5,pInfinity },
                {pInfinity,5,pInfinity,pInfinity,pInfinity,5,pInfinity,5,0,3 },
                {15,pInfinity,pInfinity,pInfinity,pInfinity,pInfinity,pInfinity,pInfinity,3,0 } };
            //Create the list of nodes for Graph3
        }
    }
    
}

        
