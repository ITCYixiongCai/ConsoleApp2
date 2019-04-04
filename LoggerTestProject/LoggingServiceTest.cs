using System;
using System.Collections.Generic;
using System.IO;
using ConsoleApp2;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharedTypes;
using System.Linq;

namespace LoggerTestProject
{
    [TestClass]
    public class LoggingServiceTest
    {
        [TestMethod]
        public void ctor_Test()
        {
            var logger = new LoggingService();
            Assert.IsNotNull(logger);
        }
        [TestMethod]
        public void AppendLineToLogFile_Test()
        {
            var path = @"C:\Users\ITC\AppData\Roaming\sageAT\Info.log";
            if (File.Exists(path))
                 File.Delete(path);
            var logger = new LoggingService();
            logger.Init();
            logger.Log("Testmessage_1234");
            using (var sr = new StreamReader(path))
            {
                var logcontent = sr.ReadToEnd();
                
                Assert.IsTrue(logcontent.Contains("Testmessage1234"), "TestMessage_1234 nicht gefunden");
            }
        }
        [TestMethod]
        public void AppendMultipleLines_Test()
        {
            var path = @"C:\Users\ITC\AppData\Roaming\sageAT\Info.log";
            if (File.Exists(path))
                File.Delete(path);
            
            var logger = new LoggingService();
            logger.Init();
            for (int i = 0; i < 10; i++)
            {
                logger.Log("Testmessage_");
            }

            using (var sr = new StreamReader(path))
            {
                var index = -1;

                while (!sr.EndOfStream)
                    {
                    var content = sr.ReadLine();
                    index++;
                    Assert.IsTrue(content.StartsWith("0") || content.StartsWith("1"));
                }

            }                
            
        }

        [TestMethod]
        public void DeleteRowByIndex_Test()
        {
            var logger = new LoggingService();
            logger.Init();

            var path = @"C:\Users\ITC\AppData\Roaming\sageAT\Info.log";

            if (File.Exists(path))
                File.Delete(path);

            logger.Log("test");
            logger.Log("test");
            logger.Log("test");

            logger.LogDeleteZeile(1);

            using (var sr = new StreamReader(path))
            {
                var index = -1;
                while (!sr.EndOfStream)
                {
                    index++;
                    var content = sr.ReadLine();
                    Assert.IsFalse(content.StartsWith("1"), $"Index 1 wurde nicht gelöscht");
                }
            }
            
        }

        [TestMethod]
        public void LogInit_Test()
        {
            var logger = new LoggingService();
            var path = @"C:\Users\ITC\AppData\Roaming\sageAT\Info.log";
            logger.Init();
            if (File.Exists(path))
                File.Delete(path);
            logger.Log("Testmessage_1234");

            using (var sr = new StreamReader(path))
            {
                var logcontent = sr.ReadToEnd();

                Assert.IsTrue(logcontent.Contains("Testmessage_1234"));
            }
        }

        [TestMethod]
        public void toLogModel_Test()
        {
            var logger = new LoggingService();
            var path = @"C:\Users\ITC\AppData\Roaming\sageAT\Info.log";

            logger.Init();
            using (var sw = new StreamWriter(path))
            {
                sw.Write("");
            }

            logger.Log(new LogLineModel { RowIndex = 0, LoggingTime = DateTime.Now, Message = "LogLineModelTest1" });
            logger.Log(new LogLineModel { RowIndex = 1, LoggingTime = DateTime.Now, Message = "LogLineModelTest2" });
            logger.Log(new LogLineModel { RowIndex = 2, LoggingTime = DateTime.Now, Message = "LogLineModelTest3" });
            logger.Log(new LogLineModel { RowIndex = 3, LoggingTime = DateTime.Now, Message = "LogLineModelTest4" });

            using (var sr = new StreamReader(path))
            {
                var logcontent = sr.ReadToEnd();

                Assert.IsTrue(logcontent.Contains("LogLineModelTest"));
            }

            var list = new List<string>();

            using (var sr = new StreamReader(path))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine();
                    list.Add(line);
                }
            }

            var erg1 = list.Where(x => x.StartsWith("0")).Count();
            var erg2 = list.Where(x => x.StartsWith("3")).Count();
            Assert.IsTrue(erg1 == 1);
            Assert.IsTrue(erg2 == 1);
            Assert.IsTrue(list.Count == 4);
        }



    }
}
