using System;
using System.Linq;
using System.IO;
using System.Configuration;

namespace MatrixComputationAndDisplay
{
    /// <summary>
    /// This class is used to read the values from the .prm file which is in the bin folder. 
    /// </summary>
    public class FileDataProvider : IDataProvider
    {
        Logger logger = new Logger();  
        
        /// <summary>
        /// Read the files specified in the app.config file and converts into decimal, returning decimal array.
        /// </summary>
        /// <returns>decimal array</returns>
        public decimal[] GetNumbers(string filePath)
        {
            try
            {
                //string filePath = ConfigurationManager.AppSettings["FilePath"];
                var numbers = File.ReadAllLines(filePath)
                  .Select(i => Convert.ToDecimal(i))
                  .ToArray();
                return numbers;
            }catch(Exception ex)
            {
                logger.WriteLog(ex.Message);
                throw ex;
            }
        }
    }
}
