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
        /// 
        private int _currentRowIndex = -1;

        private string Logfile;

        public void Init()
        {
            var path = (string)Environment.GetEnvironmentVariables()["APPDATA"];
            var folder = Path.Combine(path, "sageAT");
            Logfile = Path.Combine(folder, "Info.log");
        }

        public void Log(string toLog)
        {
            
            DateTime date = DateTime.Now;
            var path = (string)Environment.GetEnvironmentVariables()["APPDATA"];
            var folder = Path.Combine(path, "sageAT");
            
            Directory.CreateDirectory(folder);
            using (var sw = new StreamWriter(Logfile, append: true))
            {
                _currentRowIndex++;
                sw.WriteLine($"{_currentRowIndex} | {toLog} + {date.ToString()}");
            }
        }
        
        public void Logdelete()
        {
            string path = @"C:\Users\ITC\AppData\Roaming\sageAT\Info.log";
            if (File.Exists(path))
                File.Delete(path);

        }

        public void LogDeleteZeile(int rowIndex)
        {
            var list= new List<string>();
            var path = (string)Environment.GetEnvironmentVariables()["APPDATA"];
            var folder = Path.Combine(path, "sageAT");
            
           
            using (var sr = new StreamReader(Logfile))
            {
                while (!sr.EndOfStream)
                {
                    list.Add(sr.ReadLine());
                }
                for (int i = 0; i < list.Count; i++)
                {
                    var isLineToDelete = list[i].StartsWith(rowIndex.ToString());
                    if (isLineToDelete)
                    {
                        list.RemoveAt(i);
                        break;
                    }
                }
            }
            using (var sw = new StreamWriter(Logfile))
            {
                foreach (var line in list)
                {
                    sw.WriteLine(line);
                }
            }
        }

    }
}
