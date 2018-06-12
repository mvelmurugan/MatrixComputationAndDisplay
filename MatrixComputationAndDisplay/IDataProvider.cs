using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixComputationAndDisplay
{
    /// <summary>
    /// This interface will be implemented in file data provider class and test provider class. 
    /// </summary>
    public interface IDataProvider
    {
        decimal[] GetNumbers(string  filePath);
    }
}
