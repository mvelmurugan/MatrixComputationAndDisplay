using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MatrixComputationAndDisplay
{
    /// <summary>
    /// This class is used to get the numbers from the files, parse it  and convert into a 2D Matrix. 
    /// It has 2 overloaded methods for populating the values.
    /// </summary>
    public class MatrixPopulator
    {
        IDataProvider dataProvider; 
        Logger logger = new Logger();
        public string FilePath { get; set; }

        /// <summary>
        /// Using dependency injection it creates the object.
        /// </summary>
        /// <param name="provider"></param>
        public MatrixPopulator(IDataProvider provider)
        {             
            this.dataProvider = provider;            
        }

        /// <summary> 
        /// Based on the Size and Upper Limit , it will create the 2D Matrix. This method is optimized based on the below formula. 
        ///  O(k, j) = O(j, k) for all k > 0 and j < k where O is output matrix and I is input array 
        ///  O(k, j) = I(c -k) * I (c - j) + O(k-1, j-1) - I(n - k) * I(n -j ) for all k > 0 and j >= k where O is output matrix and I is input array 
        /// </summary> 
        /// <param name="c"> Size</param> 
        /// <param name="n">Upper Limit</param> 
        /// <returns> Decimal Array</returns>
       
        public decimal[,] Populate(int c, int n)
        {
            try
            {
                 if(!File.Exists(FilePath)) throw new FileNotFoundException($"The Specified file is not found in the follwing path : {FilePath}");
                 if (c < 0 ) throw new ArgumentOutOfRangeException("The Size of the Output Matrix must be greater than 0.");
                 if (c >= n) throw new ArgumentOutOfRangeException("The Upper Limit value should be greater than Size of the Output Matrix.");

                var numbers = dataProvider.GetNumbers(FilePath);

                if (n > numbers.Length) throw new ArgumentOutOfRangeException("The Upper Limit should be less than total value in file. Please check the file" );

                decimal[,] output = new decimal[c + 1, c + 1];
                for (int k = 0 ; k <= c ; k++)
                {
                    for (var j = 0 ; j <= c ; j++)
                    {
                        if (k > 0)
                        {
                            if (j < k)
                            {
                                output[k, j] = output[j, k];
                            } else
                            {
                                
                                    output[k, j] = (numbers[c - k] * numbers[c - j])
                                        + output[k - 1, j - 1]
                                        - (numbers[n - k] * numbers[n - j]);
                                 
                            }
                            continue;
                        }
                        decimal total = 0;
                        for (var i = c ; i < n ; i++)
                        {
                            total += numbers[i - k] * numbers[i - j];
                        }
                        
                      output[k, j] = total;
                         
                    }
                }

                return output;
            }catch(Exception ex)
            {
                logger.WriteLog(ex.Message);
                throw ex;
            }

        }

        /// <summary>
        /// Based on the Size , Upper Limit and Precision, it will create the 2D Matrix. This method is optimized based on the below formula.
        ///  O(k, j) = O(j, k)
        ///  O(k, j) = I(c -k) * I (c - j) + O(k-1, j-1) - I(n - k) * I(n -j )
        /// </summary>
        /// <param name="c">Size</param>
        /// <param name="n">Upper Limit</param>
        /// <param name="precision">Precision</param>
        /// <returns></returns>
        public decimal[,] Populate(int c, int n, int precision)
        {
            try
            {                 
                 if (precision < 0 ) throw new ArgumentOutOfRangeException("The Precision should be greater than 0");
                decimal[,] output = Populate(c, n);

                for (int k = 0 ; k <= c ; k++)
                {
                    for (var j = 0 ; j <= c ; j++)
                    {
                        output[k, j] = Math.Round(output[k, j], precision);
                    }
                     
                }
                return output;
            } catch (Exception ex)
            {
                logger.WriteLog(ex.Message);
                throw ex;
            }
        }

    }
}
