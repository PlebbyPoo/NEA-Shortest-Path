using System;

namespace NEAProject
{
    public class Program 
    {
        public static void Main(string[] args)
        {
            double pInfinity = double.PositiveInfinity;
            double[][] Graph1 =
                {
            new double[]{0,2,4, pInfinity, pInfinity },
            new double[]{2,0,1,5, pInfinity },
            new double[]{4,1,0,3,1 },
            new double[]{pInfinity,5,3,0,pInfinity },
            new double[]{pInfinity,pInfinity,1,pInfinity,0 } };
            Console.WriteLine(Graph1);
        }
    }
    
}

        
