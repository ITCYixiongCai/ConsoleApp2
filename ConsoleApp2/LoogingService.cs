using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class LoggingService
    {
 
    /// <summary>
    /// Soll ein Eintrag in die Info.log anhängen.
    /// </summary>
    /// <param name="toLog"></param>
        public void Log(string toLog)
    {
        var path = (string)Environment.GetEnvironmentVariables()["APPDATA"];
        var folder = Path.Combine(path, "sageAT");
        var logfile = Path.Combine(folder, "Info.log");
        Directory.CreateDirectory(folder);
        using (var sw = new StreamWriter(logfile, append: true))
        {
            sw.WriteLine(toLog.Replace("_",""));
        }
    }
    }
}
