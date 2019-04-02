using System;
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
            logger.Log("Testmessage_1234");
            using (var sr = new StreamReader(path))
            {
                var logcontent = sr.ReadToEnd();
                Assert.IsTrue(logcontent.Contains("Testmessage1234"), "TestMessage_1234 nicht gefunden");
            }
        }
    }
}
