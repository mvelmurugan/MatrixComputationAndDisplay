using System;
using MatrixComputationAndDisplay;

namespace MatrixComputationAndDisplay.Test
{

    /// <summary>
    /// This class is used to test the methods in MatrixPopulater.
    /// </summary>
    public class TestDataProvider : IDataProvider
    {

        Logger logger = new Logger();

        /// <summary>
        /// This Method returns the hard coded decimal values.
        /// </summary>
        /// <returns>decimal array</returns>
        public decimal[] GetNumbers(string filePath)
        {
            return new decimal[] {1,2,3,4,5.75m,6,7,8,9,10 }; 
            
        }


    }
}
