using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LogProcessor
{
    class Program
    {
        static void Main(string[] args)
        {

            string tempLineTimeStamp="";
            string tempLog = "";
            int numLinesRead = 0;
            int numLinesWrite = 0;
            string outputDir=@"D:\";

                Parallel.ForEach( Directory.EnumerateFiles(@outputDir, "Log3*.txt", SearchOption.TopDirectoryOnly), (file) =>
                {
                    
                    foreach (string line in File.ReadLines(file))
                    {

                        numLinesRead++;
                        string NewFile = outputDir + "Processed_" + Path.GetFileName(file);
                        if (line.Contains("Timestamp"))
                        {
                            tempLineTimeStamp = line;
                        }
                        if (line.Contains("TracerExit Machine"))
                        {
                            tempLog = tempLineTimeStamp + line + tempLog + Environment.NewLine;
                            File.AppendAllText(@NewFile, tempLog);
                            numLinesWrite++;

                        }
                        if (line.Contains("End Trace"))
                        {
                            tempLog = line;
                        }
                    }
                });

        }
    }
}
