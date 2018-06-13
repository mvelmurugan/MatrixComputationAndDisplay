using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; 

namespace MatrixComputationAndDisplay
{
    /// <summary>
    /// This class is used to write a log file if there is an unhandled exception. The file will be placed in bin folder.
    /// </summary>
    /// 
   public class Logger
    {
        public void WriteLog(string logMessage)
        {
            StreamWriter log;

            if (!File.Exists("logfile.txt"))
            {
                log = new StreamWriter("logfile.txt");
            } else
            {
                log = File.AppendText("logfile.txt");
            }

            // Write to the file:
            log.WriteLine(DateTime.Now);
            log.WriteLine(logMessage);
            log.WriteLine();

            // Close the stream:
            log.Close();
        }
    }
}
