using System;
using System.Configuration;

namespace MatrixComputationAndDisplay
{
    /// <summary>
    /// This is the main class to invoke from the command line. This Method will call the Matrix populater by using dependency injection.
    /// Also, this method has pre validation checks to make sure that the application won't break at run time. 
    /// Finally, the result will be displayed in a 2D Matrix format.
    /// </summary>
    /// 
    class Program
    {
        
         
        static void Main(string[] args)
        {
            int PRECISION = Convert.ToInt32(ConfigurationManager.AppSettings["Precision"]);
            int c, n;
            Console.WriteLine("Please Enter the size of the Output Matrix : ");
            while (!int.TryParse(Console.ReadLine(), out c))
            {
                Console.WriteLine("Please Enter a Valid Numerical Value!");
                Console.WriteLine("Please Enter the Size of the Output Matrix : ");
            }
            Console.WriteLine("Please Enter the Upper Limit : ");
            while (!int.TryParse(Console.ReadLine(), out n))
            {
                Console.WriteLine("Please Enter a Valid Numerical Value!");
                Console.WriteLine("Please Enter the Upper Limit : ");
            }
            string filePath;
            do
            {

                Console.WriteLine(@"Please Enter the Path with File Name  (C:\example.prn) : ");
                filePath = Console.ReadLine();
                if (filePath.Trim() != "" ) break;
            } while (true);

            MatrixPopulator matrixPopulator = new MatrixPopulator(new FileDataProvider() );
            matrixPopulator.FilePath = filePath;
            //decimal[,] output = matrixPopulator.Populate(c, n);
            decimal[,] output = matrixPopulator.Populate(c, n, PRECISION);
            Console.WriteLine("The Output is as Follows : ");
            for (int k = 0 ; k <= c ; k++)
            {
                for (var j = 0 ; j <= c ; j++)
                {
                    Console.Write(output[k, j] + "\t");
                }
                Console.WriteLine();
            }

            Console.ReadLine();
        }


    }
}
