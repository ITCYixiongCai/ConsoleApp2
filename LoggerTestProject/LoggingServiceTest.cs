using System;
using System.Collections.Generic;
using System.IO;
using ConsoleApp2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
                    Assert.IsTrue(content.StartsWith("1"), "Index 1 wurde nicht gelöscht");
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

    }
}
